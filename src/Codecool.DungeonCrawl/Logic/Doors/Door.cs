using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Interfaces;

namespace Codecool.DungeonCrawl.Logic.Doors
{
    public class Door : Actor 
    {
        private DoorKeyType _color;


        public Door(Cell cell, DoorKeyType color, TileType tile) : base(cell , TileSet.GetTile(tile))
        {
            
            _color = color;
        }

        public DoorKeyType GetDoorType()
        {
            return _color;
        }

        public bool IsKeyMatch(Player player, DoorKeyType color)
        {
            foreach (var item in player.GetInventory())
            {
                if (item.Key is DoorKey)
                {
                    Console.WriteLine("oh yeahh");
                    var doorKey = item.Key as DoorKey;
                    //doorKey
                    //(DoorKey)item.Key.GetKeyType();
                    //== door.GetDoorType();
                    return true;
                }
            }
            return false;
            
        }

    }

}
