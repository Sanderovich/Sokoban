using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class PitFall:Tile
    {
        private int hits;
        public int Hits
        {
            get
            {
                return this.hits;
            }

            set
            {
                this.hits += value;
                if (this.hits == 3)
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
            this.Hits = 1;
        }
    }
}
