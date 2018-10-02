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
        public int MazeNumber { get; set; }

        public Tile First { get; set; }

        public Player Player { get; set; }

        public List<Crate> Crates { get; } = new List<Crate>();

        public int DestinationsAmount { get; set; }

        public void PrintField()
        {   
            Tile current = First;
            Tile firstTileLine = current;

            while(current != null)
            {
                if (current.Entity != null)
                {
                    current.Entity.Print();
                }
                else
                {
                    current.Print();
                }

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

        public void DestroyCrate(Crate crate)
        {
            Crates.Remove(crate);
        }

        public bool IsFinished()
        {
            if (DestinationsAmount > Crates.Count)
            {
                return false;
            }

            int finishedCount = 0;

            foreach (Crate crate in Crates)
            {
                if (crate.OnDestination)
                {
                    finishedCount++;
                }
            }

            return finishedCount == Crates.Count;
        }
    }
}
