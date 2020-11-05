namespace Codecool.DungeonCrawl.Items
{
    class Weapon : Item
    {
        private int _attack;

        private bool _isMagic;
        
        public Weapon(string name, int attack, bool isMagic, int droprate)
        {
            _name = name;
            _attack = attack;
            _isMagic = isMagic;
            _droprate = droprate;
            _value = _attack * 10;
            type = TileType.Sword;
        }
    }
}
