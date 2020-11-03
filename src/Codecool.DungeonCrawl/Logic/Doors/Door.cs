using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.DungeonCrawl.Logic.Actors;
using Codecool.DungeonCrawl.Items;

namespace Codecool.DungeonCrawl.Logic.Doors
{
    public class Door : Actor
    {

        public Door(Cell cell, DoorKeyType color, TileType tile) : base(cell, tile)
        {

        }
        
        //public bool IsKeyMatch(Inventory inventory)
        //{

        //}

    }

}
