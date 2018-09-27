using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Players
{
    class Player
    {
        public char Character { get; } = '@';
        public Tile Tile { get; set; }

        public Player (Tile tile)
        {
            this.Tile = tile;
        }

        public void Move(Direction direction)
        {
            Tile temp = Tile.getTileInDirection(direction);

            if (temp is Wall) return;

            if (temp is PitFall)
            {
                PitFall pitFall = (PitFall)temp;
                pitFall.IncreaseHits();
            }

            Tile = temp;
        }

        public void Print()
        {
            Console.Write(Character);
        }

    }
}
