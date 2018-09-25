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
        private View _view;
        public void Start()
        {
            _view = new StartView();
            _view.Print(_maze);

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

            SokobanParser parser = new SokobanParser();

            this._maze = parser.Parse(output);

            this._view = new GameView();
            this._view.Print(_maze);

            while (!IsFinished())
            {
                checkMovement();

                this._view.Print(_maze);
            }
        }

        private void checkMovement()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.RightArrow)
            {
                _maze.Player.Move(Direction.EAST);
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                _maze.Player.Move(Direction.WEST);
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                _maze.Player.Move(Direction.SOUTH);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                _maze.Player.Move(Direction.NORTH);
            }
        }

        public bool IsFinished()
        {
            return this._maze.IsFinished();
        }
    }
}
