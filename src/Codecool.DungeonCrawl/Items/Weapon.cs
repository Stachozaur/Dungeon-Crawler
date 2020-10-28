using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Items
{
    class Weapon : Item
    {
        private int _attack;

        private bool _isMagic;
        
        public Weapon(string name, int attack, bool isMagic)
        {
            _name = name;
            _attack = attack;
            _isMagic = isMagic;
            _value = _attack * 10;
        }
    }
}
