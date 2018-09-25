using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Players
{
    class Player
    {

        public Tile Place { get; set; }

        public Player (Tile place)
        {
            Place = place;
        }

    }
}
