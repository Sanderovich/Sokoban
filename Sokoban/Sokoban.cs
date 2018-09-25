using Sokoban.Crates;
using Sokoban.Players;
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
        public Maze Maze { get; set; }
        public CrateModule CrateModule { get; set; }

        public Sokoban ()
        {
            CrateModule = new CrateModule(this);
        }

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

            Maze = parser.Parse(output);

            Maze.PrintField();

            while (!IsFinished())
            {
                ConsoleKeyInfo key = Console.ReadKey();


            }
        }

        public bool IsFinished()
        {
            return this.Maze.IsFinished();
        }
    }
}
