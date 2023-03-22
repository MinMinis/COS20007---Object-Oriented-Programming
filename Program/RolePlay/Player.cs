namespace RolePlay
{
    public class Player : GameObject
    {
        static Random rand = new Random();
        private string _name, _desc, _weapondesc;
        private int _exp, _health, _damage, _armor, _potion, _weapon, _healed, _level, _coin;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public int Exp
        {
            get
            {
                return _exp;
            }
            set
            {
                _exp = value;
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }
        public int Armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
            }
        }
        public int Potion
        {
            get
            {
                return _potion;
            }
            set
            {
                _potion = value;
            }
        }
        public int Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
            }
        }
        public int Healed
        {
            get { return _healed; }
            set { _healed = value; }
        }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            { _level = value; }

        }
        public int Coin
        {
            get
            {
                return _coin;
            }
            set
            {
                _coin = value;
            }
        }
        public string WeaponDesc
        {
            get
            {
                return _weapondesc;
            }
            set
            {
                _weapondesc = value;
            }
        }
        public Player(string name, string desc) : base(new string[] {"hunter", "me"}, name, desc)
        {
            _exp = 0;
            _health = 50;
            _damage = 10;
            _armor = 5;
            _potion = 1;
            _weapon = 5;
            _weapondesc = "Stick";
            _healed = 20;
            _level = 1;
            _coin = 15;
            
        }
    }
}
