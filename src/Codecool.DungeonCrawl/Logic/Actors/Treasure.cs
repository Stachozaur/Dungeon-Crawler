using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Logic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    public class Treasure : Actor 
    {
        public Treasure(Cell cell) : base(cell, TileSet.GetTile(TileType.Treasure))
        {
            var lootableItems = new Dictionary<Item, int>
            {
                { new Consumable("Healing Potion", 10, true, 100), 20 },
                { new Consumable("Mana Potion", 10, false, 100), 20 },
            };
            var lootTable = new LootTable(lootableItems);
            _inventory = new Inventory(lootTable.RandomizeLoot());
        }
    }
}
