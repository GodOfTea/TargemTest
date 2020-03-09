using System;
using System.Collections.Generic;


namespace Calc.Classes
{
    class ReversePolishNotation
    {
        //private Dictionary<string, Operations> Operators;

        private Stack<string>   _operStack;
        private string          _data;

        public List<string> Output;


        public ReversePolishNotation(string data)
        {
            Output     = new List<string>();
            _operStack = new Stack<string>();

            _data = data;
            Filter();
        }

        public void Filter()
        {
            _data = _data.Replace(" ", "");

            for (int i = 0; i < _data.Length; i++)
            {
                int number;
                if (int.TryParse(_data[i].ToString(), out number) == true)
                {
                    i = Number(i);
                }
                else
                {
                    Operator(i);
                }
            }

            while (_operStack.Count > 0)
                Output.Add(_operStack.Pop());
        }

        private int Number(int start)
        {
            int pos = start;
            double number = 0;
            while (pos < _data.Length && (char.IsDigit(_data[pos]) || _data[pos] == ','))
            {
                ++pos;
            }

            try
            {
                number = double.Parse(_data.Substring(start, pos - start));
            }
            catch
            {
                Console.WriteLine("Error Messege");
            }

            Output.Add(number.ToString());

            return pos-1; /* Проверить */
        }

        /* Пока без отрицательных значений */
        private void Operator(int index)
        {
            if (_data[index] == '(')
            {
                _operStack.Push(_data[index].ToString());
            }
            else if (_data[index] == ')')
            {
                string oper = _operStack.Pop();

                while (oper != "(")
                {
                    Output.Add(oper);
                    oper = _operStack.Pop();
                }
            }
            else
            {
                if (_operStack.Count > 0 &&
                    Priorities(_data[index].ToString()) <= Priorities(_operStack.Peek()))
                {
                    Output.Add(_operStack.Pop());
                }

                _operStack.Push(_data[index].ToString());
            }
        }

        private int Priorities(string oper)
        {
            if (oper == "(" || oper == ")") return 0;
            if (oper == "+" || oper == "-") return 1;
            if (oper == "*" || oper == "/") return 2;

            return -1;
        }
    }
}
