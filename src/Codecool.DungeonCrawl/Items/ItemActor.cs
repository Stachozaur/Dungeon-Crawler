using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Logic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    class ItemActor: Actor
    {
        public ItemActor(Cell cell, Item item) : base(cell, TileSet.GetTile(item.type))
        {
            var startingItems = new Dictionary<Item, int>
            {
                {item, 1 }
            };
            _inventory = new Inventory(startingItems);
        }

    }
}
