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
            Tile current = First;
            Tile firstTileLine = current;

            while(current != null)
            {
                current.Print();

                if (current.East == null)
                {
                    Console.WriteLine("");
                    current = firstTileLine.South;
                    firstTileLine = current;
                }
                else
                {
                    current = current.East;
                }
            }
        }

        public bool IsFinished()
        {
            int finishedCount = 0;

            foreach (Crate crate in Crates)
            {
                if (crate.Tile is Destination)
                {
                    finishedCount++;
                }
            }

            return finishedCount == Crates.Count;
        }
    }
}
