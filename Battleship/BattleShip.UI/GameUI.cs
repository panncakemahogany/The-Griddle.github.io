using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameUI
    {
        public static void CommenceGame(Player playerOne, Player playerTwo,
                             BLL.GameLogic.Board boardOne, BLL.GameLogic.Board boardTwo)
        {
            DisplayManipulation.ResetDisplay(playerOne);
            DisplayManipulation.ResetDisplay(playerTwo);

            while (!playerOne.IsWinner && !playerTwo.IsWinner)
            {
                if (playerOne.OnTurn)
                {
                    Turn(playerOne, boardTwo);
                    playerTwo.OnTurn = true;
                }
                else
                {
                    Turn(playerTwo, boardOne);
                    playerOne.OnTurn = true;
                }

                DisplayManipulation.ShotHistoryDisplay(boardTwo, playerOne);
                DisplayManipulation.ShotHistoryDisplay(boardOne, playerTwo);
            }

            if (playerOne.IsWinner)
            {
                Console.Clear();
                Console.WriteLine(playerOne.Name + " IS VICTORIOUS!");
                Console.ReadLine();
            }
            else if (playerTwo.IsWinner)
            {
                Console.Clear();
                Console.WriteLine(playerTwo.Name + " IS VICTORIOUS!");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("SOMETHING WENT SERIOUSLY WRONG");
                Console.ReadLine();
            }
        }

        public static void Turn(Player player, BLL.GameLogic.Board board)
        {
            Console.ForegroundColor = player.Color;
            bool validShot = false;

            Console.Clear();
            Console.WriteLine(player.Name.ToUpper() + "'S TURN IS COMMENCING, SWITCH CONTROL NOW.");
            Console.WriteLine("PRESS ENTER TO CONTINUE.");
            Console.ReadLine();

            while (!validShot)
            {
                Console.Clear();
                player.ShowDisplay();

                string userInput = null;
                int[] coordRequest = new int[4];

                Console.Write("ENTER COORDINATES FOR FIRING A SHOT : ");
                userInput = Console.ReadLine();

                if (userInput.Length > 0)
                {
                    coordRequest = Decipher.CoordinateTranslator(userInput);
                }

                BLL.Requests.Coordinate shotDestination = new BLL.Requests.Coordinate(coordRequest[0], coordRequest[1]);

                BLL.Responses.FireShotResponse response = board.FireShot(shotDestination);

                switch (response.ShotStatus)
                {
                    case BLL.Responses.ShotStatus.Invalid:
                        Console.WriteLine("THAT SHOT WAS INVALID");
                        break;
                    case BLL.Responses.ShotStatus.Duplicate:
                        Console.WriteLine("YOU'VE ALREADY SHOT THERE");
                        break;
                    case BLL.Responses.ShotStatus.Miss:
                        validShot = true;
                        Console.WriteLine("THE SHOT MISSED!");
                        break;
                    case BLL.Responses.ShotStatus.Hit:
                        validShot = true;
                        Console.WriteLine("THE SHOT HIT!");
                        break;
                    case BLL.Responses.ShotStatus.HitAndSunk:
                        validShot = true;
                        Console.WriteLine("THE SHOT HIT AND SUNK THEIR " + response.ShipImpacted.ToUpper() + "!");
                        break;
                    case BLL.Responses.ShotStatus.Victory:
                        validShot = true;
                        player.IsWinner = true;
                        break;
                }

                Console.WriteLine("PRESS ENTER TO CONTINUE.");
                Console.ReadLine();
            }
            player.OnTurn = !player.OnTurn;
        }
    }
}
