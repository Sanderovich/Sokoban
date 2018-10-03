using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class Destination:Tile
    {
        public Destination()
        {
            this.Character = 'x';
        }

        public override void Update() { }
    }
}
