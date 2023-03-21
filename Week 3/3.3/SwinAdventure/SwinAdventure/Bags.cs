using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bags : Item
    {
        private Inventory _bag;

        public Bags(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _bag = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _bag.Fetch(id);
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"In the {this.Name}, you can see \n{_bag.ItemList()}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _bag;
            }
        }
    }
}
