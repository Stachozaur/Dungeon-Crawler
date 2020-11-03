using Codecool.DungeonCrawl.Combat;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using System;
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
        private List<Option> _options;
        private List<Ability> _abilityList;

        
        public Player(Cell cell) : base(cell, TileSet.GetTile(TileType.Player))
        {
            Program.UpdatablesToAdd.Add(this);
            _abilityList = new List<Ability>();
            _abilityList.Add(new Ability(30, 0, "Attack"));
            _abilityList.Add(new Ability(25, 20, "Heal"));
            _abilityList.Add(new Ability(99, 45, "Pyroblast"));
            _options = new List<Option>();
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
                var enemy = targetCell.Actor;
                var CombatMode = new CombatMode(this, enemy);
                CombatMode.RunCombat();
            }
        }

        public override bool OnCollision(Actor other)
        {
            return false;
        }

        public void AddToInventory(Item item, int count)
        {

        }

    }
}