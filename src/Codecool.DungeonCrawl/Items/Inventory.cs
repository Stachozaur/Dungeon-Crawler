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
            //foreach (var item in lootedItems)
            //{
            //    if (_inventory.ContainsKey(item.Key))
            //    {
            //        _inventory[item.Key] += 1;
            //    }
            //}
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
    }
}
