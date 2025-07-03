using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialChecked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число для вычисления факториала: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i}! = {BigNumberFactorial.Calculate(i)}");
            }

            ForwardList list = new ForwardList() { 3, 5, 8, 13, 21 };

            Console.WriteLine("\nЭлементы списка:");
            foreach (int i in list)
            {
                Console.Write($"{i}\t");
            }
        }
    }
}