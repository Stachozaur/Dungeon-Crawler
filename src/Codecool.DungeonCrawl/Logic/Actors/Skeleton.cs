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


    public class Skeleton : Enemy, IPlayerAttributes, IUpdatable
    {
        public int _hp { get; private set; } = 20;
        public int _attack { get; private set; } = 5;
        public int _dexterity { get; private set; } = 0;
        public int _actionPoints { get; private set; } = 50;
        public int _magicResistance { get; private set; } = 0;
        public int _armor { get; private set; } = 5;
        public override bool isAggressive { get; set; }
        public override float timeLastMove { get; set; }
        public override List<string> speakList { get; set; }
        public override float timeLastSpeak { get; set; }
        public override float timeToRemoveSpeak { get; set; }

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

            speakList = new List<string> { "Praca, Praca" };

            _inventory = new Inventory(lootTable.RandomizeLoot());
            isAggressive = IsAggressive();

        }
    }
}