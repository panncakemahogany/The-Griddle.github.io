using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riley.Powerball.BLL
{
    public class QuickPick
    {
        static Random rng = new Random();

        public static int RandomBall()
        {
            return rng.Next(1, 70);
        }

        public static int RandomPowerball()
        {
            return rng.Next(1, 27);
        }

        public static decimal RandomWinnings()
        {
            decimal winnings = rng.Next(int.MaxValue) * rng.Next(int.MaxValue);
            return winnings;
        }
    }
}
