using Sokoban.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class PitFall:Tile
    {
        private int _hits;
        public int Hits
        {
            get
            {
                return this._hits;
            }

            set
            {   
                this._hits += value;
                if (this._hits == 3)
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

        public override void Update()
        {
            IncreaseHits();

            if (IsBroken && Entity is IPushable)
            {
                Entity = null;
            }
        }
    }
}
