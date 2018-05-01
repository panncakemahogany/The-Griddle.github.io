using Riley.Powerball.BLL;
using Riley.Powerball.BLL.PowerIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Powerball.Output;

namespace Powerball.Input
{
    public class DrawPick
    {
        public void ShowWinners()
        {
            PickRepository repo = new PickRepository();
            Pick winningPick = GetWinningPick();
            List<Pick> winners = repo.FindBestMatches(winningPick).ToList();

            PickDisplay.DisplayWinningHeader();
            PickDisplay.DisplayWinningPick(winningPick);
            foreach(Pick p in winners)
            {
                PickDisplay.DisplayWinningPick(p);
            }
            Console.ReadLine();
        }

        public Pick GetWinningPick()
        {
            Pick winningBall = FastBalls.QuickPickLickitySplit("Winning Balls");
            winningBall.Winnings = QuickPick.RandomWinnings();
            winningBall.WinningBallCount = 6;
            winningBall.WinningPowerball = true;
            return winningBall;
        }
    }
}
