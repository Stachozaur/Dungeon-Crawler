using System;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Codecool.DungeonCrawl.Items;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Sample enemy
    /// </summary>
    /// 


    public class Skeleton : Actor, IPlayerAttributes
    {
        public int _hp { get; private set; } = 20;
        public int _attack { get; private set; } = 5;
        public int _dexterity { get; private set; } = 0;
        public int _actionPoints { get; private set; } = 50;
        public int _magicResistance { get; private set; } = 0;
        public int _armor { get; private set; } = 5;
        private static readonly Random _random = new Random();
        private float _timeLastMove;

        public Skeleton(Cell cell) : base(cell, TileSet.GetTile(TileType.Skeleton))
        {
            var lootableItems = new Dictionary<Item, int>
            {
                { new Weapon("Stinger", 10, true, 10), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
            };
            var lootTable = new LootTable(lootableItems);
            _inventory = new Inventory(lootTable.RandomizeLoot());
            bool agressive = IsAggressive();
            RandomAiMove();

        }

        private bool IsAggressive()
        {
            return Program.Rnd.Next(100) % 2 == 0;
        }

        private bool AggressiveRunStart(Player player)
        {
            int CriticalDistance = 3;
            (int x, int y) distance = GetDistanceToPlayer(player);
            return distance.x <= CriticalDistance || distance.y <= CriticalDistance;
        }

        public Direction GetRandomDirection()
        {
            int maxDirection = 3;
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

            if (canPass)
            {
                AssignCell(targetCell);
            }
        }

        public (int x, int y) GetStartPosition()
        {
            return (this.Position.x, this.Position.y);
        }

        public (int x, int y) GetDistanceToPlayer(Player player)
        {
            (int x, int y) distance = (Math.Abs(this.Position.x - player.Position.x), Math.Abs(this.Position.y - player.Position.y));
            return distance;
        }

        public bool IsPlayerClose()
        {
            return false;
        }

    }
}