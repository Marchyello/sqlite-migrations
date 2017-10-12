using System;
using Xunit;
using dummyDb.Services;

namespace test_dummyDb
{
    public class InitialTest
    {
        private IUselessity uselessity;
        public InitialTest()
        {
            this.uselessity = new Uselessity();
        }

        [Fact]
        public void Test1()
        {
            string input = "input";
            string expected = "input_UselessityServedYou";

            Assert.Equal(expected, uselessity.Serve(input));
        }
    }
}
