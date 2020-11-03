namespace Codecool.DungeonCrawl
{
    public abstract class Item
    {
        protected string _name { get; set; }
        
        protected int _value { get; set; }

        protected int _droprate { get; set; }

        public int GetDroprate()
        {
            return _droprate;
        }

        public string GetItemName()
        {
            return _name;
        }
    }
}
