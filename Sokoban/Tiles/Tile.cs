using Sokoban.Entity;
using Sokoban.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Tiles
{
    abstract class Tile
    {
        public Tile North { get; set; }
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public char Character { get; set; }
        public IEntity Entity { get; set; }

        public Tile PushContent(Direction direction)
        {
            Tile tile = getTileInDirection(direction);

            if (!tile.IsMoveableTile()) return null;

            if (!tile.IsOccupied())
            {
                tile.Entity = Entity;
                Entity = null;
                return tile;
            }

            if (tile.IsEntityPushable())
            {
                IPushable entity = (IPushable)tile.Entity;

                if (IsEntityPushable()) return null;
                if (tile.PushContent(direction) == null) return null;

                entity.Update(tile.getTileInDirection(direction));

                tile.Entity = Entity;
                Entity = null;
                return tile;
            }
            
            return null;
        }

        private bool IsMoveableTile()
        {
            return !(this is Wall);
        }

        private bool IsEntityPushable()
        {
            return Entity is IPushable;
        }

        private bool IsOccupied()
        {
            return Entity != null;
        }
                                    
        private Tile getTileInDirection(Direction direction)
        {
            switch(direction)
            {
                case Direction.NORTH:
                    return North;
                case Direction.EAST:
                    return East;
                case Direction.SOUTH:
                    return South;
                case Direction.WEST:
                    return West;
                default:
                    return null;
            }
        }

        public void Print()
        {
            Console.Write(Character);
        }
    }
}
