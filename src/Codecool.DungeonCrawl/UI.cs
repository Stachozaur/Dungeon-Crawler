using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Codecool.DungeonCrawl.Items;
using Perlin;
using Perlin.Display;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;

namespace Codecool.DungeonCrawl
{
    public static partial class UI
    {
        private static List<(int x, int y)> InventorySlots = new List<(int, int)>
        {
            (4, 27),
            (5, 27),
            (6, 27),
        };

        public static void DisplayUIHeaders()
        {
            TextField InventoryHeader = new TextField(PerlinApp.FontRobotoMono.CreateFont(22));
            InventoryHeader.Text = "INVENTORY";
            InventoryHeader.FontColor = Color.FloralWhite;
            InventoryHeader.X = 900;
            InventoryHeader.Y = 50;
            PerlinApp.Stage.AddChild(InventoryHeader);

            TextField CombatHeader = new TextField(PerlinApp.FontRobotoMono.CreateFont(22));
            CombatHeader.Text = "COMBAT";
            CombatHeader.FontColor = Color.FloralWhite;
            CombatHeader.X = 920;
            CombatHeader.Y = 340;
            PerlinApp.Stage.AddChild(CombatHeader);
        }


        public static void UpdateInventory(Dictionary<Item, int> inventory)
        {
            
            foreach (var item in inventory)
            {
                
                    foreach (var slot in InventorySlots)
                    {
                        
                        if (item.Key is Weapon)
                        {
                            var cell = new Cell(slot.x, slot.y, ,TileSet.GetTile(TileType.EmptyInventorySlot));
                            var inventoryItem = new UIInventoryActor(cell);
                            
                            
                            cell.
                        }
                        
                        
                        public void AssignCell(Cell target)
                        {
                            Cell.Actor = null;
                            Cell = target;
                            target.Actor = this;

                            Position = target.Position;
                        }


                        var InventoryItem = new Actor();


                        // var tile = TileSet.GetTile(TileType.EmptyInventorySlot);
                        var targetCell = new Cell(slot.x, slot.y, new Sprite(), TileType.EmptyInventorySlot);
                        // targetCell.Sprite = new Sprite("tiles.png", false, tile);

                        var character = line[x];

                        // Cell type assignment
                        var cellType = GetCellType(character);
                        var cell = new Cell(x, y, cellParent, cellType);
                    }
            }
        }
    }
}