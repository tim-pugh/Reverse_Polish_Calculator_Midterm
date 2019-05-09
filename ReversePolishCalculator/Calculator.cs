using EnsureThat;
using System;

namespace ReversePolishCalculator
{
    public class Calculator
    {     
        public decimal Add(decimal first, decimal second)
        {  return first + second; }

        public decimal Subtract(decimal first, decimal second)
        { return first - second; }

        public decimal Multiply(decimal first, decimal second)
        { return first * second; }

        public decimal Divide(decimal first, decimal second)
        {
            Ensure.That(second, nameof(second)).IsNot(0);
            return first / second;
        }

        public decimal Power(decimal first, decimal second)
        { return (decimal)Math.Pow((double)first, (double)second); }       
    }
}
