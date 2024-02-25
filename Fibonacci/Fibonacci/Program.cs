using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, a = 0, b = 1, c = 0;
            Console.Write("Ingrese el número: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("0 1 ");

            for (int i = 2; i < n; i++)
            {
                c = a + b;
                Console.Write(c + " ");

                a = b;
                b = c;
            }
            Console.ReadKey();
        }
    }
}
