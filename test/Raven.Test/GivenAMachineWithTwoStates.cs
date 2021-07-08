using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace Raven.Test {

    public class GivenAMachineWithTwoStates {

        record Data(int From, int To, string When) : ITransition<string, int>;

        private Machine<int, string> machine;

        public GivenAMachineWithTwoStates() {
            this.machine = new Machine<int, string>(
                new HashSet<int>() { 1, 10 }, 
                new HashSet<ITransition<string, int>>() { new Data(1, 2, "go") }, 
                1);
        }

        [Fact]
        public void WhenTransitioningFromTheInitialStateToTheNext() {
            var result = this.machine.Transition("go");

            // Then
            result.CurrentState.Should().Be(2);
        }

    }
}
