using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using System;
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
        private CombatMode _combatMode;

        public Player(Cell cell) : base(cell, TileSet.GetTile(TileType.Player))
        {
            Program.UpdatablesToAdd.Add(this);

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

            if (canPass)
                AssignCell(targetCell);
        }

        public override bool OnCollision(Actor other)
        {
            if (this.Position.x == other.Position.x && this.Position.y == other.Position.y)
            {
                return true;
            }
            return false;
        }

        public void AddToInventory(Item item, int count)
        {

        }

        public void RunCombat(Actor other)
        {
            var collision = OnCollision(other);
            if (collision)
            {
                _combatMode.RunCombat();
            }
        }

    }
}