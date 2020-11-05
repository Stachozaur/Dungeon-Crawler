using System.IO;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Actors;
using Perlin.Display;
using Codecool.DungeonCrawl.Logic.Doors;
using Codecool.DungeonCrawl;
using System;

namespace Codecool.DungeonCrawl.Logic.Map
{
    /// <summary>
    ///     Helper class to load the map from the disk
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Returns map's dimensions
        /// </summary>
        /// <returns></returns>
        public static (int width, int height) GetMapDimensions()
        {
            var lines = File.ReadAllLines("map.txt");
            var dimensions = lines[0].Split(" ");
            var width = int.Parse(dimensions[0]);
            var height = int.Parse(dimensions[1]);

            return (width, height);
        }

        /// <summary>
        ///     Loads and returns the GameMap
        /// </summary>
        /// <param name="cellParent"></param>
        /// <returns></returns>
        public static GameMap LoadMap(DisplayObject cellParent)
        {
            var lines = File.ReadAllLines("map.txt");
            var dimensions = lines[0].Split(" ");
            var width = int.Parse(dimensions[0]);
            var height = int.Parse(dimensions[1]);

            var cellGrid = new Cell[width, height];

            // Cell creation loop
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    // Cell type assignment
                    var cellType = GetCellType(character);
                    var cell = new Cell(x, y, cellParent, cellType);

                    cellGrid[x, y] = cell;
                }
            }

            // Actor creation loop
            // Due to how rendering in this game works, we need to create all actors AFTER creating all cells
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];
                    var cell = cellGrid[x, y];

                    cell.Actor = GetActor(character, cell);
                }
            }

            return new GameMap(cellGrid);
        }

        /// <summary>
        ///     Assigns Cell Type based on given character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static TileType GetCellType(char c) => c switch
        {
            ' ' => TileType.Empty,
            '#' => TileType.Wall,
            '.' => TileType.Floor,
            's' => TileType.Floor,
            'p' => TileType.Floor,
            'h' => TileType.Floor,
            '-' => TileType.UIborderHorizontalTop,
            '_' => TileType.UIborderHorizontalBottom,
            '!' => TileType.UIborderVerticalLeft,
            '|' => TileType.UIborderVerticalRight,
            '<' => TileType.UIborderCornerTopLeft,
            '>' => TileType.UIborderCornerTopRight,
            '\\' => TileType.UIborderCornerBottomLeft,
            '/' => TileType.UIborderCornerBottomRaight,
            'X' => TileType.EmptyInventorySlot,
            'w' => TileType.Floor,
            'a' => TileType.Floor,
            'm' => TileType.Floor,
            'H' => TileType.Floor,
            'k' => TileType.Floor,
            'b' => TileType.Floor,
            'r' => TileType.Floor,
            'y' => TileType.Floor,  
            't' => TileType.Floor,
            _ => TileType.Empty
        };

        /// <summary>
        ///     Assigns Actor based on given character
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static Actor GetActor(char c, Cell cell) => c switch
        {
            's' => new Skeleton(cell),
            'p' => new Player(cell),
            'b' => new Door(cell, DoorKeyType.Blue, TileType.DoorBlue),
            'r' => new Door(cell, DoorKeyType.Red, TileType.DoorRed),
            'y' => new Door(cell, DoorKeyType.Yellow, TileType.DoorYellow),
            'w' => new ItemActor(cell, new Weapon($"{Utilities.RandomItemName("Sword")}", Program.Rnd.Next(5, 15), false, 100)),
            'a' => new ItemActor(cell, new Armor($"{Utilities.RandomItemName("Armor")}", Program.Rnd.Next(1, 10), Program.Rnd.Next(1, 10), 100)),
            'm' => new ItemActor(cell, new Consumable("Mana Potion", 20, false, 100)),
            'h' => new ItemActor(cell, new Consumable("Healing Potion", 20, true, 100)),
            't' => new Treasure(cell),
            'H' => new Haerówka(cell),
            _ => null
        };
    }
}