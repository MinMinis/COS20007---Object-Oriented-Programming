namespace RolePlay
{
    public class Shop
    {
        static Random rand = new Random();
        static string[] shopItems = { "otion", "rmor", "eapon", "amage" };
        static string[] shopCommand = { "P", "A", "W", "D" };
        static int[] shopCosts = { 0, 0, 0, 0 };
        static string[] weaponNames = { "Frosty Blade", "Thunderous Hammer", "Inferno Bow", "Radiant Shield", "Venomous Dagger", "Lumious Spear", "Ethereal Staff", "Sonic Sword", "Mystic Want", "Celestial Blade", "Stick" };


        public static void LoadShop(Player player)
        {
            ShopInstruction();
            SaveShop(player);
        }
        public static void SaveShop(Player player)
        {
            shopCosts[0] = rand.Next(2, 8) * player.Level;
            shopCosts[1] = rand.Next(2, 5) * player.Level;
            shopCosts[2] = rand.Next(4, 10);
            shopCosts[3] = rand.Next(4, 10);

            while (true)
            {

                Console.WriteLine("---------Shop--------");
                for (int i = 0; i < shopItems.Length; i++)
                {
                    Console.WriteLine($"({shopCommand[i]}){shopItems[i]}: {shopCosts[i]} coins");
                }
                Console.WriteLine("(B)ack to previous menu");
                Console.WriteLine("---------------------");
                Console.WriteLine($"Your info: {player.Desc} {player.Name}");
                Console.WriteLine($"Level: {player.Level}   | Coins: {player.Coin}");
                Console.WriteLine($"Health: {player.Health} | Potion: {player.Potion}");
                Console.WriteLine($"Weapon: {player.WeaponDesc} |Weapon attack: {player.Weapon}");
                Console.WriteLine($"Total attack: {player.Damage} | Defend: {player.Armor}\n");
                string shopinput = Console.ReadLine().ToLower();

                if (shopinput == "p" || shopinput == "potion")
                {
                    Buy("potion", shopCosts[0], player);
                }
                else if (shopinput == "a" || shopinput == "armor")
                {
                    Buy("armor", shopCosts[1], player);
                }
                else if (shopinput == "w" || shopinput == "weapon")
                {
                    Buy("weapon", shopCosts[2], player);
                } 
                else if (shopinput == "d" || shopinput == "damage")
                {
                    Buy("damage", shopCosts[3], player);
                }
                else if (shopinput == "b" || shopinput == "back")
                {
                    Console.WriteLine("You have back to the fight");
                    break;
                }
                else
                {
                    Console.WriteLine($"I don't know how to {shopinput}");
                }

            }
        }
        public static void Buy(string item, int cost, Player player)
        {
            if (player.Coin >= cost)
            {
                if (item == "potion")
                {
                    player.Potion++;
                    Console.WriteLine("\nYou have buy a potion!\n");
                }
                else if (item == "armor")
                {
                    player.Armor += rand.Next(5, 10);
                    Console.WriteLine("\nYou have upgraded to a better armor!\n");
                }
                else if (item == "damage")
                {
                    player.Damage += rand.Next(5, 10);
                    Console.WriteLine("\nYour attack has been increased!\n");
                }
                else if (item == "weapon")
                {
                    player.Weapon += rand.Next(5, 10);
                    Console.WriteLine("\nYour weapon has been upgrade!\n");
                    Equipment(player);
                }

                player.Coin -= cost;
            }
            else
            {
                int coinneed = cost - player.Coin;
                Console.WriteLine("\nYou are broke ...");
                Console.WriteLine($"You need {coinneed} coins to buy {item}");
            }
        }
        public static void Equipment(Player player)
        {
            if (rand.Next(999,1000) + player.Level >= 950)
            {
                Thread.Sleep(2000);
                int weaponIndex = rand.Next(0, weaponNames.Length);
                player.Weapon += 50;
                player.WeaponDesc = weaponNames[weaponIndex];
                Console.WriteLine($"With your luck, you have rolled out legendary weapon {weaponNames[weaponIndex]}");
                Console.WriteLine("Your weapon's attack increase greatly ...");
            }
            Console.WriteLine();
        }
        public static void ShopInstruction()
        {
            Console.WriteLine("\nShop Description: ");
            Console.WriteLine(" - This is where you can upgrade your stats and buy potions\n");
        }
    }
}
