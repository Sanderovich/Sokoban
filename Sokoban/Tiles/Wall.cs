using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    class Wall:Tile
    {
        public Wall()
        {
            this.Character = '█';
        }

        public override void Update() { }
    }
}
