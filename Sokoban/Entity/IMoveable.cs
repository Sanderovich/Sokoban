using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Enums;

namespace Sokoban.Entity
{
    interface IMoveable : IEntity
    {

        void Move(Direction direction);
    }
}
