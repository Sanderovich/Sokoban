using Sokoban.Entity;
using Sokoban.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Players
{
    class Worker : IMoveable
    {
        
        public char Character { get; } = '$';
        public char SleepingCharacter { get; } = 'Z';
        public Tile Tile { get; set; }

        public bool Sleeping { get; set; }

        private Random Random = new Random();

        public Worker(Tile tile)
        {
            Tile = tile;
        }

        public bool Move(Direction direction)
        {
            int percentage = Random.Next(0, 101);

            if (percentage <= 10 && Sleeping) Sleeping = !Sleeping;
            else if (percentage <= 25 && !Sleeping) Sleeping = !Sleeping;
            
            if (!Sleeping)
            {
                int intDirection = Random.Next(1, 5);
                Direction finalDirection = Direction.NORTH;

                switch (intDirection)
                {
                    case 1:
                        finalDirection = Direction.NORTH;
                        break;
                    case 2:
                        finalDirection = Direction.EAST;
                        break;
                    case 3:
                        finalDirection = Direction.SOUTH;
                        break;
                    case 4:
                        finalDirection = Direction.WEST;
                        break;
                    default:
                        break;
                }

                Tile tile = Tile.PushContent(finalDirection);

                if (tile != null)
                {
                    Tile = tile;
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            if (Sleeping) Console.Write(SleepingCharacter);
            else Console.Write(Character);
        }
    }
}
