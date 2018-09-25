using Sokoban.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Sokoban
    {
        private Maze _maze;
        public void Start()
        {
            new StartView().PrintStart();

            String input = Console.ReadLine();
            int output = 0;
            Boolean finished = false;
            while (!finished)
            {
                if (!int.TryParse(input, out output))
                {
                    System.Console.WriteLine("?");
                    System.Console.WriteLine("> Choose a maze (1 - 4), s = stop");
                    input = Console.ReadLine();
                    continue;
                }

                finished = true;
            }


            Console.WriteLine($"START{ output }");

            SokobanParser parser = new SokobanParser();

            this._maze = parser.Parse(output);

            this._maze.PrintField();

            while (!IsFinished())
            {
                ConsoleKeyInfo key = Console.ReadKey();


            }
        }

        public bool IsFinished()
        {
            return this._maze.IsFinished();
        }
    }
}
