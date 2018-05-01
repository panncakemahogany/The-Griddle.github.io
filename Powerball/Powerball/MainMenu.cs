using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Powerball.Output;
using Powerball.Input;

namespace Powerball
{
    public class MainMenu
    {
        public static void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Prompt.MainMenuDisplay();
                bool validChoice = false;
                int number = 0;

                while (!validChoice)
                {
                    Console.Write("Make your selection : ");
                    string input = Console.ReadLine();
                    
                    if (input.Equals("updownupdownleftrightleftrightababselectstart", StringComparison.CurrentCultureIgnoreCase))
                    {
                        number = -1;
                        FastBalls konamiCode = new FastBalls();
                        konamiCode.GetFastBallsQuickNowGo();
                        validChoice = true;
                    }
                    else if (!int.TryParse(input, out number))
                    {
                        Console.Clear();
                        Prompt.MainMenuDisplay();
                        Console.WriteLine("That was not even a number!");
                    }
                    else if (number < 1 || number > 4)
                    {
                        Console.Clear();
                        Prompt.MainMenuDisplay();
                        Console.WriteLine("That was not a valid choice!");
                    }
                    else
                    {
                        validChoice = true;
                    }
                }

                switch (number)
                {
                    case 1:
                        MakePick selected = new MakePick();
                        selected.Create();
                        break;
                    case 2:
                        FindPick.FindPickByChoice();
                        break;
                    case 3:
                        DrawPick draw = new DrawPick();
                        draw.ShowWinners();
                        break;
                    case -1:
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
