
using System;
using System.Threading.Tasks;

namespace TextGame
{
    public class Maze
    {
        public const char Player1Char = '1';
        public const char Player2Char = '2';
        public const char WallChar = '#';
        public const char CoinChar = '?';
        public const char EmptyChar = ' ';

        public char[] Cells;
        public int Width { get; }
        public int Height{ get; }

        public int NumCoinsLeft { get; private set; } = 0;

        public Player Player1 = new Player(1);
        public Player Player2 = new Player(2);

        public Action OnCoinCollected { get; set; } //We can tell the maze what to do when a coin is collected. For example, play a sound

        public Maze(string fileContent)
        {
            //TODO
        }

        private void OnPlayerCollectedCoin(int playerId)
        {
            /*
             * TODO
             */

            OnCoinCollected?.Invoke();
        }

        public char CellContent(int x, int y)
        {
            //TODO
            return EmptyChar;
        }

        public void SetCellContent(int x, int y, char content)
        {
            //TODO
        }

        //private bool IsFirstTime = true;
        public void Draw()
        {
            //TODO: Draw the contents of the maze using Console.SetCursorPosition(x,y) and Console.Write(CellContent(x,y)) foreach cell (x,y)
            
            Task.Delay(500);
        }

        public enum Direction { Up, Down, Left, Right}
        public void MovePlayer(int playerId, Direction direction)
        {
            //Move player #playerId
            //Don't step over the other player
            //Don't step over walls
            //If there is a coin, call OnPlayerCollectedCoin()
        }
    }
}
