using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Interfaces
{
    public interface IPlayerAttributes
    {
        int _hp { get; }

        int _attack { get; }

        int _dexterity { get; }

        int _actionPoints { get; }

        int _magicResistance { get; }

        int _armor { get; }
    }
}
