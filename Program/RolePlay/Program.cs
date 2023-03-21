namespace RolePlay
{
    public class Program
    {
        public static Player player = new("", "");
        public static int stage = 0;
        static void Main(string[] args)
        {
            Play();
            while (true)
            {
                stage++;
                Action.Creep(stage);
            }

            
        }
        public static void Play()
        {
            Console.WriteLine("Welcome to RolePlay Game!");
            string playerName = "";
            while (playerName == "")
            {
                Console.WriteLine("Enter your character name: ");
                playerName = Console.ReadLine();
                if (playerName == "")
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                }
                else
                {
                    string playerDesc = "";
                    while (playerDesc == "")
                    {
                        Console.WriteLine("Enter your character role: ");
                        Console.WriteLine("Recommend role: Ninja, Warrior, Hunter, Mage ...");
                        playerDesc = Console.ReadLine();
                        if (playerDesc == "")
                        {
                            Console.WriteLine("Role cannot be empty. Please try again.");
                        }
                        else
                        {
                            player.Name = playerName;
                            player.Desc = playerDesc;
                        }
                    }
                }
            }
            Console.WriteLine("Enter to continue ...");
            Console.ReadKey();

            Console.WriteLine("\nWelcome " + player.Name + " to the darkness place in the Earth!");
            Console.WriteLine("Your are the last " + player.Desc + " ...\nThe last hope of human kind");

            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}