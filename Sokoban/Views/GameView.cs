using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class GameView : View
    {
        public override ConsoleKeyInfo Print(Maze maze)
        {
            //Console.Clear();
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("| Sokoban  |");
            Console.WriteLine("└──────────┘");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            maze.PrintField();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");

            return Console.ReadKey();
        }
    }
}
