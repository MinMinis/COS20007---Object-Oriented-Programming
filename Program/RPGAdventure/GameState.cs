using System.Collections;

namespace RPGAdventure
{
    public class GameState : State
    {
        private Player player;
        public GameState(Stack<State> states, Player currentplayer) : base (states)
        {
            this.player = currentplayer;
        }
        public void Process(string num)
        {
            switch (num.ToLower())
            {
                case "e": //Exit
                case "exit":
                    end = true;
                    Console.Clear();
                    break;
                case "s":
                case "start":
                    Story(player);
                    states.Push(new SceneState(states, player));
                    break;
                case "p":
                case "stats":
                case "player":
                    Console.WriteLine(player.AllInfo());
                    break;
                default:
                    Console.Clear();
                    break;
            }
            
        }
        public override void Update()
        {
            GUI.Title(     "Game Menu");
            GUI.Menu("S",  "Start Game");
            GUI.Menu("P",  "Player Stats");
            GUI.Menu("E",  "Exit");

            string number = GUI.GetCommandCount("Input your option");
            Process(number);
        }
        public static void Story(Player player)
        {
            Console.Clear();
            GUI.Title("Story Line");
            GUI.Slowprint($"Welcome {player.Nameplayer} to the darkness place in the dugeon");
            GUI.Slowprint($"You are the last {player.Descplayer} in the world ...");
            GUI.Slowprint("You are the last hope of the human kind");
            GUI.WaitEnter();
        }
    }
}
