using Codecool.DungeonCrawl.Combat;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using SharpDX;
using System.Collections.Generic;
using Veldrid;
using Codecool.DungeonCrawl.Logic.Doors;

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
        private List<Option> _options;
        private List<Ability> _abilityList;
        public static Player Singleton { get; private set; }


        public Player(Cell cell) : base(cell, TileSet.GetTile(TileType.Player))
        {
            Program.UpdatablesToAdd.Add(this);
            var startingItems = new Dictionary<Item, int>
            {
                { new Weapon("B.F.H", 10, false, 5), 1 },
                { new Consumable("Healing Potion", 10, true, 50), 1 },
                { new Armor("Wooden Armor", 10, 0, 10), 1 },
                { new Consumable("Mana Potion", 10, true, 50), 1 },
                { new DoorKey( DoorKeyType.Blue ), 1 }
            };
            var newItems = new Dictionary<Item, int>
            {
                { new Weapon("B.F.H", 10, false, 5), 2 },
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

            _abilityList = new List<Ability>();
            _abilityList.Add(new Ability(30, 0, "Attack"));
            _abilityList.Add(new Ability(25, 20, "Heal"));
            _abilityList.Add(new Ability(99, 45, "Pyroblast"));
            _options = new List<Option>();
            Singleton = this;

        }

        public List<Option> CombatOptions()
        {
            foreach (var ability in _abilityList)
            {
                var name = new Option(ability.AbilityName());
                _options.Add(name);
            }
            return _options;
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
                if (targetCell.Actor is ItemActor)
                {
                    PickUpItem(targetCell);
                    AssignCell(targetCell);
                }
                else if (targetCell.Actor is Door)
                {
                    var colorDoor = targetCell.Actor as Door;
                    if (colorDoor.IsKeyMatch(this, colorDoor.GetDoorType()))
                    {
                        //targetCell.Actor.Cell = null;
                        targetCell.Actor.Destroy();
                        targetCell.Actor = null;
                        targetCell.Type = TileType.Floor;
                        AssignCell(targetCell);

                    }
                }

                else
                {
                    var enemy = targetCell.Actor;
                    var CombatMode = new CombatMode(this, enemy);
                    CombatMode.RunCombat();
                }
            }

        }

        public override bool OnCollision(Actor other)
        {
            return false;
        }

        public void AddLootToInventory(Dictionary<Item, int> lootedItems)
        {
            _inventory.AddLootToInventory(lootedItems);
        }

        public void UpdateInventory()
        {
            var inventory = GetInventory();
            //UI.UpdateInventory(inventory);
        }

        public void RemoveItemFromInventory(Item item)
        {
            //System.Console.WriteLine(($"kurwa to jest to {item.type}"));

            _inventory.RemoveItemFromInventory(item);
        }

        private void PickUpItem(Cell targetCell)
        {
            _inventory.AddLootToInventory(targetCell.Actor.GetInventory());
            targetCell.Actor.Destroy();
            targetCell.Actor = null;
            foreach (var item in _inventory.GetInventory())
            {
                System.Console.WriteLine($"{item.Key.GetItemName()}: {item.Value}");
            }
        }
    }
}