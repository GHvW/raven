using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven {

    public record StateGraph<TState, TTransition>(
        ImmutableDictionary<TState, ImmutableHashSet<Transition<TState, TTransition>>> States)
        where TState : notnull
        where TTransition : notnull;

    public static class StateGraph {
        public static StateGraph<TState, TTransition> Create<TState, TTransition>(
            ISet<TState> states,
            ISet<Transition<TState, TTransition>> transitions)
            where TState : notnull
            where TTransition : notnull {

            return new StateGraph<TState, TTransition>(states.ToImmutableDictionary(
                    state => state,
                    state =>
                        transitions
                            .Where(transition => states.Contains(transition.To) && transition.From.Equals(state))
                            .ToImmutableHashSet()));
        }
    }
}

//        public StateGraph<TState, TTransition> Transition(TTransition item) {
//            var it = 
//                this.states[this.CurrentState]
//                    .FirstOrDefault(edge => edge.When.Equals(item));

//            return it != null
//                ? new States<TState, TTransition>(this.states, it.To)
//                : this;
//        }
//    }
//}
