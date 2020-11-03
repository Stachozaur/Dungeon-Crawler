namespace Codecool.DungeonCrawl.Items
{
    class Armor : Item
    {
        private int _armor;

        private int _magicResistance;

        public Armor(string name, int armor, int magicResistance, int droprate )
        {
            _name = name;
            _armor = armor;
            _magicResistance = magicResistance;
            _droprate = droprate;
            _value = (_magicResistance + _armor) * 4;
        }
    }
}
