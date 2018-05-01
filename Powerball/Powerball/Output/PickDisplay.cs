using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riley.Powerball.BLL;

namespace Powerball.Output
{
    public class PickDisplay
    {
        public static void DisplayHeader()
        {
            Console.WriteLine("ID    |                Name                | First | Second | Third | Fourth | Fifth | Powerball |");
        }

        public static void DisplayPick(Pick p)
        {
            string line = "{0,-3} | {1,-35}|{2,4}   |{3,5}   |{4,4}   |{5,5}   |{6,4}   |{7,6}     |";
            Console.WriteLine("===============================================================================================|");
            Console.WriteLine(line, p.Identifier, p.Name, p.FirstBall, p.SecondBall, p.ThirdBall, p.FourthBall, p.FifthBall, p.PowerBall);
        }

        public static void DisplayWinningHeader()
        {
            Console.WriteLine("ID    |                Name                | First | Second | Third | Fourth | Fifth | Powerball | Count | Power? |        Winnings");
        }

        public static void DisplayWinningPick(Pick p)
        {
            string line = "{0,-5} | {1,-35}|{2,4}   |{3,5}   |{4,4}   |{5,5}   |{6,4}   |{7,6}     | {8,3}   | {9,5}  | ${10,15}";
            Console.WriteLine("=================================================================================================|--------------------------------");
            Console.WriteLine(line, p.Identifier, p.Name, p.FirstBall, p.SecondBall, p.ThirdBall, p.FourthBall, p.FifthBall, p.PowerBall, p.WinningBallCount, p.WinningPowerball, p.Winnings);
        }
    }
}
