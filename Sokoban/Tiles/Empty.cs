using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class Empty:Tile
    {
        public Empty()
        {
            this.Character = ' ';
        }

        public override void Update() { }
    }
}
