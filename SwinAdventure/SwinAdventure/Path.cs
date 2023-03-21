namespace SwinAdventure
{
    public class Paths : GameObject
    {
        private Locations _destination;
        private bool _isLocked;
        private string _key;
        private string _direction;

        public Paths(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _isLocked = false;
            _key = "";
            _destination = null;
            _direction = "";
        }

        public Locations Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
            }
        }

        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
            }
        }

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public string Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public bool Unlock(string key)
        {
            if (_isLocked && key.ToLower() == _key.ToLower())
            {
                _isLocked = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string FullDescription
        {
            get
            {
                string desc = "A path to " + _destination.Name + " (" + _direction + ").\n";
                if (_isLocked)
                {
                    desc += "The path is locked.\n";
                }
                else
                {
                    desc += "The path is unlocked.\n";
                }
                return desc;
            }
        }

        public bool Move(Player player)
        {
            if (_isLocked)
            {
                return false;
            }
            else
            {
                player.Location = _destination;
                return true;
            }
        }
    }
}
