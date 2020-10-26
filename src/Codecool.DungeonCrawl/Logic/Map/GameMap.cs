namespace Codecool.DungeonCrawl.Logic.Map
{
    public class GameMap
    {
        private readonly Cell[,] _map;

        public int Width { get; }
        public int Height { get; }

        public GameMap(Cell[,] cells)
        {
            _map = cells;
            Width = _map.GetLength(0);
            Height = _map.GetLength(1);
        }

        /// <summary>
        ///     Returns cell at given position (if exists)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell GetCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return null;

            return _map[x, y];
        }

        public Cell this[int x, int y] => GetCell(x, y);
    }
}