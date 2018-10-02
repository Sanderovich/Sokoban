using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Entity;
using Sokoban.Tiles;

namespace Sokoban.Crates
{
    class Crate : IPushable
    {
        public char Character { get; } = 'O';
        public char CharacterOnDestination{ get; } = '0';
        public bool OnDestination { get; set; } = false;
        public Tile Tile { get; set; }

        public Crate(Tile tile)
        {
            this.Tile = tile;
        }

        public void Print()
        {
            if (OnDestination)
            {
                Console.Write(CharacterOnDestination);
                return;
            }

            Console.Write(Character);
        }

        public void Update(Tile tile)
        {
            Tile = tile;

            if (tile is Destination)
            {
                OnDestination = true;
            } else
            {
                OnDestination = false;
            }
        }
    }
}
