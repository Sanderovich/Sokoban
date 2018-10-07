using Sokoban.Crates;
using Sokoban.Enums;
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

        public GameStates State { get; set; }

        private StartView _startView;
        private GameView _gameView;
        private FinishedView _finishedView;
        private LosedView _losedView;

        private readonly SokobanParser _parser;

        public Sokoban()
        {
            _parser = new SokobanParser();

            _startView = new StartView();
            _gameView = new GameView();
            _finishedView = new FinishedView();
            _losedView = new LosedView();

            State = GameStates.Menu;
        }

        public void Start()
        {
            State = GameStates.Menu;

            ConsoleKeyInfo input = _startView.Print(Maze);
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
                    input = _startView.PrintError();
                    continue;
                }

                this.Maze = this._parser.Parse(this, output);
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

        private void Play()
        {
            State = GameStates.Playing;

            while (State == GameStates.Playing)
            {
                CheckInput(this._gameView.Print(Maze));
                IsFinished();
            }

            End();
        }

        private void End()
        {
            if (State == GameStates.Finished)
            {
                Console.ReadKey(); _finishedView.Print(Maze);
            }
            else if (State == GameStates.Lost)
            {
                _losedView.Print(Maze);
            }

            this.Maze = null;

            Start();
        }

        private void CheckInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.R:
                    this.Maze = this._parser.Parse(this, this.Maze.MazeNumber);
                    Play();
                    break;
                case ConsoleKey.S:
                    Start();
                    break;
                case ConsoleKey.RightArrow:
                    if (Maze.Player.Move(Directions.EAST)) if (Maze.Worker != null) Maze.Worker.Move(Directions.EAST);
                    break;
                case ConsoleKey.LeftArrow:
                    if (Maze.Player.Move(Directions.WEST)) if (Maze.Worker != null) Maze.Worker.Move(Directions.WEST);
                    break;
                case ConsoleKey.DownArrow:
                    if (Maze.Player.Move(Directions.SOUTH)) if (Maze.Worker != null) Maze.Worker.Move(Directions.SOUTH);
                    break;
                case ConsoleKey.UpArrow:
                    if (Maze.Player.Move(Directions.NORTH)) if (Maze.Worker != null) Maze.Worker.Move(Directions.NORTH);
                    break;
            }
        }

        public void IsFinished()
        {
            if (Maze.IsFinished()) State = GameStates.Finished;
        }
    }
}
