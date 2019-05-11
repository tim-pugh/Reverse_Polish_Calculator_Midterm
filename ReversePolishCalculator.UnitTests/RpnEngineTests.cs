using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using FakeItEasy;

namespace ReversePolishCalculator
{
    public class RpnEngineTests
    {
        [Fact]
        public void RpnEngine_SplitInput_Success()
        {
            var rpnEngine = new RpnEngine();

            var input = "3 5 +";
            string[] inputArray = new string[3];
            inputArray[0] = "3";
            inputArray[1] = "5";
            inputArray[2] = "+";


            var rpnTokens = rpnEngine.SplitInput(input);

            int count = rpnTokens.Length;

            rpnTokens.Should().Equal(inputArray, "Because these should be equal");
        }

        [Fact]
        public void RpnEngine_TryParseRpnToken_Success()
        {

            var rpnEngine = new RpnEngine();

            var input = "3 5";

            var rpnTokens = input.Split(' ');

            foreach(var rpnToken in rpnTokens)
            {
                var isDecimal = rpnEngine.TryParseDecimal(rpnToken);

                isDecimal.Should().BeTrue("It's set to true");
            }

        }

        [Fact]
        public void RpnEngine_TryParseRpnToken_Failure()
        {

            var rpnEngine = new RpnEngine();

            var input = "* * *";

            var rpnTokens = input.Split(' ');

            foreach (var rpnToken in rpnTokens)
            {
                var isDecimal = rpnEngine.TryParseDecimal(rpnToken);

                isDecimal.Should().BeFalse("It's set to false");
            }

        }
        [Fact]
        public void RpnEngine_ValidRpnOperation_Success()
        {
            var rpnEngine = new RpnEngine();

            var input = "^ * - / +";

            var rpnOperators = input.Split(' ');

            foreach (var rpnOperation in rpnOperators)
            {
                var isValidOperation = rpnEngine.ValidRpnOperation(rpnOperation);

                isValidOperation.Should().BeTrue("Because these are all valid rpn operations.");

            }
        }

        [Fact]
        public void RpnEngine_ValidRpnOperation_Failure()
        {
            var rpnEngine = new RpnEngine();

            var input = " 1 ! t < _";

            var rpnOperators = input.Split(' ');

            foreach (var rpnOperation in rpnOperators)
            {
                var isValidOperation = rpnEngine.ValidRpnOperation(rpnOperation);

                isValidOperation.Should().BeFalse("Because these are not valid rpn operations.");

            }
        }

        [Theory]
        [InlineData("3","3", "+")]
        [InlineData("-")]
        [InlineData("*")]
        [InlineData("/")]
        [InlineData("^")]
        public void RpnEngine_Calculate_Success(params string[] operation)
        {
            var rpnEngine = new RpnEngine();
            var _stack = new Stack<decimal>();

            _stack.Push(2);
            _stack.Push(2);

           // var calculation = rpnEngine.Calculate(operation, _stack);

            //calculation.Should().Be();

        }
    }


}
