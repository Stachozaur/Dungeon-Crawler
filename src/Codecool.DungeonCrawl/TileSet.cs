using System.Collections.Generic;
using Perlin.Geom;

namespace Codecool.DungeonCrawl
{
    /// <summary>
    ///     Helper class to read the tile map image.
    /// </summary>
    public static class TileSet
    {
        /// <summary>
        ///     Size of a single tile in pixels
        /// </summary>
        public const int Size = 16;

        /// <summary>
        ///     Scale of the game (used as a multiplier)
        /// </summary>
        public const int Scale = 2;

        private static readonly Dictionary<TileType, Rectangle> TileMap;

        static TileSet()
        {
            TileMap = new Dictionary<TileType, Rectangle>
            {
                [TileType.Empty] = CreateTile(0, 0),
                [TileType.Wall] = CreateTile(10, 17),
                [TileType.Floor] = CreateTile(2, 0),
                [TileType.Player] = CreateTile(27, 0),
                [TileType.Skeleton] = CreateTile(29, 6),
                [TileType.EmptyInventorySlot] = CreateTile(23, 26),
                [TileType.Sword] = CreateTile(0, 29),
                [TileType.Consumable] = CreateTile(16, 28),
                [TileType.Armor] = CreateTile(0, 23),
                [TileType.Hammer] = CreateTile(5, 29),

                [TileType.Keanu] = CreateTile(31, 8),
                [TileType.UIborderHorizontalTop] = CreateTile(17, 19),
                [TileType.UIborderVerticalLeft] = CreateTile(16, 20),
                [TileType.UIborderHorizontalBottom] = CreateTile(17,21),
                [TileType.UIborderVerticalRight] = CreateTile(18, 20),
                [TileType.UIborderCornerBottomLeft] = CreateTile(16, 21),
                [TileType.UIborderCornerBottomRaight] = CreateTile(18, 21),
                [TileType.UIborderCornerTopLeft] = CreateTile(16, 19),
                [TileType.UIborderCornerTopRight] = CreateTile(18, 19),
                [TileType.HealingPotion] = CreateTile(18,25),
                [TileType.WoodenShield] = CreateTile(8,24),
                [TileType.ManaPotion] = CreateTile(16,25),
                [TileType.IronChestplate] = CreateTile(0,23),
                [TileType.DoorBlue] = CreateTile(0, 10),
                [TileType.DoorRed] = CreateTile(0, 20),
                [TileType.DoorYellow] = CreateTile(23, 10),
                [TileType.Treasure] = CreateTile(23, 11),
                [TileType.Key] = CreateTile(17,23),
                [TileType.Dog] = CreateTile(31, 7)
            };
        }

        /// <summary>
        ///     Returns tile rectange for given TileType
        /// </summary>
        /// <param name="tileType"></param>
        /// <returns></returns>
        public static Rectangle GetTile(TileType tileType)
        {
            return TileMap[tileType];
        }

        private static Rectangle CreateTile(int i, int j)
        {
            return new Rectangle(i * (Size + 1), j * (Size + 1), Size, Size);
        }
    }
}