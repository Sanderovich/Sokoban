using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Crates
{
    class CrateModule
    {
        private Sokoban _sokoban;

        public CrateModule(Sokoban sokoban)
        {
            this._sokoban = sokoban;
        }

        public bool Move(Crate crate, Direction direction)
        {
            Tile next = crate.Tile.getTileInDirection(direction);
            if (next is Wall)
            {
                return false;
            }

            foreach (Crate c in _sokoban.Maze.Crates)
            {
                if (c.Tile.Equals(crate.Tile.getTileInDirection(direction)))
                {
                    return false;
                }
            }

            if (next is PitFall)
            {
                PitFall pitFall = (PitFall)next;

                if (pitFall.IsBroken)
                {
                    _sokoban.Maze.DestroyCrate(crate);
                }
                else
                {
                    pitFall.IncreaseHits();
                }
            }

            crate.Move(direction);

            return true;
        }
    }
}
