using System;
using Xunit;

namespace Raven.Test
{
    public record Thing<A>(A It, string Bull);

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Thing<string>? it = null;

            var result = it?.It;


            Assert.NotNull(result);
        }
    }
}
