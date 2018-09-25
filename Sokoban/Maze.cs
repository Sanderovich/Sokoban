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

            String line = "";

            while(current != null)
            { 
                //current.Print();

                if (dir == 1 && current.East == null)
                {
                    current = current.South;
                    dir = -1;
                    Console.WriteLine(line);
                    if (current != null) line = current.Character + "";
                }
                else if (dir == 1)
                {
                    current = current.East;
                    line += current.Character;
                }
                else if (dir == -1 && current.West == null)
                {
                    current = current.South;
                    dir = 1;
                    Console.WriteLine(line);
                    if (current != null) line = current.Character + "";
                }
                else if (dir == -1)
                {
                    current = current.West;
                    line = current.Character + line;
                }
            }
        }
    }
}
