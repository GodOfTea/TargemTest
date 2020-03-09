using System;
using System.Collections.Generic;
using System.Linq;


namespace Calc.Classes
{
    class Calculate
    {
        private Stack<double> Numbers;
        private delegate double Operation(double x, double y);
        private Dictionary<string, Operation> _operations = new Dictionary<string, Operation>
        {
            {"+", ((x, y) => x + y)},
            {"-", ((x, y) => y - x)},
            {"*", ((x, y) => x * y)},
            {"/", ((x, y) => y / x)}
        };

        public double Result;
        

        public Calculate(List<string> input)
        {
            Numbers = new Stack<double>();
            double number;
            foreach (var symbol in input)
            {
                if (double.TryParse(symbol, out number) == true)
                {
                    Numbers.Push(number);
                }
                else
                {
                    number = _operations.Where(
                        p => p.Key == symbol).FirstOrDefault().Value(Numbers.Pop(), Numbers.Pop());
                    Numbers.Push(number);
                }
            }

            Result = Numbers.Peek();
            Console.WriteLine("Ответ: {0}", Result);
            Console.ReadKey();
        }
    }
}
