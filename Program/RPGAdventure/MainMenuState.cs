using System.Collections;
using System;

namespace RPGAdventure
{
    public class MainMenuState : State
    {
        protected ArrayList playerlist;
        private Player activep;
        public MainMenuState(Stack<State> states, ArrayList playerlist) : base(states)
        {
           this.playerlist = playerlist;
           activep = null;
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
                case "n":
                case "new":
                    NewGame();
                    break;
                case "p"://Player creator
                case "player":
                    states.Push(new PlayerState(states, activep, playerlist));
                    Console.Clear();
                    break;
                case "s":// Count created players
                case "select":
                    ChoosePlayer();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public override void Update()
        {
            if (activep != null)
            {
                Console.WriteLine($"Player: {activep.Name}");
                Console.WriteLine(activep.Banner());
            }

            GUI.Title(    "Main Menu");
            GUI.Menu("N", "New Game");
            GUI.Menu("P", "Player Creator");
            GUI.Menu("S", "Select Players");
            GUI.Menu("E", "Exit");

            string number = GUI.GetCommandCount("Input your option");
            Process(number);
        }
        private void NewGame()
        {
            if (activep == null)
            {
                GUI.SystemNoti("There is no Active Player. Select any player first");
            } 
            else
            {
                states.Push(new GameState(states, activep));
            }
        }
        private void ChoosePlayer()
        {
            if (activep != null)
            {
                Console.WriteLine($"You are selecting {activep}");
            }

            Console.WriteLine($"\nThere are {playerlist.Count} players:");
            int i = 1;
            foreach (var players in playerlist)
            {
                Console.WriteLine($"\t{i} - {players}");
                i++;
            }
            string choose = GUI.GetCommandCount("Player Selection");
            choose.ToLower();
            try
            {
                int chosen = Int32.Parse(choose);
                chosen--;
                activep = (Player)this.playerlist[chosen];
                GUI.SystemNoti($"Player {activep.Name} has been selected!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
        }
    }
}
