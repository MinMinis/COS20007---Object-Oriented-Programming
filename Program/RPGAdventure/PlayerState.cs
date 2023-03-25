using System.Collections;
using System.Transactions;

namespace RPGAdventure
{
    internal class PlayerState : State
    {
        ArrayList playerlist;
        Player currentplayer;

        public PlayerState(Stack<State> states, Player player, ArrayList playerlist) : base(states)
        {
            this.playerlist = playerlist;
            this.currentplayer = player;
        }
        public void Process(string num)
        {
            switch (num.ToLower())
            {
                case "b": //Exit
                case "back":
                    end = true;
                    Console.Clear();
                    break;
                case "n":
                case "new":
                    CreatePlayer();
                    break;
                case "e":
                case "edit":
                    EditPlayer();
                    break;
                case "d":
                case "delete":
                    DeletePlayer();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        private void CreatePlayer()
        {
            GUI.GetCommand("Input your player's name");
            string name = Console.ReadLine();
            GUI.GetCommand("Input your player's role");
            string desc = Console.ReadLine();
            if (name != "" || desc != "")
            {
                playerlist.Add(new Player(name, desc));
                GUI.SystemNoti($"Character {desc} {name} created successfully");
                Thread.Sleep(1000);
                GUI.WaitEnter();
            }
        }
        private void EditPlayer()
        {
            Console.WriteLine($"\nThere are {playerlist.Count} players:");
            int i = 1;
            foreach (var players in playerlist)
            {
                GUI.Menu($"{i}", $"{players}");
                i++;
            }
            string choose = GUI.GetCommandCount("Player Selection to Edit").ToLower();
            try
            {
                int chosen = Int32.Parse(choose);
                chosen--;
                currentplayer = (Player)this.playerlist[chosen];
                GUI.SystemNoti($"Player {currentplayer.Name} has been selected!");
                Rename();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Rename()
        {
            currentplayer.Nameplayer = GetNewValue("New name for the", currentplayer.Nameplayer);
            currentplayer.Descplayer = GetNewValue("New role for the", currentplayer.Descplayer);
            currentplayer.Exp = GetNewLevel("Add experience for current player to level up (for each 10 exp, level will be up)");
            Action.CheckExp(currentplayer);
        }

        private string GetNewValue(string message, string currentValue)
        {
            string newValue = GUI.GetCommandCount($"{message} {currentValue}");
            if (string.IsNullOrEmpty(newValue))
            {
                GUI.SystemNoti($"New {message.ToLower()} can't be empty");
            }
            else
            {
                GUI.SystemNoti($"Player {currentplayer.Nameplayer} has been edited");
                return newValue;
            }
            return currentValue;
        }

        private int GetNewLevel(string message)
        {
            string newLevelString = GUI.GetCommandCount(message);
            if (string.IsNullOrEmpty(newLevelString))
            {
                GUI.SystemNoti("Added experience can't be empty");
                return currentplayer.Exp;
            }
            else
            {
                if (int.TryParse(newLevelString, out int newLevel))
                {
                    GUI.SystemNoti($"Player {currentplayer.Nameplayer}'s experience has been edited");
                    newLevel += currentplayer.Exp;
                    return newLevel;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number for experience.");
                    return currentplayer.Exp;
                }
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine($"\nThere are {playerlist.Count} players:");
            int i = 1;
            foreach (var players in playerlist)
            {
                GUI.Menu($"{i}", $"{players}");
                i++;
            }
            string choose = GUI.GetCommandCount("Player Selection to Delete");
            choose.ToLower();
            try
            {
                int chosen = Int32.Parse(choose);
                chosen--;
                currentplayer = (Player)this.playerlist[chosen];
                GUI.SystemNoti($"Player {currentplayer.Name} has been deleted!");
                playerlist.RemoveAt(chosen);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override void Update()
        {
            GUI.Title(    "Create character");
            GUI.Menu("N", "New Character");
            GUI.Menu("E", "Edit Character");
            GUI.Menu("D", "Delete Character");
            GUI.Menu("B", "Back");

            string input = GUI.GetCommandCount("Enter your option (Player)");
            Process(input);
        }

    }
}
