using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Interface
    {
        public void Run()
        {
            //Console.WriteLine("Enter any whole number to see its factors, if it's a perfect number, and if it's a prime number: ");
            Console.WriteLine("Enter number for correlating function. Enter Q to quit.");

            bool isRunning = true;

            while (isRunning)
            {
                int output;
                string input = Console.ReadLine();

                if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
                {
                    isRunning = false;
                }
                if (int.TryParse(input, out output))
                {
                    Calculator.PrintFactors(output);
                    Calculator.IsPerfectNumber(output);
                    Calculator.IsPrimeNumber(output);
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a whole number!");
                }
                Console.ReadLine();
            }
        }
    }
}
