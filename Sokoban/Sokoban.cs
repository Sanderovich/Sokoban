using Sokoban.Crates;
using Sokoban.Players;
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

        private StartView _startView;
        private GameView _gameView;
        private EndView _endView;

        public PlayerModule PlayerModule { get; set; }
        public CrateModule CrateModule { get; set; }
        private SokobanParser _parser;

        public Sokoban()
        {
            PlayerModule = new PlayerModule(this);
            CrateModule = new CrateModule(this);
            _parser = new SokobanParser();

            _startView = new StartView();
            _gameView = new GameView();
            _endView = new EndView();
        }

        public void Start()
        {
            _startView.Print(Maze);

            String input = Console.ReadLine();
            int output = 0;

            Boolean finished = false;

            while (!finished)
            {
                if (input == "s")
                {
                    Environment.Exit(0);
                    return;
                }

                if (!int.TryParse(input, out output))
                {
                    _startView.PrintError();
                    input = Console.ReadLine();
                    continue;
                }

                this.Maze = this._parser.Parse(output);
                if (this.Maze == null)
                {
                    _startView.PrintError();
                    input = Console.ReadLine();
                    continue;
                }

                finished = true;
            }

            Play();
        }

        private void Play() {
            this._gameView.Print(Maze);

            while (!IsFinished())
            {
                CheckMovement();

                this._gameView.Print(Maze);
            }

            Finish();
        }

        private void Finish()
        {
            this._endView.Print(Maze);

            Console.ReadKey();

            Start();
        }

        private void CheckMovement()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.R)
            {
                this.Maze = this._parser.Parse(this.Maze.MazeNumber);
                Play();
                return;
            }

            if (key.Key == ConsoleKey.S)
            {
                Start();
                return;
            }

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
