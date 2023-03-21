namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Locations _location;
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
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            } 
            else if (_location != null)
            {
                return _location.Locate(id);
            }
            return null;

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
        public Locations Location
        { 
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

    }
}
