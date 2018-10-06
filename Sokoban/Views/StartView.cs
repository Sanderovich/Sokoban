using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Views
{
    class StartView:View
    {
        public override void Print(Maze maze)
        {
            Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("| Welcome at Sokoban                                           |");
            System.Console.WriteLine("|                                                              |");
            System.Console.WriteLine("| Meaning of the symbols in-game   |  Goal of the game         |");
            System.Console.WriteLine("|                                  |                           |");
            System.Console.WriteLine("| spacebar : outerspace            |  Push the crate(s)        |");
            System.Console.WriteLine("|        █ : Wall                  |  to the destination place |");
            System.Console.WriteLine("|        · : Floor                 |  with the truck           |");
            System.Console.WriteLine("|        O : Crate                 |                           |");
            System.Console.WriteLine("|        0 : Crate on destination  |                           |");
            System.Console.WriteLine("|        x : Destination           |                           |");
            System.Console.WriteLine("|        @ : Truck                 |                           |");
            System.Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("> Choose a maze (1 - 6), s = stop");
        }

        public void PrintError()
        {
            System.Console.WriteLine("?");
            System.Console.WriteLine("> Choose a maze (1 - 6), s = stop");
        }
    }
}
