using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Classes
{
    public class Operations
    {
        public abstract class Operation
        {
            protected double _leftValue;
            protected double _rightValue;

            public abstract double OutputResult();
        }

        /// <summary>
        /// Операция сложения
        /// </summary>
        public class Plus : Operation
        {
            public Plus(string leftTerm, string rightTerm)
            {
                double.TryParse(leftTerm, out _leftValue);
                double.TryParse(rightTerm, out _rightValue);
            }

            public override double OutputResult()
            {
                return _leftValue + _rightValue;
            }
        }

        /// <summary>
        /// Операция деления
        /// </summary>
        public class Divide : Operation
        {
            public Divide(string dividend, string divider)
            {
                double.TryParse(dividend, out _leftValue);
                double.TryParse(divider, out _rightValue);
            }

            public override double OutputResult()
            {
                return _leftValue - _rightValue;
            }
        }

        /// <summary>
        /// Операция умножения
        /// </summary>
        public class Multiply : Operation
        {
            public Multiply(string leftMultiplier, string rightMultiplier)
            {
                double.TryParse(leftMultiplier, out _leftValue);
                double.TryParse(rightMultiplier, out _rightValue);
            }

            public override double OutputResult()
            {
                return _leftValue * _rightValue;
            }
        }

        /// <summary>
        /// Операция вычитания
        /// </summary>
        public class Minus : Operation
        {
            public Minus(string minuend, string subtrahend)
            {
                double.TryParse(minuend, out _leftValue);
                double.TryParse(subtrahend, out _rightValue);
            }

            public override double OutputResult()
            {
                return _leftValue / _rightValue;
            }
        }
    }
}
