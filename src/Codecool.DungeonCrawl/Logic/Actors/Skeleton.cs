using System;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Sample enemy
    /// </summary>
    public class Skeleton : Actor, IPlayerAttributes
    {
        public int _hp { get; private set; } = 20;
        public int _attack { get; private set; } = 5;
        public int _dexterity { get; private set; } = 0;
        public int _actionPoints { get; private set; } = 50;
        public int _magicResistance { get; private set; } = 0;
        public int _armor { get; private set; } = 5;
        private static readonly Random _random = new Random();
        private float _timeLastMove;

        public Skeleton(Cell cell) : base(cell, TileSet.GetTile(TileType.Skeleton))
        {
        }
    }
}