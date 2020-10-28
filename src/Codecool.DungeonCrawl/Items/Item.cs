using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl
{
    public abstract class Item
    {
        protected string _name { get; set; }
        
        protected int _value { get; set; }
    }
}
