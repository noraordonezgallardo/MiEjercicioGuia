// Incluir la librería para MySQL
#include <mysql .h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char **argv)
{
    // Estructura especial para almacenar resultados de consultas
    MYSQL *conn;
    MYSQL_RES *resultado;
    MYSQL_ROW row;
    int err;

    // Creamos conexión al servidor MySQL
    conn = mysql_init(NULL);
    if (conn == NULL) {
        printf("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
        exit(1);
    }

    // Inicializar la conexión
    conn = mysql_real_connect(conn, "localhost", "root", "mysql", "Play", 0, NULL, 0);
    if (conn == NULL) {
        printf("Error al conectar a la base de datos: %u %s\n", mysql_errno(conn), mysql_error(conn));
        exit(1);
    }

    // Consulta SQL
    err = mysql_query(conn,
        "SELECT Player.Name, Game.Points FROM Player, Game, Ranking WHERE Player.Id = Ranking.Player_id "
        "AND Game.Id = Ranking.Game_id "
        "ORDER BY Game.Points DESC");
    
    
    if (err != 0) {
        printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
        exit(1);
    }

    // Recoger el resultado de la consulta
    resultado = mysql_store_result(conn);
    if (resultado == NULL) {
        printf("Error al almacenar resultado: %u %s\n", mysql_errno(conn), mysql_error(conn));
        exit(1);
    }

    // Procesar los resultados e imprimir el ranking
    int ranking = 1;
    while ((row = mysql_fetch_row(resultado))) {
        printf("%d. %s - %s puntos\n", ranking, row[0], row[1]);
        ranking++;
    }

    // Liberar memoria y cerrar conexión
    mysql_free_result(resultado);
    mysql_close(conn);

    return 0;
}
