using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Combat
{
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}
