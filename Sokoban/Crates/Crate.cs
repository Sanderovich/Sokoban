using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Tiles;

namespace Sokoban.Crates
{
    class Crate
    {
        public char Character { get; } = 'O';
        public char CharacterOnDestination{ get; } = '0';
        public bool OnDestination { get; set; } = false;
        public Tile Tile { get; set; }

        public Crate(Tile tile)
        {
            this.Tile = tile;
        }
        public void Move(Direction direction)
        {
            Tile = Tile.getTileInDirection(direction);

            if (Tile is Destination)
            {
                OnDestination = true;
            } 
            else
            {
                OnDestination = false;
            }
        }

        public void Print()
        {
            Console.Write(Character);
        }

        public void PrintOnPlace()
        {
            Console.Write(CharacterOnDestination);
        }
    }
}
