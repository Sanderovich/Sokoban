using Sokoban.Entity;
using Sokoban.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Enums;

namespace Sokoban.Tiles
{
    abstract class Tile
    {
        public Tile North { get; set; }
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public char Character { get; set; }
        private IEntity _entity;
        public IEntity Entity
        {
            get
            {
                return this._entity;
            }

            set
            {
                this._entity = value;
                if (value != null)
                {
                    Update();
                }
            }
        }

        public Tile PushContent(Directions direction)
        {
            Tile tile = getTileInDirection(direction);

            if (!tile.IsMoveableTile()) return null;

            if (!tile.IsOccupied())
            {
                tile.Entity = Entity;
                Entity = null;
                return tile;
            }

            if (tile.IsEntityNotPushable())
            {
                INotPushable entity = (INotPushable) tile.Entity;

                entity.Update();
                return null;
            } 
            else if (tile.IsEntityAPlayer())
            {
                Player player = (Player)tile.Entity;

                Tile newTile = tile.PushContent(direction);
                if (newTile == null) return null;

                player.Tile = newTile;

                tile.Entity = Entity;
                Entity = null;
                return tile;
            }
            else if (tile.IsEntityPushable())
            {
                IPushable entity = (IPushable) tile.Entity;

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

        private bool IsEntityNotPushable()
        {
            return Entity is INotPushable;
        }

        private bool IsEntityAPlayer()
        {
            return Entity is Player;
        }

        private bool IsEntityPushable()
        {
            return Entity is IPushable;
        }

        private bool IsOccupied()
        {
            return Entity != null;
        }
                                    
        private Tile getTileInDirection(Directions direction)
        {
            switch(direction)
            {
                case Directions.NORTH:
                    return North;
                case Directions.EAST:
                    return East;
                case Directions.SOUTH:
                    return South;
                case Directions.WEST:
                    return West;
                default:
                    return null;
            }
        }

        public void Print()
        {
            Console.Write(Character);
        }

        public abstract void Update();
    }
}
