using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{

    enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Sokoban().Start();
        }
    }
}
