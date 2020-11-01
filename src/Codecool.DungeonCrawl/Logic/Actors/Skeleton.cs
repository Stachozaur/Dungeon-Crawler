using System;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Codecool.DungeonCrawl.Items;
using System.Collections.Generic;

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
        }
    }
}