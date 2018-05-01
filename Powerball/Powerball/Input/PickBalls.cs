using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riley.Powerball.BLL;
using Riley.Powerball.BLL.Validation;
using Powerball.Output;

namespace Powerball.Input
{
    public class PickBalls
    {
        public static Pick Create()
        {
            Console.Clear();
            Console.Write("Enter a name for this pick : ");
            string name = Console.ReadLine();

            List<int> numbers = new List<int>();
            int first = GetFirstFiveNumber("first");
            if (first > 100)
            {
                first -= 100;
                numbers.Add(first);
            }
            else
            {
                numbers.Add(first);
            }
            SecondToFifth(numbers, "second", 1);
            SecondToFifth(numbers, "third", 2);
            SecondToFifth(numbers, "fourth", 3);
            SecondToFifth(numbers, "fifth", 4);
            numbers.Add(GetPowerballNumber());

            Pick pick = new Pick();

            pick.Name = name;
            pick.FirstBall = numbers[0];
            pick.SecondBall = numbers[1];
            pick.ThirdBall = numbers[2];
            pick.FourthBall = numbers[3];
            pick.FifthBall = numbers[4];
            pick.PowerBall = numbers[5];

            return pick;
        }

        public static int GetFirstFiveNumber(string place)
        {
            Console.Clear();
            Prompt.FirstFiveInstructions();
            bool validOutput = false;
            int number = 0;
            while (!validOutput)
            {
                bool validInput = false;
                int output = 0;
                while (!validInput)
                {
                    Console.Write("Enter your " + place + " pick number : ");
                    string input = Console.ReadLine();
                    if (input.Equals("quickpick", StringComparison.CurrentCultureIgnoreCase))
                    {
                        number = QuickPick.RandomBall() + 100;
                        validInput = true;
                        validOutput = true;
                    }
                    else if (InputToInt(input))
                    {
                        output = int.Parse(input);
                        validInput = true;
                    }
                    else
                    {
                        Console.Clear();
                        Prompt.FirstFiveInstructions();
                        Console.WriteLine("That was not a number!");
                    }
                }
                if (Validate.ValidFirstFiveRange(output))
                {
                    number = output;
                    validOutput = true;
                }
                else
                {
                    Console.Clear();
                    Prompt.FirstFiveInstructions();
                    Console.WriteLine("That was not a number from 1 to 69!");
                }
            }
            return number;
        }

        public static int GetPowerballNumber()
        {
            Console.Clear();
            Prompt.PowerballInstructions();
            bool validInput = false;
            int number = 0;
            while (!validInput)
            {
                bool validOutput = false;
                int output = 0;
                while (!validOutput)
                {
                    Console.Write("Enter a number for your powerball : ");
                    string input = Console.ReadLine();
                    if (input.Equals("quickpick", StringComparison.CurrentCultureIgnoreCase))
                    {
                        number = QuickPick.RandomPowerball();
                        validInput = true;
                        validOutput = true;
                    }
                    else if (InputToInt(input))
                    {
                        output = int.Parse(input);
                        validOutput = true;
                    }
                    else
                    {
                        Console.Clear();
                        Prompt.PowerballInstructions();
                        Console.WriteLine("That was not a number!");
                    }
                }
                if (Validate.ValidPowerballRange(output))
                {
                    number = output;
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Prompt.PowerballInstructions();
                    Console.WriteLine("That was not a number from 1 to 26!");
                }
            }
            return number;
        }

        public static void SecondToFifth(List<int> numbers, string place, int index)
        {
            bool validBall = false;
            while (!validBall)
            {
                bool notQuickpick = false;
                int ball = GetFirstFiveNumber(place);
                if (Validate.IsQuickPick(ball))
                {
                    ball = QuickpickUntilRight(numbers, ball, index);
                    validBall = true;
                }
                else
                {
                    numbers.Add(ball);
                    notQuickpick = true;
                }

                while (notQuickpick)
                {
                    if (Validate.NoFirstFiveOverlap(numbers))
                    {
                        validBall = true;
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                        Console.WriteLine("You that was not a unique number!");
                    }
                }
            }
        }

        public static bool InputToInt(string input)
        {
            int output;
            return (int.TryParse(input, out output));
        }

        public static int QuickpickUntilRight(List<int> numbers, int ball, int index)
        {
            ball -= 100;
            bool validQuickpick = false;

            while (!validQuickpick)
            {
                numbers.Add(ball);
                if (Validate.NoFirstFiveOverlap(numbers))
                {
                    validQuickpick = true;
                }
                else
                {
                    numbers.RemoveAt(index);
                    ball = QuickPick.RandomBall();
                }
            }

            return ball;
        }
    }
}
