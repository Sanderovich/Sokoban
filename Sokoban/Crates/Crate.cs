using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Crates
{
    class Crate
    {
        public Tile Tile { get; set; }

        public Crate(Tile tile)
        {
            this.Tile = tile;
        }
        public void Move(Direction direction)
        {
            if (direction.Equals(Direction.NORTH))
            {
                Tile = Tile.North;
            }
            else if (direction.Equals(Direction.EAST))
            {
                Tile = Tile.East;
            }
            else if (direction.Equals(Direction.SOUTH))
            {
                Tile = Tile.South;
            }
            else if (direction.Equals(Direction.WEST))
            {
                Tile = Tile.West;
            }
        }
    }
}
