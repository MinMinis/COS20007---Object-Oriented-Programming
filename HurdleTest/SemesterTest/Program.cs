namespace SemesterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MinMax Summary");
            List<int> studentID = new List<int>() {1 ,0 ,3, 8, 0, 9, 0, 4, 8};
            DataAnalyser dataAnalyser = new(studentID,new MinMaxSummary());
            dataAnalyser.Summarise("minmax");
            studentID.Add(10);
            studentID.Add(7);
            studentID.Add(2);

            Console.WriteLine("Average Summary");
            dataAnalyser.Strategy = new AverageSummary();
            dataAnalyser.Summarise("avg");

        }
    }
}