using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAdventure
{
    public class State
    {
        protected Stack<State> states;
        protected bool end = false;
        public State(Stack<State> states)
        {
            this.states = states;

        }
        public bool wantEnd()
        {
            return end;
        }
        public virtual void Update()
        {

        }
    }
}
