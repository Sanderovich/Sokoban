using Sokoban.Crates;
using Sokoban.Entity;
using Sokoban.Enums;
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

        private Sokoban Sokoban { get; set; }

        public PitFall(Sokoban sokoban)
        {
            Character = '~';

            Sokoban = sokoban;
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
                Entity.Tile = null;
                Entity = null;

                Sokoban.State = GameStates.Lost;
            }
        }
    }
}
