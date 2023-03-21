namespace RolePlay
{
    public class Action
    {
        static Random rand = new();

        public static void Creep(int stage)
        {
            Console.WriteLine($"You have entered stage {stage} of the challenge.");
            Console.WriteLine("Enter to continue ...");
            Console.ReadKey();
            Thread.Sleep(2000);
            Fight();
        }
        public static void Fight()
        {
            switch (rand.Next(0,10))
            {
                case 0:
                    Combat(true, "", 0,0);
                    break;
                /*case 1:
                    Shop();
                    break;*/
                default:
                    Combat(false, "", 0, 0);
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
                    return "You have pick up 1 Potion";
                default:
                    return "";
            }
        }
        public static void Combat(bool random, string creep, int dame, int health)
        {
            int expboss = 0;
            int goldboss = 0;
            if (random)
            {
                creep = Boss();
                dame = Program.player.Damage/2 + rand.Next(15, 20) * Program.player.Level;
                health = Program.player.Health/2 + rand.Next(50, 100) * Program.player.Level;
                expboss += rand.Next(10,20);
                goldboss += rand.Next(10, 20);
                Console.WriteLine($"\nYou have encounter Boss {creep}");
            }
            else
            {
                creep = Monsters();
                dame = Program.player.Damage/3 + rand.Next(8, 15);
                health = Program.player.Health/5 + rand.Next(30, 50);
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
                Console.WriteLine($"Your info: {Program.player.Desc} {Program.player.Name}. Level: {Program.player.Level}");
                Console.WriteLine($"Health: {Program.player.Health} | Potion: {Program.player.Potion}");
                Console.WriteLine($"Attack: {Program.player.Damage} | Defend: {Program.player.Armor}\n");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                    case "attack":
                        Console.WriteLine($"{Program.player.Name} have choose attack!");
                        int hurt = dame - Program.player.Armor;
                        if (hurt < 0)
                            hurt = 0;
                        int crit = rand.Next(0, 20);
                        if (crit > 10)
                            Console.WriteLine($"You have land super critical damage to {creep}");
                        int damage = rand.Next(Program.player.Damage, Program.player.Damage + Program.player.Weapon) + crit;
                        Console.WriteLine($"{Program.player.Name} have losen {hurt} HP, and cause {damage} damage to enemy");
                        Program.player.Health -= hurt; //lose hp
                        health -= damage; //attack creep
                        break;
                    case "d":
                    case "defend":
                        Console.WriteLine($"{Program.player.Name} have choose defend!");
                        Console.WriteLine($"{creep} have punched into your armor...");
                        int hurted = dame/4 - Program.player.Armor;
                        if (hurted < 0)
                            hurted = 0;
                        //int damaged = rand.Next(Program.player.Damage, Program.player.Damage + Program.player.Weapon)/2;
                        Console.WriteLine($"{Program.player.Name} defend successfully. You have losen {hurted} HP");
                        Program.player.Health -= hurted; //lose hp
                        //health -= damaged; //attack creep
                        break;
                    case "h":
                    case "heal":
                        Console.WriteLine($"{Program.player.Name} have choose heal!");
                        if (Program.player.Potion == 0)
                        {
                            Console.WriteLine("You have no potion left to heal");
                        }
                        else
                        {
                            Console.WriteLine("You have successfully healed yourself!");
                            Program.player.Potion -= 1;
                            Program.player.Health += Program.player.Healed;
                            Console.WriteLine($"You have used herbals to gain {Program.player.Healed} HP");
                        }
                        if (rand.Next(0,2) > 0)
                        {
                            int hurtheal = dame - Program.player.Armor;
                            if (hurtheal < 0)
                                hurtheal = 0;
                            Program.player.Health -= hurtheal; //lose hp

                            Console.WriteLine($"You have losen {hurtheal} HP because of enemy attack!");
                        } else
                        {
                            Console.WriteLine($"You have evaded the attack from {creep}!");
                        }
                        break;
                    case "r":
                    case "run":
                        Console.WriteLine($"{Program.player.Name} have choose run!");
                        Console.WriteLine("You are running away ... ");
                        Thread.Sleep(3000);
                        if (rand.Next(0,3) == 0)
                        {
                            Console.WriteLine($"{Program.player.Name} have failed to run away from {creep}");
                            int hurtrun = dame - Program.player.Armor;
                            if (hurtrun < 0)
                                hurtrun = 0;
                            Program.player.Health -= hurtrun; //lose hp
                            Console.WriteLine($"{Program.player.Name} have losen {hurtrun} HP because of {creep}'s claws");
                        } else
                        {
                            Console.WriteLine($"You have successfully run away from {creep}");
                            //Environment.Exit(0);
                            Fight();
                            break;
                        }
                        break;
                }
                PlayerDeath();
            }
            Console.WriteLine($"\n{creep} has been defeated by {Program.player.Desc} {Program.player.Name}");
            int exp = rand.Next(1, 10) + expboss;
            Program.player.Exp += exp; // add exp 
            int gold = rand.Next(5, 10) + goldboss;
            Program.player.Coin += gold; // add exp 
            Console.WriteLine($"You have gained {exp} EXP and {gold} coins !");
            Console.WriteLine(Loot());
            while (Program.player.Exp > 10)
            {
                Console.WriteLine(LevelUp.Lv(Program.player.Exp));
            }
            Console.WriteLine("Enter to continue ...");
            Console.ReadKey();
        }

        public static void PlayerDeath()
        {
            if (Program.player.Health <= 0)
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
