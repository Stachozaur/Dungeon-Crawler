namespace Codecool.DungeonCrawl.Items
{
    class Consumable : Item
    {
        private int _potionPower;
        private bool _isRestoringHP;
        public Consumable(string Name, int potionPower, bool isRestoringHP, int droprate)
        {
            _name = Name;
            _potionPower = potionPower;
            _isRestoringHP = isRestoringHP;
            _droprate = droprate;
            _value = potionPower / 10;
            type = TileType.Consumable;
        }
    }
}
