namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;
        public Player(string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public override string FullDescription //override
        {
            get
            {
                return $"You are {Name}, {base.ShortDescription}.You are carrying: {_inventory.ItemList()}";
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
