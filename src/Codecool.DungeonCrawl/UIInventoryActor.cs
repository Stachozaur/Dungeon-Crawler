using System.Threading;
using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;

namespace Codecool.DungeonCrawl
{
    public static partial class UI
    {
        public class UIInventoryActor : Actor
        {
            public UIInventoryActor(Cell cell, TileType tile) : base(cell, TileSet.GetTile(tile))
            {

            }
        }
    }
}