using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven {

    public class Machine<TState, TTransition> {

        private readonly IDictionary<TState, HashSet<Transition<TState, TTransition>>> states;

        public TState CurrentState { get; }

        public Machine(
            ISet<TState> states, 
            ISet<Transition<TState, TTransition>> transitions, 
            TState initialState) {

            if (!states.Contains(initialState)) {
                throw new ArgumentException("the initial state must exist in the Set of states");
            }

            this.CurrentState = initialState;
            this.states =
                states.ToDictionary(
                    state => state,
                    state => 
                        transitions
                            .Where(transition => transition.From.Equals(state))
                            .ToHashSet());
        }

        private Machine(IDictionary<TState, HashSet<Transition<TState, TTransition>>> states, TState currentState) {
            this.states = states;
            this.CurrentState = currentState;
        }

        public Machine<TState, TTransition> Transition(TTransition item) {
            var it = 
                this.states[this.CurrentState]
                    .FirstOrDefault(edge => edge.When.Equals(item));

            return it != null
                ? new Machine<TState, TTransition>(this.states, it.To)
                : this;
        }
    }
}
