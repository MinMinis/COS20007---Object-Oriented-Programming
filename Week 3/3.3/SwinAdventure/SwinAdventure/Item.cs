using System;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }
        /*
        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}\nThis is {base.Name}.";
            }
        }*/
    }
}
