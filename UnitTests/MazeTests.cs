using System;
using Xunit;
using TextGame;

namespace UnitTests
{
    public class MazeTests
    {
        [Fact]
        public void MazeDrawingInDocsDirectory()
        {
            Assert.True(System.IO.File.Exists("..\\..\\..\\..\\docs\\maze.jpg"));
        }

        [Fact]
        public void ExceptionIfSomeLinesAreLongerThanOthers()
        {
            Maze maze;
            Assert.Throws<Exception>(() => { maze = new Maze($"    \n     \n    \n    "); });
            Assert.Throws<Exception>(() => { maze = new Maze($"    \n    \n  \n    "); });
        }

        [Fact]
        public void WidthAndHeight()
        {
            Maze maze = new Maze($"    \n    \n    \n    ");
            Assert.Equal(4, maze.Width);
            Assert.Equal(4, maze.Height);

            maze = new Maze($"    \n    ");
            Assert.Equal(4, maze.Width);
            Assert.Equal(2, maze.Height);
        }

        [Fact]
        public void CellsArrayLength()
        {
            Maze maze = new Maze($"    \n    \n    \n    ");
            Assert.Equal(16, maze.Cells.Length);

            maze = new Maze($"    \n    ");
            Assert.Equal(8, maze.Cells.Length);
        }

        [Fact]
        public void SetGetCellContent()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");

            maze.SetCellContent(1, 1, 'r');
            Assert.Equal('r', maze.CellContent(1, 1));
            maze.SetCellContent(1, 3, 'r');
            Assert.Equal('r', maze.CellContent(1, 3));
        }

        [Fact]
        public void SetGetCellContentOutsideBounds()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");

            maze.SetCellContent(1, 1, 'r');
            Assert.Equal('r', maze.CellContent(1, 1));
            maze.SetCellContent(1, 3, 'r');
            Assert.Equal('r', maze.CellContent(1, 3));
        }

        [Fact]
        public void PlayersInitialization()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");
            Assert.Equal(Maze.Player1Char, maze.CellContent(0, 0));
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 3));
        }

        [Fact]
        public void MovePlayer1()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");

            maze.MovePlayer(1, Maze.Direction.Down);
            Assert.Equal(Maze.Player1Char, maze.CellContent(0, 0));
            maze.MovePlayer(1, Maze.Direction.Left);
            Assert.Equal(Maze.Player1Char, maze.CellContent(0, 0));
            maze.MovePlayer(1, Maze.Direction.Right);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(0, 0));
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 0));
            maze.MovePlayer(1, Maze.Direction.Up);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(1, 0));
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 1));
            maze.MovePlayer(1, Maze.Direction.Left);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(1, 1));
            Assert.Equal(Maze.Player1Char, maze.CellContent(0, 1));
            maze.MovePlayer(1, Maze.Direction.Left);
            Assert.Equal(Maze.Player1Char, maze.CellContent(0, 1));
        }
        [Fact]
        public void MovePlayer2()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");

            maze.MovePlayer(2, Maze.Direction.Up);
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 3));
            maze.MovePlayer(2, Maze.Direction.Right);
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 3));
            maze.MovePlayer(2, Maze.Direction.Left);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(3, 3));
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 3));
            maze.MovePlayer(2, Maze.Direction.Down);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(2, 3));
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 2));
            maze.MovePlayer(2, Maze.Direction.Right);
            Assert.Equal(Maze.EmptyChar, maze.CellContent(2, 2));
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 2));
            maze.MovePlayer(2, Maze.Direction.Right);
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 2));
            maze.MovePlayer(2, Maze.Direction.Up);
            Assert.Equal(Maze.Player2Char, maze.CellContent(3, 3));
        }

        [Fact]
        public void NumCoins()
        {
            Maze maze = new Maze($"   {Maze.Player2Char}\n    \n    \n{Maze.Player1Char}   ");
            Assert.Equal(0, maze.NumCoinsLeft);
            maze = new Maze($"   {Maze.Player2Char}\n{Maze.CoinChar}{Maze.CoinChar}{Maze.CoinChar}{Maze.CoinChar}\n    \n{Maze.Player1Char}   ");
            Assert.Equal(4, maze.NumCoinsLeft);
        }

        [Fact]
        public void MovePlayer1OverPlayer2()
        {
            Maze maze = new Maze($" {Maze.Player1Char}{Maze.Player2Char} ");

            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 0));
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 0));
            maze.MovePlayer(1, Maze.Direction.Right);
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 0));
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 0));
            maze.MovePlayer(2, Maze.Direction.Left);
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 0));
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 0));
        }

        [Fact]
        public void MovePlayersOverWall()
        {
            Maze maze = new Maze($" {Maze.WallChar}  \n {Maze.Player1Char}{Maze.WallChar} \n {Maze.WallChar}{Maze.Player2Char} \n  {Maze.WallChar} ");

            maze.MovePlayer(1, Maze.Direction.Right);
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 2));

            maze.MovePlayer(1, Maze.Direction.Up);
            Assert.Equal(Maze.Player1Char, maze.CellContent(1, 2));

            maze.MovePlayer(2, Maze.Direction.Left);
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 1));

            maze.MovePlayer(2, Maze.Direction.Left);
            Assert.Equal(Maze.Player2Char, maze.CellContent(2, 1));
        }
    }
}
