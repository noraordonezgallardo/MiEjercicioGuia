#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>

#define MAX_CLEGIOS 10
#define MAX_PARTIDOS 10

// Estructura para pasar parámetros a los threads
typedef struct {
	int id;
	char nombre[20];
} Tparam;

// Matriz global de votos
int votaciones[MAX_CLEGIOS][MAX_PARTIDOS];

// Mutex para acceso excluyente
pthread_mutex_t accesoexcluyente;

void *procesar_votos_fichero(void *arg) {
	Tparam *p = (Tparam *)arg;
	FILE *f = fopen(p->nombre, "r");
	if (f == NULL) {
		perror("Error abriendo archivo");
		pthread_exit(NULL);
	}
	
	int j;
	for (j = 0; j < MAX_PARTIDOS; j++) {
		int votos;
		fscanf(f, "%d", &votos);
		
		pthread_mutex_lock(&accesoexcluyente);
		votaciones[p->id][j] += votos;
		pthread_mutex_unlock(&accesoexcluyente);
	}
	fclose(f);
	free(p);
	pthread_exit(NULL);
}

int main() {
	pthread_t thread[MAX_CLEGIOS];
	Tparam *param[MAX_CLEGIOS];
	int i, j, n;
	
	// Inicializar la matriz de votos a 0
	for (i = 0; i < MAX_CLEGIOS; i++)
		for (j = 0; j < MAX_PARTIDOS; j++)
			votaciones[i][j] = 0;
			
			// Inicializar mutex
			pthread_mutex_init(&accesoexcluyente, NULL);
			
			printf("\n¿Cuántos colegios hay?: ");
			scanf("%d", &n);
			
			// Crear un thread para cada colegio electoral
			for (i = 0; i < n; i++) {
				param[i] = malloc(sizeof(Tparam));
				param[i]->id = i;
				sprintf(param[i]->nombre, "colegio%d.txt", i);
				pthread_create(&thread[i], NULL, procesar_votos_fichero, (void *)param[i]);
			}
			
			// Esperar a que todos los threads terminen
			printf("Esperamos que acaben los %d threads\n", n);
			for (i = 0; i < n; i++) {
				pthread_join(thread[i], NULL);
			}
			
			// Acumular los votos
			printf("Acumulamos votos\n");
			for (i = 1; i < n; i++) {
				for (j = 0; j < MAX_PARTIDOS; j++) {
					votaciones[0][j] += votaciones[i][j];
				}
			}
			
			// Mostrar los resultados
			printf("Resultados\n");
			for (j = 0; j < MAX_PARTIDOS; j++) {
				printf("Votos para el partido %d: %d\n", j, votaciones[0][j]);
			}
			
			// Destruir mutex
			pthread_mutex_destroy(&accesoexcluyente);
			
			return 0;
}
