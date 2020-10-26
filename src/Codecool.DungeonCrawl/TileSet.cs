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
        public const int Scale = 3;

        private static readonly Dictionary<TileType, Rectangle> TileMap;

        static TileSet()
        {
            TileMap = new Dictionary<TileType, Rectangle>
            {
                [TileType.Empty] = CreateTile(0, 0),
                [TileType.Wall] = CreateTile(10, 17),
                [TileType.Floor] = CreateTile(2, 0),
                [TileType.Player] = CreateTile(27, 0),
                [TileType.Skeleton] = CreateTile(29, 6)
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