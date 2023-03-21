namespace ClockClass
{
    public class Counter
    {
        private int _count;
        private string _name;
        public string Name
        { 
            get
             {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Count { get { return _count; } }
        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }
        public void Increment()
        {
            _count++;
        }
        public void Reset()
        {
            _count = 0;
        }
        public int Ticks
        {
            get
            {
                return _count;
            }
        }
    }
}
