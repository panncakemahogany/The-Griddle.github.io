using Riley.Powerball.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Powerball.Input;
using Powerball.Names;
using Riley.Powerball.BLL.PowerIO;

namespace Powerball.Input
{
    public class FastBalls
    {
        public void FastGrabQuickPick()
        {
            Pick pick = QuickPickLickitySplit(Name.GetName());

            PickRepository repo = new PickRepository();

            repo.ToFile(repo.Create(pick));
        }

        public void GetFastBallsQuickNowGo()
        {
            Console.Clear();
            bool validInput = false;
            int number = 0;

            while (!validInput)
            {
                Console.Write("Gimme a number : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Try again, Mr. Not-Smart");
                }
            }

            PickRepository repo = new PickRepository();
            List<Pick> allOfThem = new List<Pick>();

            for (int i = number; i > 0; i--)
            {
                Pick pick = QuickPickLickitySplit(Name.GetName());

                allOfThem.Add(pick);
            }

            foreach (Pick p in allOfThem)
            {
                repo.ToFile(repo.Create(p));
            }

            Console.Clear();
            Console.WriteLine("It is done.");
            Console.ReadLine();
        }

        public static Pick QuickPickLickitySplit(string name)
        {
            List<int> balls = new List<int>();

            balls.Add(QuickPick.RandomBall());
            PickBalls.QuickpickUntilRight(balls, QuickPick.RandomBall() + 100, 1);
            PickBalls.QuickpickUntilRight(balls, QuickPick.RandomBall() + 100, 2);
            PickBalls.QuickpickUntilRight(balls, QuickPick.RandomBall() + 100, 3);
            PickBalls.QuickpickUntilRight(balls, QuickPick.RandomBall() + 100, 4);

            Pick pick = new Pick();
            pick.Name = name;
            pick.FirstBall = balls[0];
            pick.SecondBall = balls[1];
            pick.ThirdBall = balls[2];
            pick.FourthBall = balls[3];
            pick.FifthBall = balls[4];
            pick.PowerBall = QuickPick.RandomPowerball();

            return pick;
        }
    }
}
