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
        public void Print()
        {
            Console.Write(Character);
        }
    }
}
