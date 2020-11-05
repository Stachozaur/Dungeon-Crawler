using Codecool.DungeonCrawl.Logic.Actors;
using System.Collections.Generic;

namespace Codecool.DungeonCrawl.Items
{
    public partial class Inventory
    {
        private Dictionary<Item, int> _inventory;

        public Inventory(Dictionary<Item, int> startingItems)
        {
            _inventory = startingItems;
        }

        public Dictionary<Item, int> GetInventory()
        {
            return _inventory;
        }

        public void AddLootToInventory(Dictionary<Item, int> lootedItems)
        {
            var inventoryCopy = new Dictionary<Item, int>(_inventory);

            foreach (var item in lootedItems)
            {
                var matchFound = false;
                foreach (var inventoryItem in inventoryCopy)
                {
                    if (item.Key.GetItemName() == inventoryItem.Key.GetItemName())
                    {
                        _inventory[inventoryItem.Key] += item.Value;
                        matchFound = true;
                        break;
                    }
                }
                if (!matchFound)
                {
                    _inventory.Add(item.Key, item.Value);
                }
            }
        }

        public void AddSingleItemToInventory(Item item)
        {
            _inventory.Add(item, 1);
        }

        public void RemoveItemFromInventory(Item item)
        {
            _inventory.Remove(item);
        }
    }
}
