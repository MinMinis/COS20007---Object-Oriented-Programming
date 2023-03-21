namespace ClockClass
{
    public class Clock
    {
        private Counter _hour, _minute, _second;
        public Clock() //define elements in clock
        {
            _hour = new Counter("Hours"); // name string for _hour call counter class to set value to 0
            _minute = new Counter("Minutes");
            _second = new Counter("Seconds");
        }
        public void Tick()
        {
            if (_second.Ticks < 59) // max 60 for second
            {
                _second.Increment();

            }
            else
            {
                _second.Reset();
                if (_minute.Ticks < 59) // max 60 for minute
                {
                    _minute.Increment();
                }
                else
                {
                    _minute.Reset();
                    if (_hour.Ticks < 23) // max 24 for hours
                    {
                        _hour.Increment();
                    }
                    else
                    {
                        _hour.Reset(); //Reset and start a new loop

                    }
                }
            }
        }
        public string ReadTime()
        {
                return $"{_hour.Count}:{_minute.Count}:{_second.Count}"; //return the string of time
        }
        public void Reset() //reset all 
        {
            _second.Reset();
            _minute.Reset();
            _hour.Reset();
        }

    }
}
