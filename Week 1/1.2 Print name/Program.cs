using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World, who are you? ");
            myMessage.Print ();
            string[] messages; // define array and create variable name
            messages = new string[5]; // 5 names will be stored
            messages[0] = "Welcome back!";
            messages[1] = "What a lovely name";
            messages[2] = "Great name";
            messages[3] = "Oh hi!";
            messages[4] = "That is a silly name";
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            if (name == "Mark")
            {
                Console.WriteLine(messages[0]);
            } 
            else if (name == "Fred")
            {
                Console.WriteLine(messages[1]);
            }
            else if (name == "Wilma")
            {
                Console.WriteLine(messages[2]);
            }
            else if (name == "Alice")
            {
                Console.WriteLine(messages[3]);
            }
            else
            {
                Console.WriteLine(messages[4]);
            }
        }
    }
}
