using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace Raven.Test {

    public class GivenAStateGraphWithTwoStates {


        private StateGraph<int, string> machine;

        public GivenAStateGraphWithTwoStates() {
            this.machine = StateGraph.Create<int, string>(
                states: new HashSet<int>() { 1, 10 }, 
                transitions: new HashSet<Transition<int, string>>() { 
                    new Transition<int, string>(1, 10, "go"),
                    new Transition<int, string>(10, 1, "back") 
                });
        }

        [Fact]
        public void WhenTransitioningFromTheInitialStateToTheNext() {
            //var result = this.machine.Transition("go");
            var machineFn = this.machine.ToMachineFn();

            var firstResult = machineFn(1, "go");
            // Then
            firstResult.Should().Be(10);

            var secondResult = machineFn(10, "back");

            secondResult.Should().Be(1);
        }


        [Fact]
        public void WhenTransitioningFromTheInitialStateToTheNextViaIEnumerablePlayback() {
            //var result = this.machine.Transition("go");
            var commands = new string[] { "go", "back", "go" };
            var machineFn = this.machine.ToMachineFn();


            var result = commands.Aggregate(1, machineFn);

            result.Should().Be(10);
        }
    }
}
