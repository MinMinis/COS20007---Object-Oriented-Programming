namespace RolePlay
{
    public class Shop
    {
        static Random rand = new Random();

        public static void LoadShop(Player player)
        {
            ShopInstruction();
            SaveShop(player);
        }
        public static void SaveShop(Player player)
        {
            int potionShop;
            int armorShop;
            int weaponShop;
            int damageShop;
            potionShop = rand.Next(2, 8) * player.Level;
            armorShop = rand.Next(2, 5) * player.Level;
            weaponShop = rand.Next(4, 10);
            damageShop = rand.Next(4, 10);
            while (true)
            {

                Console.WriteLine("---------Shop--------");
                Console.WriteLine("(P)otion: " + potionShop + " coins");
                Console.WriteLine("(A)rmor: " + armorShop + " coins");
                Console.WriteLine("(D)amage: " + damageShop + " coins");
                Console.WriteLine("(W)eapon: " + weaponShop + " coins");
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
                    Buy("potion", potionShop, player);
                }
                else if (shopinput == "a" || shopinput == "armor")
                {
                    Buy("armor", armorShop, player);
                }
                else if (shopinput == "w" || shopinput == "weapon")
                {
                    Buy("weapon", weaponShop, player);
                } 
                else if (shopinput == "d" || shopinput == "damage")
                {
                    Buy("damage", damageShop, player);
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
                    // add another method to use another weapon ...
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
        public static void ShopInstruction()
        {
            Console.WriteLine("\nShop Description: ");
            Console.WriteLine(" - This is where you can upgrade your stats and buy potions\n");
        }
    }
}
