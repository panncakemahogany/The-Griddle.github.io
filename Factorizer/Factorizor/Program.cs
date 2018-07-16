using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool guard = true;
            for (int i = 0; i < 100; i++)
            {
                int number = i;

                Calculator.PrintFactors(number);
                Calculator.IsPerfectNumber(number);
                Calculator.IsPrimeNumber(number);

                Console.WriteLine();
            }

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            int output;
            while (true)
            {
                Console.WriteLine("Enter any whole number to see its factors, if it's a perfect number, and if it's a prime number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That was not a whole number!");
                }
            }
            Console.ReadLine();

            //throw new NotImplementedException();
        }
    }
}
