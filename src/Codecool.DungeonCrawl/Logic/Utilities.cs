using Codecool.DungeonCrawl.Items;
using System;

namespace Codecool.DungeonCrawl.Logic
{
    public static class Utilities
    {
        public static (int x, int y) ToVector(this Direction dir) => dir switch
        {
            Direction.Up => (0, -1),
            Direction.Down => (0, 1),
            Direction.Left => (-1, 0),
            Direction.Right => (1, 0),
            Direction.UpperLeft => (-1, -1),
            Direction.UpperRight => (1, -1),
            Direction.BottomLeft => (-1, 1),
            Direction.BottomRight => (1, 1),
            _ => throw new NotImplementedException(),
        };

        public static Direction ToDirection(this (int x, int y) vector) => vector switch
        {
            (0, -1) => Direction.Up,
            (0, 1) => Direction.Down,
            (-1, 0) => Direction.Left,
            (1, 0) => Direction.Right,
            (-1, -1) => Direction.UpperLeft,
            (1, -1) => Direction.UpperRight,
            (-1, 1) => Direction.BottomLeft,
            (1, 1) => Direction.BottomRight,
            _ => throw new NotImplementedException(),
        };

        public static bool IsPassable(this TileType tile) => tile switch
        {
            TileType.Empty => true,
            TileType.Floor => true,
            TileType.Wall => false,
            TileType.DoorBlue => false,
            TileType.DoorRed => false,
            TileType.DoorYellow => false,
            _ => true
        };

        public static string RandomItemName(string itemName)
        {
            var randomPrefix = (RandomNames) Program.Rnd.Next(Enum.GetNames(typeof(RandomNames)).Length);
            var fullString = $"{randomPrefix} {itemName}";
            return fullString;
        }

        public static string GetLastWord(string name)
        {
            var words = name.Split(' ');
            return words[words.Length - 1];
        }
    }
}