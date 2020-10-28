using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    class Armor : Item
    {
        private int _armor;

        private int _magicResistance;

        public Armor(string name, int armor, int magicResistance )
        {
            _name = name;
            _armor = armor;
            _magicResistance = magicResistance;
            _value = (_magicResistance + _armor) * 4;
        }
    }
}
