namespace RolePlay
{
    public class Action
    {
        static Random rand = new();

        public static void Creep(int stage)
        {
            Console.WriteLine($"You have entered stage {stage} of the challenge.");
            Thread.Sleep(2000);
            Fight();
        }
        public static void Fight()
        {
            switch (rand.Next(0,10))
            {
                case 0:
                    //Boss combat
                    Combat(true, "", 0,0, Program.player);
                    break;
                default:
                    Combat(false, "", 0, 0, Program.player);
                    break;
            }
        }
        public static string Boss()
        {
            switch (rand.Next(0,1))
            {
                case 0:
                    return "Crazy Immersive Mage";
                case 1:
                    return "Infernal Demonic Diablos";
                default:
                    return "Unknown Boss ...";
            }
        }
        public static string Monsters()
        {
            switch (rand.Next(1, 10))
            {
                case 1:
                    return "Devouring Skeleton";
                case 2:
                    return "Shadow Hydra";
                case 3:
                    return "Brutal Yeti";
                case 4:
                    return "Venomous Dragon";
                case 5:
                    return "Crazy Unicorn";
                case 6:
                    return "Eternal Phoenix";
                case 7:
                    return "Deadly Basilisk";
                case 8:
                    return "Hellish Centaurs";
                case 9:
                    return "Monstrous Gorgon";
                case 10:
                    return "Bloodthirsty Aliens";
            }
            return "Human Rogue";
        }
        public static string Loot()
        {
            switch (rand.Next(1,5))
            {
                case 1:
                    Program.player.Potion += 1;
                    return "You have pick up 1 Potion\n";
                default:
                    return "";
            }
        }
        public static void Combat(bool boss, string creep, int dame, int health, Player player)
        {
            int expboss = 0;
            int goldboss = 0;
            if (boss)
            {
                creep = Boss();
                dame = player.Damage/2 + rand.Next(15, 20) * player.Level;
                health = player.Health/2 + rand.Next(50, 100) * player.Level;
                expboss += rand.Next(10,20);
                goldboss += rand.Next(10, 20);
                Console.WriteLine($"\nYou have encounter Boss {creep}");
            }
            else
            {
                creep = Monsters();
                dame = player.Damage/3 + rand.Next(8, 15);
                health = player.Health/5 + rand.Next(30, 50);
                Console.WriteLine($"\nYou have encounter Small {creep}");
            }
            while (health > 0)
            {
                
                Console.WriteLine($"\n{creep.ToUpper()}");
                Console.WriteLine($"Health: {health} | Attack: {dame}");
                Console.WriteLine("---------------------");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (H)eal   (R)un    |");
                Console.WriteLine("---------------------");
                Console.WriteLine($"Your info: {player.Desc} {player.Name}. Level: {player.Level}");
                Console.WriteLine($"Exp: {player.Exp}/10    | Coins: {player.Coin}");
                Console.WriteLine($"Health: {player.Health} | Potion: {player.Potion}");
                Console.WriteLine($"Attack: {player.Damage} | Defend: {player.Armor}\n");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                    case "attack":
                        Console.WriteLine($"{player.Name} choose attack!");
                        int hurt = dame + rand.Next(0,10) - player.Armor;
                        if (hurt < 0)
                            hurt = 0;
                        if (hurt > (dame - player.Armor + 5))
                            Console.WriteLine($"{creep} has caused critical damage on you!");
                        int crit = rand.Next(0, 20);
                        if (crit > 10)
                            Console.WriteLine($"You have used {player.WeaponDesc} to land super critical damage to {creep}");
                        int damage = rand.Next(player.Damage, player.Damage + player.Weapon) + crit;
                        Console.WriteLine($"{player.Name} have losen {hurt} HP, and cause {damage} damage to enemy");
                        player.Health -= hurt; //lose hp
                        health -= damage; //attack creep
                        break;
                    case "d":
                    case "defend":
                        Console.WriteLine($"{player.Name} choose defend!");
                        Console.WriteLine($"{creep} have punched into your armor...");
                        int hurted = dame/4 - player.Armor;
                        if (hurted < 0)
                            hurted = 0;
                        Console.WriteLine($"{player.Name} defend successfully. You have losen {hurted} HP");
                        Program.player.Health -= hurted; //lose hp
                        break;
                    case "h":
                    case "heal":
                        Console.WriteLine($"{player.Name} choose heal!");
                        if (Program.player.Potion == 0)
                        {
                            Console.WriteLine("You have no potion left to heal");
                        }
                        else
                        {
                            Console.WriteLine("You have successfully healed yourself!");
                            Program.player.Potion -= 1;
                            player.Health += player.Healed;
                            Console.WriteLine($"You have used herbals to gain {player.Healed} HP");
                        }
                        if (rand.Next(0,2) > 0)
                        {
                            int hurtheal = dame - player.Armor;
                            if (hurtheal < 0)
                                hurtheal = 0;
                            player.Health -= hurtheal; //lose hp

                            Console.WriteLine($"You have losen {hurtheal} HP because of enemy attack!");
                        } else
                        {
                            Console.WriteLine($"You have evaded the attack from {creep}!");
                        }
                        break;
                    case "r":
                    case "run":
                        Console.WriteLine($"{player.Name} choose run!");
                        Console.WriteLine("You are running away ... \n");
                        Thread.Sleep(3000);
                        if (rand.Next(0,3) == 0)
                        {
                            Console.WriteLine($"{player.Name} have failed to run away from {creep}");
                            int hurtrun = dame - player.Armor;
                            if (hurtrun < 0)
                                hurtrun = 0;
                            Program.player.Health -= hurtrun; //lose hp
                            Console.WriteLine($"{player.Name} have losen {hurtrun} HP because of {creep}'s claws");
                        } else
                        {
                            Console.WriteLine($"You have successfully run away from {creep} to go to shop");
                            Shop.LoadShop(player);
                            Console.WriteLine($"{creep} has wait for you outside the shop\nThere is no way to run away from it ...");
                        }
                        break;
                }
                Thread.Sleep(3000);
                Console.Clear();
                PlayerDeath(player);
            }
            Console.WriteLine($"\n{creep} has been defeated by {player.Desc} {player.Name}");
            int exp = rand.Next(1, 10) + expboss;
            player.Exp += exp; // add exp 
            int gold = rand.Next(5, 10) + goldboss;
            player.Coin += gold; // add exp 
            Console.WriteLine($"You have gained {exp} EXP and {gold} coins !");
            Console.WriteLine(Loot());
            while (player.Exp > 10)
            {
                Console.WriteLine(LevelUp.Lv(player.Exp));
            }
            Console.WriteLine("Enter to continue ...");
            Console.ReadKey();
        }

        public static void PlayerDeath(Player player)
        {
            if (player.Health <= 0)
            {
                Console.WriteLine("You have try the best to rescue the world ...");
                Console.WriteLine("Your HP has returned to 0.");
                Console.WriteLine("Enter to continue ...");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Console.WriteLine("");
        }
    }
}
