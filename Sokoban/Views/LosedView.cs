﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class LosedView:View
    {
        public override ConsoleKeyInfo Print(Maze maze)
        {
            Console.Clear();
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("| Sokoban  |");
            Console.WriteLine("└──────────┘");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            maze.PrintField();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("=== YOU LOST! Not enough crates to finish :( ===");
            Console.WriteLine("> Press any key to continue");

            return Console.ReadKey();
        }
    }
}
