using System;
using System.Collections.Generic;
using System.Text;


namespace TextGame
{
    public class Game
    {
        Maze Maze;

        public void Run()
        {
            InputController inputController = new InputController(ProcessKeys);

            //Hide the cursor
            Console.CursorVisible = false;

            //Start screen
            //TODO: show a start screen with the title of the game, and wait until a key is pressed

            string mazeConfig = System.IO.File.ReadAllText("..\\..\\..\\..\\data\\map-1.txt");
            Maze = new Maze(mazeConfig);

            while (!GameEnded && Maze.NumCoinsLeft > 0)
            {
                //Draw the maze
                Maze.Draw();
                inputController.ProcessKeys();
            }

            //End screen
            //TODO: show an end screen with a message saying who won and wait until a key is pressed
        }


        bool GameEnded = false;

        private void ProcessKeys(int keyCode)
        {
            switch(keyCode)
            {
                case 'a': Maze.MovePlayer(1, Maze.Direction.Left); break;
                //TODO:
                //1) Map keys to player movements: a,s,d,w for player 1, and 1,2,3,5 for player 2
                //2) Finish the game when ESC (ASCII code 27) is pressed
            }
        }
    }
}
