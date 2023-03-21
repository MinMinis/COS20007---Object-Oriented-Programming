using ClockClass;

namespace Clockclass;
public class Program
{
    static void Main(string[] args)
    {
            //Console.ReadLine();
        Clock time = new(); //define time
        for (int i = 0; i != 24 * 60 * 60 - 1 ; i ++) // 24 hours * 60 minutes * 60 seconds = 86,400 seconds = 1 day
        {
            //Console.WriteLine(time.ReadTime()); //print out
            time.Tick(); // increase seconds
        }
        Console.WriteLine(time.ReadTime());   

    }
}