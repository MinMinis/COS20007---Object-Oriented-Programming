using System.Collections;

namespace RPGAdventure
{
    public class GamePlay
    {
        private bool end;
        private Stack<State> states;
        private ArrayList playerlist;

        private void InitStates()
        {
            states = new Stack<State>();

            states.Push(new MainMenuState(states, playerlist));
        }
        private void InitPlayer()
        {
            playerlist = new ArrayList();
        }
        private bool End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }
        private void Initial()
        {
            end = false;

        }
        public GamePlay()
        {
            Initial();
            InitPlayer();
            InitStates();
        }
        public void Run()
        {

            while (states.Count > 0)
            {
                if (states.Count > 0)
                {
                    states.Peek().Update();
                    if (states.Peek().wantEnd())
                    {
                        states.Pop();
                    }
                }

            }
            GUI.SystemNoti("End Game ...");
            GUI.SystemNoti("Thanks for playing");
            GUI.Slowprint("Creator: Thanh Minh");
            GUI.Slowprint("Subject: COS20007 OOP");
        }
    }
}
