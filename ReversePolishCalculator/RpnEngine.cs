using System;
using System.Collections.Generic;
using System.Linq;
using FileLogger;

namespace ReversePolishCalculator
{
    public class RpnEngine
    {
        private readonly Stack<decimal> _stack;
        private readonly Calculator _calculator;

        private Logger _log;

        public RpnEngine()
        {
            _stack = new Stack<decimal>();
            _calculator = new Calculator();
            _log = new Logger(eLogLevel.Debug);
        }

        public void CalculateRpn()
        {
            var rpnTokens = SplitInput(Console.ReadLine());

            foreach (var rpnToken in rpnTokens)
            {
                _log.Debug(rpnToken);
                if (TryParseDecimal(rpnToken))
                { _stack.Push(decimal.Parse(rpnToken)); }
                else if(ValidRpnOperation(rpnToken))
                {
                    _stack.Push(Calculate(rpnToken, _stack));
                }
                else
                {
                    var message = $"Could not parse [{rpnToken}]";
                    _log.Fatal(message);
                    throw new ArgumentException(message, nameof(rpnToken));
                }
            }

            var result = _stack.Pop();
            _log.Debug($"Result of calculation is [{result}]");
            Console.WriteLine(result);
        }


        public string [] SplitInput(string input)
        {
            _stack.Clear();
            _log.Trace(input);
            return input.Split(' ');
        }

        public bool TryParseDecimal(string rpnToken)
        {
         return decimal.TryParse(rpnToken, out decimal number);
        }

        public bool ValidRpnOperation(string rpnOperation)
        {
            var operators = new List<string> { "*", "^", "/", "+", "-" };
            bool validOperator = operators.Contains(rpnOperation, StringComparer.OrdinalIgnoreCase);
            if (validOperator)
                return true;
            else
                return false;
        }

        public decimal Calculate(string rpnToken, Stack<decimal> _stack)
        {
            switch (rpnToken)
            {
                case "^":
                    var stackNumber = _stack.Pop();
                    return _calculator.Power(_stack.Pop(), stackNumber);
                case "*":
                    return _calculator.Multiply(_stack.Pop(), _stack.Pop());
                case "/":
                    stackNumber = _stack.Pop();
                    return _calculator.Divide(_stack.Pop(), stackNumber);
                case "+":
                    return _calculator.Add(_stack.Pop(), _stack.Pop());
                default:
                    stackNumber = _stack.Pop();
                    return _calculator.Subtract(_stack.Pop(), stackNumber);
            }
        }
    }
}
