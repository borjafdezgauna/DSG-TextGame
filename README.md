# Maze Game

## Objetivo

Este es el primer proyecto de la asignatura **Desarrollo de Sistemas Gr�ficos**, del curso 4 del **Grado en Inform�tica de Gesti�n y Sistemas de Informaci�n** impartido en la **Escuela de Ingenier�a de Vitoria-Gasteiz**.


## Pasos a seguir

Algunos de estos pasos se pueden hacer de manera concurrente. Intentad repartiros el trabajo de manera que nadie est� esperando a otra persona

1. Lo primero de todo es acordar c�mo vamos a representar en memoria el contenido de la mazmorra. Hay que hacer un esquema que muestre la relaci�n entre la mazmorra vista como una matriz y el array de caracteres que tenemos en Maze.Cells. Este dibujo lo guardaremos como una imagen (foto con el m�vil por ejemplo) y lo a�adiremos al repositorio en docs/maze.jpg para que todo el mundo lo tenga claro

2. Implementar el constructor Maze(string fileContent). El string que se le pasa representa el contenido le�do de un fichero. Algo as�:

````
  # 
  1# 
  #2 
   # 
````

En este ejemplo, el jugador 1 solo puede moverse a la izquierda, y el 2 a la derecha. La pared est� representada por el car�cter '#'

3. Implementar el m�todo CellContent(int x, int y) que devuelve el car�cter que est� en la celda (x,y)
4. Implementar el m�todo SetCellContent(int x, int y, char content) que modifica el contenido de la celda (x,y) <= content
5. Implementar el m�todo MovePlayer(int playerId, Direction direction). Este m�todo debe usar CellContent() y SetCellContent() para decidir si el jugador #playerId puede moverse en la direcci�n indicada, y qu� pasa si se mueve (moneda?)
6. Implementar el m�todo OnPlayerCollectedCoin(int playerId) al que se llamar� desde MovePlayer() cada vez que un jugador se mueva a una celda donde haya una moneda
7. Corregir errores hasta que todos los test pasen
8. Implementar Game.ProcessKeys(int keyCode)
9. Implementar la clase Screen: se le pasa un mensaje en el constructor, y cuando se llama a Draw(), vac�a la consola y escribe el mensaje. Usarlo para crear en Maze.Run() una pantalla de inicio con el t�tulo del juego y una pantalla de fin con el resultado de la partida
10. A�adir al juego sonidos de inicio, fin y moneda. Para eso, usaremos la clase GameEngine.Sounds.Sound. A�adir la librer�a NetCoreAudio desde NuGet y descomentar la clase Sound
11. Mejorar el juego todo lo que se os ocurra (varios mapas, colores diferentes para cada tipo de casilla,...)