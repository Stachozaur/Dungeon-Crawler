using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using Veldrid;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     The game player
    /// </summary>

    public class Player : Actor, IUpdatable
    {
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
            // TODO Receive damage logic
            return false;
        }
    }
}