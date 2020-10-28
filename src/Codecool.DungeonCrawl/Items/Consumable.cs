using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    class Consumable : Item
    {
        private int _potionPower;
        private bool _isRestoringHP;
        public Consumable(string Name, int potionPower, bool isRestoringHP)
        {
            _name = Name;
            _potionPower = potionPower;
            _isRestoringHP = isRestoringHP;
            _value = potionPower / 10;
        }
    }
}
