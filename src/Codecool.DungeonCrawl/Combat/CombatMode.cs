using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using Codecool.DungeonCrawl;
using Codecool.DungeonCrawl.Logic.Actors;

namespace Codecool.DungeonCrawl.Combat
{
    public class CombatMode
    {
        private static List<Option> _options;
        private Player _player;

        public CombatMode(Player player, Actor other)
        {
            _player = player;
        }


        static void Menu()
        {


        }
        public void RunCombat()
        {
            ConsoleHelper.FightChoiceMenu(true, _player.CombatOptions());

        }
    }
}