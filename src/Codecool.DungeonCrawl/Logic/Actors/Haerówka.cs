using Codecool.DungeonCrawl.Combat;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using System.Collections.Generic;
using Veldrid;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    public class Haerówka : Enemy, IUpdatable
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

        public Haerówka(Cell cell) : base(cell, TileSet.GetTile(TileType.Haerówka))
        {
            Program.UpdatablesToAdd.Add(this);
            var lootableItems = new Dictionary<Item, int>
            {
                { new Weapon("Stinger", 10, true, 10), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
            };
            var lootTable = new LootTable(lootableItems);

            speakList = new List<string> { "OH!, YES!!!, AHHH!!, SOFTSKILLS YEAH, SOFTSKILLS AAARGHH", "Every fall is chance to rise!", "Yes! Doing your job is part of your JOB!", "Hmm, I can smell your softskills" };

            _inventory = new Inventory(lootTable.RandomizeLoot());
            isAggressive = IsAggressive();

        }
    }
}