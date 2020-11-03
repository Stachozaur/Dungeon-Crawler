using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl
{
    public static partial class UI
    {
        public class UIInventoryActor : Actor
        {
            public UIInventoryActor(Cell cell) : base(cell, TileSet.GetTile(TileType.EmptyInventorySlot))
            {
                
            }
        }
    }
}