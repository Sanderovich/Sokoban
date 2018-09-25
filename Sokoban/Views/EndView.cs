using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class EndView : View
    {
        public override void Print(Maze maze)
        {
            Console.Clear();
            Console.WriteLine("=== HURRAY! YOU COMPLETED LEVEL ===");
            Console.WriteLine("> Press any key to continue");
        }
    }
}
