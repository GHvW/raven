using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven {

    public record Transition<TState, TTransition>(TState From, TState To, TTransition When) 
        where TState : notnull
        where TTransition : notnull;
}
