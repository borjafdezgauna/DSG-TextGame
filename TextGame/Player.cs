using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public class Player
    {
        public int Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Coins { get; private set; } = 0;

        public Player(int id)
        {
            Id = id;
        }

        public void AddCoin()
        {
            Coins++;
        }
    }
}
