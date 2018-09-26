using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Crates;
using Sokoban.Tiles;

namespace Sokoban.Players
{
    class PlayerModule
    {
        private Sokoban _sokoban;

        private CrateModule _crateModule;

        public PlayerModule(Sokoban sokoban)
        {
            this._crateModule = sokoban.CrateModule;
            this._sokoban = sokoban;
        }

        public void Move(Direction direction)
        {
            Maze maze = _sokoban.Maze;
            Player player = maze.Player;

            Tile nextTile = player.Tile.getTileInDirection(direction);
            Crate crate = maze.GetCrateOnTile(nextTile);

            if (crate != null && !_crateModule.Move(crate, direction))
            {
                return;
            }

            player.Move(direction);
        }
    }
}
