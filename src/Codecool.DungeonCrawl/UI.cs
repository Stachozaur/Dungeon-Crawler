using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl
{
    public static class UI
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayInventory(Dictionary<Item, int> inventory)
        {
            foreach ((Item key, int count) in inventory)
            {
                Console.WriteLine($"{key}: {count}");
            }
            Console.WriteLine("\n");
        }


    }


}
