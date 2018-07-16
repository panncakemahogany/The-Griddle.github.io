using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            //TODO:  Implement FizzBuzz
            int top;
            top = 100;
            for (int num = 1; num <= top; num++)
            {
                Console.Write(num + " ");
                if (num % 3 == 0 && num % 5 == 0)
                {
                    Console.Write("FizzBuzz");
                }
                else if (num % 3 == 0)
                {
                    Console.Write("Fizz");
                }
                else if (num % 5 == 0)
                {
                    Console.Write("Buzz");
                }
                Console.WriteLine();
            }
        }
    }
}
