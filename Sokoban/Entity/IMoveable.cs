﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Entity
{
    interface IMoveable : IEntity
    {

        void Move(Direction direction);
    }
}
