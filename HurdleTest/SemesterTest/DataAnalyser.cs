namespace SemesterTest
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        private AverageSummary _avgSumariser;
        private MinMaxSummary _minMaxSummariser;
        private SummaryStrategy _strategy;
        public SummaryStrategy Strategy
        {
            get
            {
                return _strategy;
            }
            set 
            {
                _strategy = value;
            }
        }
        public DataAnalyser() : this(new List<int>(), new AverageSummary()) { }
        public DataAnalyser(List<int> numbers, SummaryStrategy sumstrategy)
        {
            _numbers = numbers;
            _strategy = sumstrategy;
        }
        public void AddNumber(int num)
        {
            _numbers.Add(num);
        }
        public void Summarise(string typeOfSummary)
        {
            if ( Strategy is MinMaxSummary )
            {
                _strategy.PrintSummary(_numbers);
            }
            else if (Strategy is AverageSummary)
            {
                _strategy.PrintSummary(_numbers);
            }
            //_strategy.PrintSummary(_numbers);
        }
    }
}
