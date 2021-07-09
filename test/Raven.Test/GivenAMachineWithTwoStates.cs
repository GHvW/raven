using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace Raven.Test {

    public class GivenAMachineWithTwoStates {


        private Machine<int, string> machine;

        public GivenAMachineWithTwoStates() {
            this.machine = new Machine<int, string>(
                states: new HashSet<int>() { 1, 10 }, 
                transitions: new HashSet<Transition<int, string>>() { new Transition<int, string>(1, 2, "go") }, 
                initialState: 1);
        }

        [Fact]
        public void WhenTransitioningFromTheInitialStateToTheNext() {
            var result = this.machine.Transition("go");

            // Then
            result.CurrentState.Should().Be(2);
        }

    }
}
