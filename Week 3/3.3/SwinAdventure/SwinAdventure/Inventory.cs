using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }
        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                return item.AreYou(id);
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }
        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }
        public string ItemList()
        {
            string result = ""; //build string
            foreach (Item item in _items)
            {
                result += ( $"\t{item.ShortDescription}"); // add append for each item's short desc 
            }
            return result;
        }
    }
}
