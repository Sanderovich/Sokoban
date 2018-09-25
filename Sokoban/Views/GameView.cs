using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class GameView : View
    {
        public override void Print(Maze _maze)
        {
            Console.Clear();
            _maze.PrintField();
        }
    }
}
