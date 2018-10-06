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
        
        private readonly SokobanParser _parser;

        public Sokoban()
        {
            _parser = new SokobanParser();

            _startView = new StartView();
            _gameView = new GameView();
            _endView = new EndView();
        }

        public void Start()
        {
            _startView.Print(Maze);

            ConsoleKeyInfo input = Console.ReadKey();
            int output;

            Boolean finished = false;

            while (!finished)
            {
                if (input.Key == ConsoleKey.S)
                {
                    Environment.Exit(0);
                    return;
                }


                if (!int.TryParse(input.KeyChar + "", out output))
                {
                    _startView.PrintError();
                    input = Console.ReadKey();
                    continue;
                }

                this.Maze = this._parser.Parse(output);
                if (this.Maze == null)
                {
                    _startView.PrintError();
                    input = Console.ReadKey();
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
                CheckInput();

                this._gameView.Print(Maze);
            }

            Finish();
        }

        private void Finish()
        {
            this._endView.Print(Maze);

            Console.ReadKey();

            this.Maze = null;

            Start();
        }

        private void CheckInput()
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
                if (Maze.Player.Move(Direction.EAST))
                {
                    if (Maze.Worker != null) Maze.Worker.Move(Direction.EAST);
                }
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (Maze.Player.Move(Direction.WEST))
                {
                    if (Maze.Worker != null) Maze.Worker.Move(Direction.WEST);
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            { 
                if (Maze.Player.Move(Direction.SOUTH))
                {
                    if (Maze.Worker != null) Maze.Worker.Move(Direction.SOUTH);
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (Maze.Player.Move(Direction.NORTH))
                {
                    if (Maze.Worker != null) Maze.Worker.Move(Direction.NORTH);
                }
            }
        }

        public bool IsFinished()
        {
            return this.Maze.IsFinished();
        }
    }
}
