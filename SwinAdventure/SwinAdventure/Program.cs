using System;
using System.Net.Http.Headers;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter player name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter player description:");
            string description = Console.ReadLine();

            Player player = new(name, description);

            Item sword = new(new string[] { "Sword", "bronze" }, "a bronze Sword", "A sharp sword.");
            Item shield = new(new string[] { "Shield", "iron" }, "a big shield", "A harden shield.");
            Item gem = new(new string[] { "Gem", "Diamond" }, "a valuable gem", "A shiny gem.");

            Bags bag = new( new string[] {"bag", "cloth"},"Backpack", "A cloth backpack.");
            player.Inventory.Put(bag); // put bag in inventory
            bag.Inventory.Put(sword);
            bag.Inventory.Put(shield);

            Locations jungle = new(new string[] { "jungle"}, "Dangerous jungle", "Hidden items are placed");
            Locations dessert = new(new string[] { "dessert" }, "Harsh dessert", "Deadly place for non-hunter");
            Paths path1 = new(new string[] { "north" }, "North Path", "A path lead to north.");
            Paths path2 = new(new string[] { "south" }, "South Path", "A path lead to south.");
            path1.Destination = dessert;
            path2.Destination = jungle;
            path1.Direction = "north";
            path2.Direction = "south";
            jungle.AddPath(path1);
            dessert.AddPath(path2);
            player.Location = jungle;
            
            jungle.Inventory.Put(gem);
            Console.WriteLine("Welcome to the game Swin Adventure, " + player.Name + "!");

            while (true)
            {
                Console.WriteLine("\nEnter a command:");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    string[] execommand = input.ToLower().Split(' ');
                    if (execommand[0] == "quit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(new CommandProcessor().ExecuteCommand(player, execommand));
                    }
                }
            }
        }
    }
}