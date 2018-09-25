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
            if (crate.Tile is Wall)
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

            crate.Move(direction);

            return true;
        }
    }
}
