using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    public class DoorKey : Item
    {
        private DoorKeyType _keyType;

        public DoorKey(DoorKeyType keyType)
        {
            _name = $"{keyType} Key";
            _value = 0;
            _droprate = 10;
        }

        public DoorKeyType GetKeyType()
        {
            return _keyType;
        }
    }
}
