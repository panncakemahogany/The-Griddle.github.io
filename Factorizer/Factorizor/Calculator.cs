using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Calculator
    {
        /// Given a number, print the factors per the specification
        public static void PrintFactors(int number)
        {
            for (int factor = 1; factor <= number; factor++)
            {
                if (number % factor == 0 && factor != number)
                {
                    if (factor == 1)
                    {
                        Console.Write("Factors : " + factor + ", ");
                    }
                    else
                    {
                        Console.Write(factor + ", ");
                    }

                }
                else if (number == factor)
                {
                    Console.Write(factor + ". ");
                }
            }
        }

        /// Given a number, print if it is perfect or not
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int factor = 1; factor < number; factor++)
            {
                if (number % factor == 0)
                {
                    sum += factor;
                }
            }
            if (sum == number)
            {
                Console.Write("This number is a Perfect Number! ");
            }
            else
            {
                Console.Write("This number is not a Perfect Number. ");
            }
        }

        /// Given a number, print if it is prime or not
        public static void IsPrimeNumber(int number)
        {
            int rule = 0;
            for (int factor = 1; factor < number; factor++)
            {
                if (number % factor == 0)
                {
                    rule += factor;
                }
            }
            if (rule == 1)
            {
                Console.Write("This number is a Prime Number!");
            }
            else
            {
                Console.Write("This number is not a Prime Number.");
            }
        }
    }
}
