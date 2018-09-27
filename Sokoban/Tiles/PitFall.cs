using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class PitFall:Tile
    {
        public int Hits
        {
            get
            {
                return Hits;
            }

            set
            {
                Hits = value;

                if (Hits == 3)
                {
                    Character = ' ';
                    IsBroken = true;
                }
            }
        }

        public bool IsBroken { get; set; }
        public PitFall()
        {
            Character = '~';
        }

        public void IncreaseHits()
        {
            Hits += 2;
        }
    }
}
