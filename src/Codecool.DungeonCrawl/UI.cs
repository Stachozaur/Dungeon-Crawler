using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Actors;
using Perlin;
using Perlin.Display;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using Codecool.DungeonCrawl.Combat;
using SharpDX;
using Utilities = Codecool.DungeonCrawl.Logic.Utilities;

namespace Codecool.DungeonCrawl
{
    public static partial class UI

    {
        private static List<(int x, int y)> InventorySlots = new List<(int, int)>
        {
            (27, 3),
            (28, 3),
            (29, 3),
            (30, 3),
            (31, 3),
            (32, 3),
            (27, 4),
            (28, 4),
            (29, 4),
            (30, 4),
            (31, 4),
            (32, 4),
        };
        
        private static List<(int x, int y)> CombatTextSlots = new List<(int, int)>
        {
            (27, 13),
            (28, 15),
            (28, 14),
            (30, 14),
        };

        private static Dictionary<string, int> fontSize = new Dictionary<string, int>()
        {
            {"small", 8},
            {"header", 22},
            {"normal", 18}
        };

        public static void DisplayUIHeaders()
        {
            TextField InventoryHeader = new TextField(PerlinApp.FontRobotoMono.CreateFont(fontSize["header"]));
            InventoryHeader.Text = "INVENTORY";
            InventoryHeader.FontColor = Color.FloralWhite;
            InventoryHeader.X = 900;
            InventoryHeader.Y = 50;
            PerlinApp.Stage.AddChild(InventoryHeader);

            TextField CombatHeader = new TextField(PerlinApp.FontRobotoMono.CreateFont(fontSize["header"]));
            CombatHeader.Text = "COMBAT";
            CombatHeader.FontColor = Color.FloralWhite;
            CombatHeader.X = 920;
            CombatHeader.Y = 340;
            PerlinApp.Stage.AddChild(CombatHeader);
        }

        public static void UpdateInventory(Dictionary<Item, int> inventory)
        {
            var inventoryReference = new Dictionary<Item, int>();
            var map = Program.Map;
            foreach (var slot in InventorySlots)
            {
                foreach (var item in inventory)
                {
                    {
                        var cell = map.GetCell(slot.x, slot.y);
                        if (cell.Type == TileType.EmptyInventorySlot && !inventoryReference.ContainsKey(item.Key))
                        {
                            
                            var ItemNamelastWord = Utilities.GetLastWord(item.Key.GetItemName());
                            if (GetInventoryTile(ItemNamelastWord) != TileType.Empty)
                            {
                                cell.Actor = new UIInventoryActor(cell, GetInventoryTile(ItemNamelastWord));
                                inventoryReference.Add(item.Key, item.Value);
                                DisplayItemQuantity(item.Value, (slot.x, slot.y));
                                break;
                            }
                            cell.Actor = new UIInventoryActor(cell, GetInventoryTile(item.Key.GetItemName()));
                            inventoryReference.Add(item.Key, item.Value);
                            DisplayItemQuantity(item.Value, (slot.x, slot.y));
                            break;
                            

                        }
                    }
                }
            }
        }

        private static void DisplayItemQuantity(int number, (int x, int y) position)
        {
            var textField = new TextField(PerlinApp.FontRobotoMono.CreateFont(fontSize["small"]));
            textField.Text = String.Format(" {0} ", number.ToString());
            textField.BackgroundColor = Color.FloralWhite;
            textField.FontColor = Color.Black;
            textField.X = (position.x * TileSet.Size) * TileSet.Scale + 20;
            textField.Y = (position.y * TileSet.Size) * TileSet.Scale + 20;
            PerlinApp.Stage.AddChild(textField);
        }

        private static TileType GetInventoryTile(string ItemNamelastWord) => ItemNamelastWord switch
        {
            "B.F.H" => TileType.Hammer,
            "Armor" => TileType.Armor,
            "Shield" => TileType.WoodenShield,
            "Chestplate" => TileType.IronChestplate,
            "Sword" => TileType.Sword,
            "Healing Potion" => TileType.HealingPotion,
            "Mana Potion" => TileType.ManaPotion,
            _ => TileType.Empty
        };

        // public static void DisplayCombatOptions(List<Option> options)
        // {
        //     var optionsReference = new List<Option>();
        //     foreach (var slot in CombatTextSlots)
        //     {
        //         foreach (var option in options)
        //         {
        //             if (optionsReference.ContainsKey(item.Key))
        //             DisplayTextOnSpot((slot.x * TileSet.Size * TileSet.Scale + 20, slot.y * TileSet.Size * TileSet.Scale + 20), option.GetAbilityName(), fontSize["normal"]);
        //             optionsReference.Add(option);
        //             break;
        //         }
        //     }
        //
        // }

        private static void DisplayTileOnSpot((int x, int y) position, TileType tile)
        {
            var map = Program.Map;
            var cell = map.GetCell(position.x, position.y);
            cell.Actor = new UIInventoryActor(cell, tile);
        }
        
        public static void DisplayTextOnSpot((int x, int y) position, string text, int fontSize)
        {
            TextField TextToDisplay = new TextField(PerlinApp.FontRobotoMono.CreateFont(fontSize));
            TextToDisplay.Text = text;
            TextToDisplay.FontColor = Color.FloralWhite;
            TextToDisplay.X = position.x;
            TextToDisplay.Y = position.y;
            PerlinApp.Stage.AddChild(TextToDisplay);
        }
        
    }
}