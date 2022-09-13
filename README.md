# Maze Game

## Objetivo

Este es el primer proyecto de la asignatura **Desarrollo de Sistemas Gráficos**, del curso 4 del **Grado en Informática de Gestión y Sistemas de Información** impartido en la **Escuela de Ingeniería de Vitoria-Gasteiz**.


## Pasos a seguir

Algunos de estos pasos se pueden hacer de manera concurrente. Intentad repartiros el trabajo de manera que nadie esté esperando a otra persona

1. Lo primero de todo es acordar cómo vamos a representar en memoria el contenido de la mazmorra. Hay que hacer un esquema que muestre la relación entre la mazmorra vista como una matriz y el array de caracteres que tenemos en Maze.Cells. Este dibujo lo guardaremos como una imagen (foto con el móvil por ejemplo) y lo añadiremos al repositorio en docs/maze.jpg para que todo el mundo lo tenga claro

2. Implementar el constructor Maze(string fileContent). El string que se le pasa representa el contenido leído de un fichero. Algo así:

````
  # 
  1# 
  #2 
   # 
````

En este ejemplo, el jugador 1 solo puede moverse a la izquierda, y el 2 a la derecha. La pared está representada por el carácter '#'

3. Implementar el método CellContent(int x, int y) que devuelve el carácter que está en la celda (x,y)
4. Implementar el método SetCellContent(int x, int y, char content) que modifica el contenido de la celda (x,y) <= content
5. Implementar el método MovePlayer(int playerId, Direction direction). Este método debe usar CellContent() y SetCellContent() para decidir si el jugador #playerId puede moverse en la dirección indicada, y qué pasa si se mueve (moneda?)
6. Implementar el método OnPlayerCollectedCoin(int playerId) al que se llamará desde MovePlayer() cada vez que un jugador se mueva a una celda donde haya una moneda
7. Corregir errores hasta que todos los test pasen
8. Implementar Game.ProcessKeys(int keyCode)
9. Implementar la clase Screen: se le pasa un mensaje en el constructor, y cuando se llama a Draw(), vacía la consola y escribe el mensaje. Usarlo para crear en Maze.Run() una pantalla de inicio con el título del juego y una pantalla de fin con el resultado de la partida
10. Añadir al juego sonidos de inicio, fin y moneda. Para eso, usaremos la clase GameEngine.Sounds.Sound. Añadir la librería NetCoreAudio desde NuGet y descomentar la clase Sound
11. Mejorar el juego todo lo que se os ocurra (varios mapas, colores diferentes para cada tipo de casilla,...)