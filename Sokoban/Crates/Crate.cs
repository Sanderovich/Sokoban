using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Crates
{
    class Crate
    {
        public Tile Tile { get; set; }

        public Crate(Tile tile)
        {
            this.Tile = tile;
        }
    }
}
