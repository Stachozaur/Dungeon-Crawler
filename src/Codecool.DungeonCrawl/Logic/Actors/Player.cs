using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using System.Collections.Generic;
using Veldrid;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     The game player
    /// </summary>
    public class Player : Actor, IUpdatable, IPlayerAttributes
    {
        public int _hp { get; private set; } = 100;
        public int _attack { get; private set; } = 10;
        public int _dexterity { get; private set; } = 10;
        public int _actionPoints { get; private set; } = 50;
        public int _magicResistance { get; private set; } = 0;
        public int _armor { get; private set; } = 10;

        public Player(Cell cell) : base(cell, TileSet.GetTile(TileType.Player))
        {
            Program.UpdatablesToAdd.Add(this);
            var startingItems = new Dictionary<Item, int>
            {
                { new Weapon("B.F.H", 10, false, 5), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Armor("Wooden Armor", 10, 0, 10), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
            };
            var newItems = new Dictionary<Item, int>
            {
                { new Weapon("B.F.H", 10, false, 5), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Armor("Wooden Armor", 10, 0, 10), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
                { new Armor("Iron Chestplate", 20, 0, 10), 1 }
            };


            _inventory = new Inventory(startingItems);
            AddLootToInventory(newItems);
            foreach (var item in _inventory.GetInventory())
            {
                System.Console.WriteLine($"{item.Key.GetItemName()}: {item.Value}");
            }

        }

        public void Update(float deltaTime)
        {
            if (KeyboardInput.IsKeyPressedThisFrame(Key.Up))
            {
                TryMove(Direction.Up);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Down))
            {
                TryMove(Direction.Down);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Left))
            {
                TryMove(Direction.Left);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Right))
            {
                TryMove(Direction.Right);
            }
        }

        private void TryMove(Direction dir)
        {
            var targetCell = Cell.GetNeighbour(dir);
            var canPass = targetCell?.OnCollision(this) ?? false;
            var isActor = targetCell?.IsActor(this) ?? false;

            if (canPass && !isActor)
                AssignCell(targetCell);
            
            else if (canPass && isActor)
            {
                System.Console.WriteLine("dupa");
            }
        }

        public override bool OnCollision(Actor other)
        {
            // TODO Receive damage logic
            return false;
        }

        public void AddLootToInventory(Dictionary<Item, int> lootedItems)
        {
            _inventory.AddLootToInventory(lootedItems);
        }
    }
}