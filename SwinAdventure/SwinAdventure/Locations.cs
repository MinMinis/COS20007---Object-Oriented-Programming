using System.IO;

namespace SwinAdventure
{
    public class Locations : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Dictionary<string, Paths> _paths;

        public Locations(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Paths>();

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
            else
            {
                return null;
            }
        }
        public override string FullDescription
        {
           get
            {
                string result = "You are in " + Name + "\n" + base.FullDescription + "\n";
                result += "Item in this place: " + _inventory.ItemList();
                if (_paths.Count >= 1) 
                {
                    result += "\nAvalaible Paths:\n";
                    foreach (Paths p in _paths.Values)
                    {
                        result += "\t" + p.Direction + " : " + p.Destination.Name + "\n";
                    }
                    return result;
                } else
                { return result; }
            }
            
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public void AddPath(Paths path)
        {
            _paths[path.Direction] = path;
        }

        public Paths GetPath(string direction)
        {
            if (_paths.ContainsKey(direction))
            {
                return _paths[direction];
            }
            else
            {
                return null;
            }
        }

    }
}
