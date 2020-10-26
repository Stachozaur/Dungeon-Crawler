using Codecool.DungeonCrawl.Logic.Actors;
using Perlin.Display;

namespace Codecool.DungeonCrawl.Logic.Map
{
    /// <summary>
    ///     Represents a cell in the map.
    /// </summary>
    public class Cell
    {
        /// <summary>
        ///     The actor on the cell, null of none.
        /// </summary>
        public Actor Actor;

        /// <summary>
        ///     Type of the cell
        /// </summary>
        public TileType Type;

        public Cell(int x, int y, DisplayObject parent, TileType type)
        {
            Type = type;
            Sprite = new Sprite("tiles.png", false, TileSet.GetTile(Type));
            Sprite.ScaleX = Sprite.ScaleY = TileSet.Scale;

            Position = (x, y);
            parent.AddChild(Sprite);
        }

        public string Tilename => Type.ToString();

        public Sprite Sprite { get; set; }

        public (int x, int y) Position
        {
            get => _position;
            set
            {
                _position = value;
                Sprite.X = value.x * TileSet.Size * TileSet.Scale;
                Sprite.Y = value.y * TileSet.Size * TileSet.Scale;
            }
        }

        private (int x, int y) _position;

        /// <summary>
        ///     Executed whenever some Actor attempts to walk on this cell
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Whether the other Actor can walk on this cell</returns>
        public bool OnCollision(Actor other)
        {
            return Type.IsPassable() && (Actor?.OnCollision(other) ?? true);
        }

        /// <summary>
        ///     Returns a cell in the given distance
        /// </summary>
        /// <param name="dx">X distance from this cell</param>
        /// <param name="dy">Y distance from this cell</param>
        /// <returns>The cell in the given distance</returns>
        public Cell GetNeighbour(int dx, int dy)
        {
            return Program.Map[Position.x + dx, Position.y + dy];
        }

        public Cell GetNeighbour(Direction dir)
        {
            var (x, y) = dir.ToVector();
            return GetNeighbour(x, y);
        }
    }
}