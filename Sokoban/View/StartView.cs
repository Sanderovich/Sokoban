using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    class StartView:View
    {

        public void PrintStart()
        {
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("| Welcome at Sokoban                                           |");
            System.Console.WriteLine("|                                                              |");
            System.Console.WriteLine("| Meaning of the symbals in-game   |  Goal of the game         |");
            System.Console.WriteLine("|                                  |                           |");
            System.Console.WriteLine("| spacebar : outerspace            |  Push the crate(s)        |");
            System.Console.WriteLine("|        █ : wall                  |  to the destination place |");
            System.Console.WriteLine("|        · : floor                 |  with the truck           |");
            System.Console.WriteLine("|        O : Crate                 |                           |");
            System.Console.WriteLine("|        0 : krat op bestemming    |                           |");
            System.Console.WriteLine("|        x : destination           |                           |");
            System.Console.WriteLine("|        @ : truck                 |                           |");
            System.Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("> Choose a maze (1 - 4), s = stop");
        }


    }
}
