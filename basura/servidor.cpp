#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>

int contador;
int sockets[100];
int i;

// Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void *AtenderCliente(void *socket) 
{
    int sock_conn;
    int *s;
    s = (int *)socket;
    sock_conn = *s;

    char peticion[512];
    char respuesta[512];
    int ret;
    int terminar = 0;

    // Conectar a la base de datos
    MYSQL *conn;
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

    // Bucle para atender al cliente
    while (terminar == 0) {
        ret = read(sock_conn, peticion, sizeof(peticion));
        printf("Recibido\n");

        peticion[ret] = '\0'; // Añadir marca de fin de string
        printf("Peticion: %s\n", peticion);

        // Procesar la petición
        char *p = strtok(peticion, "/");
        int codigo = atoi(p);

        int numForm;
        char nombre[50];
        char correo[100];
        char contrasena[50];

        if (codigo != 0) {
            p = strtok(NULL, "/");
            numForm = atoi(p);
            p = strtok(NULL, "/");
            strcpy(nombre, p);
        }

        if (codigo == 0) { // Petición de desconexión
            terminar = 1;
        } else if (codigo == 1) { // Nombre de usuario
            strcpy(nombre, p);
        } else if (codigo == 2) { // Correo
            strcpy(correo, p);
        } else if (codigo == 3) { // Contraseña y proceso de registro
            strcpy(contrasena, p);

            // Conectar a la base de datos
            MYSQL_RES *res;
            MYSQL_ROW row;

            char query[256];

            // Verificar si el correo ya existe
            sprintf(query, "SELECT * FROM Player WHERE Address='%s'", correo);
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                mysql_close(conn);
                pthread_exit(NULL);
            }
            res = mysql_store_result(conn);
            if (mysql_num_rows(res) > 0) {
                sprintf(respuesta, "Error: El correo ya está registrado.");
                write(sock_conn, respuesta, strlen(respuesta));
                mysql_free_result(res);
                continue;
            }
            mysql_free_result(res);

            // Verificar si el nombre de usuario ya existe
            sprintf(query, "SELECT * FROM Player WHERE Username='%s'", nombre);
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                mysql_close(conn);
                pthread_exit(NULL);
            }
            res = mysql_store_result(conn);
            if (mysql_num_rows(res) > 0) {
                sprintf(respuesta, "Error: El nombre de usuario ya existe.");
                write(sock_conn, respuesta, strlen(respuesta));
                mysql_free_result(res);
                continue;
            }
            mysql_free_result(res);

            // Insertar el nuevo usuario si no está repetido
            sprintf(query, "INSERT INTO Player (Id, Username, Name, Address, Password) VALUES (NULL, '%s', 'Nuevo Jugador', '%s', '%s')", nombre, correo, contrasena);
            if (mysql_query(conn, query)) {
                printf("Error al insertar usuario: %s\n", mysql_error(conn));
                mysql_close(conn);
                pthread_exit(NULL);
            }

            sprintf(respuesta, "Registro exitoso. Bienvenido, %s!", nombre);
            write(sock_conn, respuesta, strlen(respuesta));
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

    // INICIALIZACIONES
    // Abrimos el socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
        printf("Error creando socket\n");
        return -1;
    }

    // Configurar la dirección del servidor
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

    printf("Escuchando\n");

    contador = 0;
    pthread_t thread;
    i = 0;

    for (;;) {
        printf("Esperando conexión...\n");
        sock_conn = accept(sock_listen, NULL, NULL);
        printf("Conexión recibida\n");

        sockets[i] = sock_conn;

        // Crear un hilo para atender al cliente
        pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
        i++;
    }

    return 0;
}
