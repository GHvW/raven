using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven {

    public interface ITransition<TItem, TState> {
        public TState From { get; }
        public TState To { get; }
        public TItem When { get; }
    }
}
