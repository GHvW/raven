using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven {

    public static class Machine {

        public static Func<TState, TTransition, TState> ToMachineFn<TState, TTransition>(this StateGraph<TState, TTransition> stateGraph)
            where TState : notnull
            where TTransition : notnull => (state, transition) => {

                if (stateGraph.States.TryGetValue(state, out var transitions)) {
                    var it = transitions.FirstOrDefault(edge => edge.When.Equals(transition));

                    //return it?.To ?? state; // why doesn't this work?
                    return it != null
                        ? it.To
                        : state;
                }

                return state;
            };
    }
}
