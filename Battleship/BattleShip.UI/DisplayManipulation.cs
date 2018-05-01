using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class DisplayManipulation
    {
        public static void ResetDisplay(Player player)
        {
            string[,] display = new string[12, 24];
            string[] boardDefault = new string[12];

            boardDefault[0] = "_______________________";
            boardDefault[1] = "|A|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[2] = "|B|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[3] = "|C|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[4] = "|D|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[5] = "|E|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[6] = "|F|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[7] = "|G|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[8] = "|H|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[9] = "|I|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[10] = "|J|_|_|_|_|_|_|_|_|_|_|";
            boardDefault[11] = "  |1|2|3|4|5|6|7|8|9|10";

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 23; y++)
                {
                    display[x, y] = boardDefault[x].Substring(y, 1);
                }
            }

            player.Display = display;
        }

        public static void ShotHistoryDisplay(BLL.GameLogic.Board board, Player player)
        {

            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    BLL.Requests.Coordinate coordinate = new BLL.Requests.Coordinate(x, y);
                    BLL.Responses.ShotHistory shot = board.CheckCoordinate(coordinate);
                    if (shot == BLL.Responses.ShotHistory.Hit)
                    {
                        player.Display[x, (y * 2) + 1] = "H";
                    }
                    else if (shot == BLL.Responses.ShotHistory.Miss)
                    {
                        player.Display[x, (y * 2) + 1] = "M";
                    }
                    else
                    {
                        player.Display[x, (y * 2) + 1] = "_";
                    }
                }
            }
        }
    }
}
