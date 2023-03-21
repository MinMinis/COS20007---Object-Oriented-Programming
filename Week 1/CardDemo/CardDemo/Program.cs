using System;

namespace CardDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Card aCard = new Card("Jack", "Spade");
            aCard.PrintDetails();

            aCard.Flip();
            aCard.PrintDetails();
        }
    }
}
