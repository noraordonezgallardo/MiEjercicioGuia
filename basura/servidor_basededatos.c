#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>

int sockets[100];
int i;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void *AtenderCliente(void *socket) {
    int sock_conn = *(int *)socket;
    char peticion[512];
    char respuesta[1024];
    int ret;
    int terminar = 0;

    // Conectar a la base de datos
    MYSQL *conn;
    MYSQL_RES *resultado;
    MYSQL_ROW row;
    int err;

    conn = mysql_init(NULL);
    if (conn == NULL) {
        printf("Error al inicializar MySQL\n");
        close(sock_conn);
        pthread_exit(NULL);
    }

    conn = mysql_real_connect(conn, "localhost", "root", "mysql", "Play", 0, NULL, 0);
    if (conn == NULL) {
        printf("Error al conectar a la base de datos: %s\n", mysql_error(conn));
        close(sock_conn);
        pthread_exit(NULL);
    }

    while (!terminar) {
        ret = read(sock_conn, peticion, sizeof(peticion));
        peticion[ret] = '\0';
        printf("Petición recibida: %s\n", peticion);

        if (strcmp(peticion, "GET_RANKING") == 0) {
            // Consulta SQL
            err = mysql_query(conn,
                "SELECT Player.Name, Game.Points FROM Player, Game, Ranking "
                "WHERE Player.Id = Ranking.Player_id AND Game.Id = Ranking.Game_id "
                "ORDER BY Game.Points DESC");

            if (err != 0) {
                sprintf(respuesta, "Error en la consulta\n");
            } else {
                resultado = mysql_store_result(conn);
                if (resultado == NULL) {
                    sprintf(respuesta, "Error al obtener resultados\n");
                } else {
                    strcpy(respuesta, "Ranking:\n");
                    int ranking = 1;
                    while ((row = mysql_fetch_row(resultado))) {
                        char linea[128];
                        sprintf(linea, "%d. %s - %s puntos\n", ranking, row[0], row[1]);
                        strcat(respuesta, linea);
                        ranking++;
                    }
                    mysql_free_result(resultado);
                }
            }
        } else if (strcmp(peticion, "EXIT") == 0) {
            terminar = 1;
            strcpy(respuesta, "Desconectando...\n");
        } else {
            strcpy(respuesta, "Comando no reconocido\n");
        }

        write(sock_conn, respuesta, strlen(respuesta));
    }

    mysql_close(conn);
    close(sock_conn);
    pthread_exit(NULL);
}

int main() {
    int sock_conn, sock_listen;
    struct sockaddr_in serv_adr;

    // Crear socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
        printf("Error creando socket\n");
        return -1;
    }

    memset(&serv_adr, 0, sizeof(serv_adr));
    serv_adr.sin_family = AF_INET;
    serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_adr.sin_port = htons(9050);

    if (bind(sock_listen, (struct sockaddr *)&serv_adr, sizeof(serv_adr)) < 0) {
        printf("Error en el bind\n");
        return -1;
    }

    if (listen(sock_listen, 3) < 0) {
        printf("Error en el listen\n");
        return -1;
    }

    printf("Servidor en espera de conexiones...\n");
    
    pthread_t thread;
    i = 0;
    while (1) {
        sock_conn = accept(sock_listen, NULL, NULL);
        printf("Nueva conexión recibida\n");

        sockets[i] = sock_conn;
        pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
        i++;
    }

    return 0;
}
