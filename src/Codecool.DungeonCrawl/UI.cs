using Perlin;
using Perlin.Display;
using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace Codecool.DungeonCrawl
{
    public class UI
    {
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
    }
}