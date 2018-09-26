using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    abstract class Tile
    {
        public Tile North { get; set; }
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public char Character { get; set; }
        public Tile getTileInDirection(Direction direction)
        {
            if (direction.Equals(Direction.NORTH))
            {
                return North;
            }
            else if (direction.Equals(Direction.EAST))
            {
                return East;
            }
            else if (direction.Equals(Direction.SOUTH))
            {
                return South;
            }
            else if (direction.Equals(Direction.WEST))
            {
                return West;
            }

            return null;
        }
        public void Print()
        {
            Console.Write(Character);
        }
    }
}
