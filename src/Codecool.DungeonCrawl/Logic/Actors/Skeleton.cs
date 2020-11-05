using System;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Codecool.DungeonCrawl.Items;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using SixLabors.ImageSharp.ColorSpaces;
using System.Runtime.ExceptionServices;
using SharpDX.Direct3D;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Sample enemy
    /// </summary>
    /// 


    public class Skeleton : Actor, IPlayerAttributes, IUpdatable

    {
        public int _hp { get; private set; } = 20;
        public int _attack { get; private set; } = 5;
        public int _dexterity { get; private set; } = 0;
        public int _actionPoints { get; private set; } = 50;
        public int _magicResistance { get; private set; } = 0;
        public int _armor { get; private set; } = 5;
        public bool isAggresive { get; private set; }

        private float _timeLastMove;

        public Skeleton(Cell cell) : base(cell, TileSet.GetTile(TileType.Skeleton))
        {
            Program.UpdatablesToAdd.Add(this);
            var lootableItems = new Dictionary<Item, int>
            {
                { new Weapon("Stinger", 10, true, 10), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
            };
            var lootTable = new LootTable(lootableItems);
            _inventory = new Inventory(lootTable.RandomizeLoot());
            bool isAgressive = true;

        }

        private bool IsAggressive()
        {
            return Program.Rnd.Next(100) % 2 == 0;
        }

        private bool AggressiveRunCheck(Player player)
        {
            int CriticalDistance = 5;
            var playerPosition = player.Position;
            var skeletonPosition = this.Position;
            (int x, int y) distance = GetVector(playerPosition, skeletonPosition);
            distance = (Math.Abs(distance.x), Math.Abs(distance.y));
            return distance.x <= CriticalDistance && distance.y == 0 || distance.y <= CriticalDistance && distance.x == 0;
        }

        private Direction ChargePlayerDirection(Player player)
        {
            (int x, int y) vector = GetVector(player.Position, this.Position);

            (int x, int y) normalize = (Math.Sign(vector.x), Math.Sign(vector.y));

            Direction targetDirection = normalize.ToDirection();
            return targetDirection;
        }

        private void ChargePlayer(Player player)
        {
            Direction dir = ChargePlayerDirection(player);
            TryMove(dir);
        }


        public Direction GetRandomDirection()
        {
            int maxDirection = 8;
            var direction = (Direction)Program.Rnd.Next(0, maxDirection);
            return direction;
        }

        public void RandomAiMove()
        {
            var direction = GetRandomDirection();
            TryMove(direction);
        }

        private void TryMove(Direction dir)
        {
            var targetCell = Cell.GetNeighbour(dir);
            var canPass = targetCell?.OnCollision(this) ?? false;
            var isActor = targetCell?.IsActor(this) ?? false;

            if (canPass && !isActor && !isAggresive)
            {
                AssignCell(targetCell);
            }
        }


        public (int x, int y) GetVector((int x, int y) position, (int x, int y)otherPosition)
        {                       
            (int x, int y) distance = ((position.x - otherPosition.x), (position.y - otherPosition.y));
            return distance;
        }

        public bool IsPlayerClose()
        {
            return false;
        }

        public void Update(float deltaTime)
        {
            _timeLastMove += deltaTime;
            if(_timeLastMove >= 0.3f)
            {
                if (!AggressiveRunCheck(Player.Singleton))
                {
                    _timeLastMove = 0;
                    RandomAiMove();
                }
                else
                {
                    _timeLastMove = 0;
                    ChargePlayer(Player.Singleton);
                }
            }
        }
    }
}