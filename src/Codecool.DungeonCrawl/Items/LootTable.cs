using System;
using System.Collections.Generic;

namespace Codecool.DungeonCrawl.Items
{
    public class LootTable
    {
        private Dictionary<Item, int> _lootTable;
        public LootTable(Dictionary<Item, int> lootableItems)
        {
            _lootTable = lootableItems;
        }

        public Dictionary<Item, int> RandomizeLoot()
        {
            Random random = new Random();
            var randomizedLoot = new Dictionary<Item, int>();
            foreach (var item in _lootTable)
            {
                var roll = random.Next(0, 100);
                if (roll <= item.Key.GetDroprate())
                {
                    randomizedLoot.Add(item.Key, item.Value);
                }
            }
            return randomizedLoot;
        }
    }
}
