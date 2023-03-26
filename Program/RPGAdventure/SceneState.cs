using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RPGAdventure
{
    public class SceneState : State
    {
        protected Player currentplayer;
        private static readonly Random random = new();
        private string[] shopItems = { "Damage", "Weapon", "Armor", "Potion" };
        private string[] shopCommand = { "D", "W", "A", "P" };
        private int[] shopCosts = { 0, 0, 0, 0 };
        public SceneState(Stack<State> states, Player player) : base(states)
        {
            this.currentplayer = player;
        }
        private void Process(string num)
        {
            switch (num.ToLower())
            {
                case "e": //Exit
                case "exit":
                    end = true;
                    Console.Clear();
                    break;
                case "c":
                case "creep":
                    if (random.Next(1, 100) >= 5)
                    {
                        Monster meetmons = new Monster();
                        meetmons.Attack += currentplayer.Damage/2;
                        meetmons.Defense+= currentplayer.Defend/3;
                        meetmons.Health+= currentplayer.Health/2;
                        GUI.Slowprint($"You have encounted Monster {meetmons.Name}");
                        states.Push(new EnemyState(states, currentplayer, meetmons));
                    }
                    else
                    {
                        Boss meetboss = new Boss();
                        meetboss.Health = 999999;
                        meetboss.Name = "Unidentified creature?????";
                        meetboss.Defense = 99999;
                        meetboss.Attack = 99999;
                        GUI.Slowprint($"Unlucily, You have encounted Boss {meetboss.Name}");
                        states.Push(new EnemyState(states, currentplayer, meetboss));
                    }
                    break;
                case "b":
                case "boss":
                    Boss newboss = new Boss();
                    newboss.Health += currentplayer.Health/2;
                    newboss.Attack += currentplayer.DamageMax / 3;
                    newboss.Defense += currentplayer.Defend / 2;

                    GUI.Slowprint($"You have encounted Boss {newboss.Name}");
                    states.Push(new EnemyState(states, currentplayer, newboss));
                    break;
                case "s":
                case "shop":
                    Displayshop(currentplayer);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public override void Update()
        {
            GUI.Title(    "Game Play");
            GUI.Menu("C", "Farm Creep");
            GUI.Menu("B", "Challenge Boss");
            GUI.Menu("S", "Go to Shop");
            GUI.Menu("E", "Exit");

            string input = GUI.GetCommandCount("Enter your option (Player)");
            Process(input);
        }
        private void Displayshop(Player currentp)
        {
            Console.Clear();
            ShopInstruction();
            SaveShop(currentp);
        }
        private void ShopInstruction()
        {
            GUI.Title("Shop Description: ");
            GUI.GetCommand("This is where you can upgrade your stats and buy potions");
        }
        private void SaveShop(Player player)
        {
            shopCosts[0] = random.Next(2, 8) * player.Level / 2;
            shopCosts[1] = random.Next(2, 5) * player.Level / 2;
            shopCosts[2] = random.Next(4, 10) * player.Level / 2;
            shopCosts[3] = random.Next(4, 10) * player.Level / 2;
            while (true)
            {
                GUI.Title("Shop");
                for (int i = 0; i < shopItems.Length; i++)
                {
                    GUI.Menu($"{shopCommand[i]}", $"{shopItems[i]}: {shopCosts[i]} coins");
                }
                GUI.Menu("B", "Back to previous menu");

                GUI.Title("Your Player's Info");
                Console.WriteLine(player.AllInfo());
                string input = GUI.GetCommandCount("Enter your option");
                if (input == "d" || input == "damage")
                {
                    Buy("damage", shopCosts[0], player);
                }
                else if (input == "w" || input == "weapon")
                {
                    Buy("weapon", shopCosts[1], player);
                }
                else if (input == "a" || input == "armor")
                {
                    Buy("armor", shopCosts[2], player);
                }
                else if (input == "p" || input == "potion")
                {
                    Buy("potion", shopCosts[3], player);
                }
                else if (input == "b" || input == "back")
                {
                    Console.WriteLine("You have back to the previous menu");
                    break;
                }
                else if (input == "c" || input == "clear")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"I don't know how to {input}");
                }
            }
        }
        private static void Buy(string item, int cost, Player player)
        {
            Console.WriteLine($"Your purchase is processing");
            Thread.Sleep(1000);
            GUI.WaitEnter();
            if (player.Gold >= cost)
            {
                Thread.Sleep(1000);

                if (item == "potion")
                {
                    player.Potion++;
                    GUI.SystemNoti($"You have buy a {item}");
                }
                else if (item == "armor")
                {
                    player.Defend += random.Next(5, 10);
                    GUI.SystemNoti("You have upgraded to a better armor");
                }
                else if (item == "damage")
                {
                    int upgraded = random.Next(5, 10);
                    player.DamageMax += upgraded;
                    player.Damage += upgraded;
                    GUI.SystemNoti("Your attack has been increased");
                }
                else if (item == "weapon")
                {
                    player.WeaponDmg += random.Next(5, 10);
                    Console.WriteLine("\nYour weapon has been upgrade!\n");
                    GUI.SystemNoti("Your weapon has been upgrade");
                    Equipment(player);
                }

                player.Gold -= cost;
            }
            else
            {
                int coinneed = cost - player.Gold;
                Console.WriteLine("\nYou are broke ...");
                Console.WriteLine($"You need {coinneed} coins to buy {item}");
            }
            GUI.WaitEnter();
        }
        private static void Equipment(Player player)
        {
            string[] weaponNames = { "Frosty Blade", "Thunderous Hammer", "Inferno Bow", "Radiant Shield", "Venomous Dagger", "Lumious Spear", "Ethereal Staff", "Sonic Sword", "Mystic Want", "Celestial Blade", "Stick" };

            if (random.Next(0, 1000) + player.Level >= 950)
            {
                Thread.Sleep(2000);
                int weaponIndex = random.Next(0, weaponNames.Length);
                player.WeaponDmg += 50;
                player.DamageMax += player.WeaponDmg;
                player.Weapon = weaponNames[weaponIndex];
                GUI.Congrat($"With your luck, you have rolled out legendary weapon {weaponNames[weaponIndex]}");
                GUI.Congrat("Your weapon's attack increase greatly ...");
            }
        
        }
    }
}
