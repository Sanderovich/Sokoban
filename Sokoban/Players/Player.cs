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

        public void Move(Direction direction)
        {
            if (direction.Equals(Direction.NORTH)) {
                if (Place.North is Wall) return;

                Place = Place.North;
            } else if (direction.Equals(Direction.EAST)) {
                if (Place.East is Wall) return;

                Place = Place.East;
            } else if (direction.Equals(Direction.SOUTH)) {
                if (Place.South is Wall) return;

                Place = Place.South;
            } else if (direction.Equals(Direction.WEST)) {
                if (Place.West is Wall) return;

                Place = Place.West;
            }
        }

    }
}
