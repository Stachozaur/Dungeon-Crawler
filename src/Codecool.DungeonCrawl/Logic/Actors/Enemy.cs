using Codecool.DungeonCrawl;
using Codecool.DungeonCrawl.Items;
using Codecool.DungeonCrawl.Logic;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Display;
using Perlin.Geom;
using System;
using System.Collections.Generic;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    public abstract class Enemy : Actor, IUpdatable
    {
        public abstract bool isAggressive { get; set; }

        public abstract float timeLastMove { get; set; }
        public abstract float timeLastSpeak { get; set; }
        public abstract float timeToRemoveSpeak { get; set; }

        public abstract List<string> speakList { get; set; }
        public TextField textField { get; set; }

        public Enemy(Cell cell, Rectangle tile) : base(cell, tile)
        {
            isAggressive = IsAggressive();
            var lootableItems = new Dictionary<Item, int> { };
            var lootTable = new LootTable(lootableItems);
            _inventory = new Inventory(lootTable.RandomizeLoot());


        }


        public string Speak()
        {
            int index = Program.Rnd.Next(speakList.Count);
            return speakList[index];
        }
        public bool IsAggressive()
        {
            return Program.Rnd.Next(100) % 2 == 0;
        }
        public bool AggressiveRunCheck(Player player)
        {

            int CriticalDistance = 5;
            var playerPosition = player.Position;
            var position = this.Position;
            (int x, int y) distance = GetVector(playerPosition, position);
            distance = (Math.Abs(distance.x), Math.Abs(distance.y));
            return distance.x <= CriticalDistance && distance.y == 0 || distance.y <= CriticalDistance && distance.x == 0;
        }

        public Direction ChargePlayerDirection(Player player)
        {
            (int x, int y) vector = GetVector(player.Position, Position);

            (int x, int y) normalize = (Math.Sign(vector.x), Math.Sign(vector.y));

            Direction targetDirection = normalize.ToDirection();
            return targetDirection;
        }

        public void ChargePlayer(Player player)
        {
            Direction dir = ChargePlayerDirection(player);
            TryMove(dir);
        }


        public Direction GetRandomDirection()
        {
            int maxDirection = 8;
            var direction = (Direction)Program.Rnd.Next(0, maxDirection);
            return direction;
        }


        public void TryMove(Direction dir)
        {
            var targetCell = Cell.GetNeighbour(dir);
            var canPass = targetCell?.OnCollision(this) ?? false;
            var isActor = targetCell?.IsActor(this) ?? false;

            if (canPass && !isActor)
            {
                AssignCell(targetCell);
            }
        }

        public void RandomAiMove()
        {
            var direction = GetRandomDirection();
            TryMove(direction);
        }

        public (int x, int y) GetVector((int x, int y) position, (int x, int y) otherPosition)
        {
            (int x, int y) distance = (position.x - otherPosition.x, position.y - otherPosition.y);
            return distance;
        }

        public bool IsPlayerClose()
        {
            return false;
        }

        public void Update(float deltaTime)
        {
            var textField = UI.CreateEnemyText(this);

            EnemyMove(deltaTime, textField);
            EnemySpeak(deltaTime, textField);
        }


        private void EnemySpeak(float deltaTime, TextField textField)
        {
            ;
            timeLastSpeak += deltaTime;
            timeToRemoveSpeak += deltaTime;
            if (timeLastSpeak >= 3f)
            {
                UI.DisplayEnemyText(textField);
                timeLastSpeak = 0;
                timeToRemoveSpeak = 0;

            if (timeToRemoveSpeak >= 2f)
            {
                UI.RemoveEnemyText(textField);
            }

            }
        }

        private void EnemyMove(float deltaTime, TextField textField)
        {
            timeLastMove += deltaTime;
            if (timeLastMove >= 1.3f)
            {
                UI.RemoveEnemyText(textField);
                if (isAggressive && AggressiveRunCheck(Player.Singleton))
                {
                    timeLastMove = 0;
                    ChargePlayer(Player.Singleton);
                }
                else
                {
                    timeLastMove = 0;
                    RandomAiMove();
                }
            }
        }
    }
}