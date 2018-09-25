using Sokoban.Crates;
using Sokoban.Tiles;
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
        private View _view;

        //public PlayerModule PlayerModule { get; set; }
        public CrateModule CrateModule { get; set; }
        public Sokoban()
        {
            //PlayerModule = new PlayerModule(this);
            CrateModule = new CrateModule(this);
        }

        public void Start()
        {
            _view = new StartView();
            _view.Print(Maze);

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

            this.Maze = parser.Parse(output);

            this._view = new GameView();
            this._view.Print(Maze);

            while (!IsFinished())
            {
                checkMovement();

                this._view.Print(Maze);
            }

            _view = new EndView();
            _view.Print(Maze);

            Console.ReadKey();
        }

        private void checkMovement()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.RightArrow)
            {
                Tile tile = Maze.Player.Place.East;

                bool canMove = true;
                foreach (Crate crate in Maze.Crates)
                {
                    if (tile.Equals(crate.Tile))
                    {
                        canMove = CrateModule.Move(crate, Direction.EAST);
                    }
                }

                if (canMove) Maze.Player.Move(Direction.EAST);
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Tile tile = Maze.Player.Place.West;

                bool canMove = true;
                foreach (Crate crate in Maze.Crates)
                {
                    if (tile.Equals(crate.Tile))
                    {
                        canMove = CrateModule.Move(crate, Direction.WEST);
                    }
                }

                if (canMove) Maze.Player.Move(Direction.WEST);
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                Tile tile = Maze.Player.Place.South;

                bool canMove = true;
                foreach (Crate crate in Maze.Crates)
                {
                    if (tile.Equals(crate.Tile))
                    {
                        canMove = CrateModule.Move(crate, Direction.SOUTH);
                    }
                }

                if (canMove) Maze.Player.Move(Direction.SOUTH);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                Tile tile = Maze.Player.Place.North;

                bool canMove = true;
                foreach (Crate crate in Maze.Crates)
                {
                    if (tile.Equals(crate.Tile))
                    {
                        canMove = CrateModule.Move(crate, Direction.NORTH);
                    }
                }

                if (canMove) Maze.Player.Move(Direction.NORTH);
            }
        }

        public bool IsFinished()
        {
            return this.Maze.IsFinished();
        }
    }
}
