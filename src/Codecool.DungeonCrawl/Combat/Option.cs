using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Combat
{
    public class Option
    {
        private string _name;
        public Option(string name)
        {
            _name = name;

        }

        public string GetAbilityName()
        {
            return _name;
        }
    }
}
