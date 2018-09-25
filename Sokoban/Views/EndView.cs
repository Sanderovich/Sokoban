using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class EndView : View
    {
        public override void Print(Maze _maze)
        {
            Console.Clear();
            Console.WriteLine("FINISHED");
            Console.WriteLine("Press any key to quit");
        }
    }
}
