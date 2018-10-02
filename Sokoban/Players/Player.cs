using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Entity;
using Sokoban.Tiles;

namespace Sokoban.Players
{
    class Player : IMoveable
    {
        public char Character { get; } = '@';
        public Tile Tile { get; set; }

        public Player (Tile tile)
        {
            this.Tile = tile;
        }

        public void Move(Direction direction)
        {
            Tile tile = Tile.PushContent(direction);

            if (tile != null) Tile = tile;
        }

        public void Print()
        {
            Console.Write(Character);
        }

    }
}
