using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using Codecool.DungeonCrawl;

namespace Codecool.DungeonCrawl.Combat
{
    public class CombatMode
    {
        private static List<Option> _options;

        static void Menu(string[] args)
        {
            _options = new List<Option>
            {
                new Option("Thing", () => WriteTemporaryMessage("Hi")),
                new Option("Another Thing", () =>  WriteTemporaryMessage("How Are You")),
                new Option("Yet Another Thing", () =>  WriteTemporaryMessage("Today")),
                new Option("Exit", () => Environment.Exit(0)),
            };
        }
        public void RunCombat()
        {

        }
    }
}