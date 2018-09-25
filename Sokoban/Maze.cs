using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;
using Sokoban.Players;
using Sokoban.Crates;

namespace Sokoban
{
    class Maze
    {
        public Tile First { get; set; }

        public Player Player { get; set; }

        public List<Crate> Crates { get; } = new List<Crate>();


        public void PrintField()
        {
            int dir = 1;
            Tile current = First;

            while(current != null)
            {
                current.Print();

                if (dir == 1 && current.East == null)
                {
                    current = current.South;
                    dir = -1;
                    Console.WriteLine("");
                }
                else if (dir == 1)
                {
                    current = current.East;
                }
                else if (dir == -1 && current.West == null)
                {
                    current = current.South;
                    dir = 1;
                    Console.WriteLine("");
                }
                else if (dir == -1)
                {
                    current = current.West;
                }
            }
        }
    }
}
