using FluentAssertions;
using Xunit;
using System;


namespace ReversePolishCalculator
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Add(first, second);
            result.Should().Be(24, "Because addition...");
        }

        [Fact]
        public void Calculator_Subtract_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Subtract(first, second);
            result.Should().Be(0, "Because subtraction...");
        }

        [Fact]
        public void Calculator_Multiply_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Multiply(first, second);
            result.Should().Be(144, "Because multiplication...");
        }

        [Fact]
        public void Calculator_Divide_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Divide(first, second);
            result.Should().Be(1, "Because division...");
        }

        [Fact]
        public void Calculator_Divide_By_Zero_Success()
        {
            var calc = new Calculator();
            Action action = () => calc.Divide(10000, 0);
            action.Should().Throw <ArgumentException> ();
        }

        [Fact]
        public void Calculator_Power_Success()
        {
            var calc = new Calculator();
            var first = 10;
            var second = 10;
            var result = calc.Power(first, second);
            result.Should().Be(10000000000, "Because taking it to the power of...");
        }

    }
}
