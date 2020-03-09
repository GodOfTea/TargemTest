using System;
using Calc.Classes;
using System.Data;


namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пример: ");
            string data = Console.ReadLine();

            DataTable dataTable = new DataTable();
            try
            {
                var value = dataTable.Compute(data, "");
            }
            catch
            {
                Console.WriteLine("Пример введен с ошибкой");
                Console.ReadKey();
                Environment.Exit(0);
            }

            ReversePolishNotation notation = new ReversePolishNotation(data);
            Calculate calculate = new Calculate(notation.Output);
        }
    }
}
