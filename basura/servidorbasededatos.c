#include <unistd.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <pthread.h>
//Incluir esta libreria para poder hacer las llamadas en shiva2.upc.es
//#include <my_global.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int contador;

// Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i;
int sockets[100];

void *AtenderCliente(void *socket) 
{
	int sock_conn;
	int *s;
	s = (int *)socket;
	sock_conn = *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		int numForm;
		// Ya tenemos el codigo de la peticion
		char nombre[20];
		
		if (codigo !=0)
		{
			p = strtok( NULL, "/");
			numForm =  atoi (p);
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			// Ya tenemos el nombre
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		
		if (codigo ==0) //peticion de desconexion
			terminar=1;
		else if (codigo ==1) // nos llega el nombre de usuario
			
		else if (codigo ==2) // nos llega el correo
			
		else if (codigo ==3) // nos llega la contraseña
		
		if (codigo !=0)
		{
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
		}
		if ((codigo ==1)||(codigo==2)|| (codigo==3))
		{
			pthread_mutex_lock( &mutex ); //No me interrumpas ahora
			contador = contador +1;
			pthread_mutex_unlock( &mutex); //ya puedes interrumpirme
			// notificar a todos los clientes conectados
			char notificacion[20];
			sprintf (notificacion, "4/%d",contador);
			int j;
			for (j=0; j< i; j++)
				write (sockets[j],notificacion, strlen(notificacion));
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
	
}	
		
int main(int argc, char *argv[]) 
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//Creamos una conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) 
	{
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","user", "pass", "Play",0, NULL, 0);
	if (conn==NULL) 
	{
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// consulta SQL para obtener una tabla con todos los datos
	// de la base de datos
	err=mysql_query (conn, "SELECT * FROM Player"); //seleccionamos todo de la tabla Player de la base de datos
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	err=mysql_query (conn, "SELECT * FROM Game"); //seleccionamos todo de la tabla Game de la base de datos
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM Ranking"); //seleccionamos todo de la tabla Ranking de la base de datos
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM Dibujos"); //seleccionamos todo de la tabla Dibujos de la base de datos
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	// En una fila hay tantas columnas como datos tiene una
	// persona. En nuestro caso hay cinco columnas: Id(row[0]),
	// Username(row[1]), Name(row[2]), Address(row[3]) y Password(row[4]).
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
		while (row !=NULL) 
	{
			// la columna 0 contiene una palabra que es el Id
			// la convertimos a entero
			Id = atoi (row[0]);
			printf ("Id: %d, username: %s, name: %s, address: %s\n", Id, row[1], row[2], row[3]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
	}
	
		// Ahora vamos a buscar el nombre de la persona cuyo Id es uno
		// dado por el usuario
		printf ("Dame el Id de la persona que quieres buscar\n");
		scanf ("%s", Id);
		// construimos la consulta SQL
		strcpy (consulta,"SELECT Name FROM Player WHERE Id = '");
		strcat (consulta, Id);
		strcat (consulta,"'");
		// hacemos la consulta
		err=mysql_query (conn, consulta);
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//recogemos el resultado de la consulta
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		else
			// El resultado debe ser una matriz con una sola fila
			// y una columna que contiene el nombre
			printf ("Nombre de la persona: %s\n", row[2] );
		// cerrar la conexion con el servidor MYSQL
		mysql_close (conn);
		exit(0);
		
		// mostrar el Ranking
		// construimos la consulta SQL
		char consulta[] = 
			"SELECT Player.Username, Game.Points "
			"FROM Ranking "
			"JOIN Player ON Ranking.Player_id = Player.Id "
			"JOIN Game ON Ranking.Game_id = Game.Id "
			"ORDER BY Game.Points DESC";
		
		// ejecutar la consulta
		err = mysql_query(conn, consulta);
		if (err != 0) {
			printf("Error al consultar datos de la base %u %s\n",
				   mysql_errno(conn), mysql_error(conn));
			mysql_close(conn);
			exit(1);
		}
		// Recoger los resultados
		resultado = mysql_store_result(conn);
		if (resultado == NULL) {
			printf("Error al obtener resultados: %u %s\n", mysql_errno(conn), mysql_error(conn));
			mysql_close(conn);
			exit(1);
		}
		
		// imprimir el ranking
		printf("Ranking:\n");
		
		while ((row = mysql_fetch_row(resultado))) {
			printf("Player: %s, Points: %s\n", row[0], row[1]);
		}
		// liberar memoria
		mysql_free_result(resultado);
		
}
	
	
	
	
	
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// INICIALIZACIONES
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Hacemos el bind al port
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicializa a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la maquina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9050);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	contador =0;
	
	pthread_t thread;
	i=0;
	for (;;)
	{
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
		
	}
	
}

