using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    public class GameSetUp
    {
        public static void NewGame(Player playerOne, Player playerTwo)
        {
            Random random = new Random();
            int whoIsFirst = random.Next(2);

            playerOne.IsWinner = false;
            playerTwo.IsWinner = false;

            BLL.GameLogic.Board playerOneBoard = new BLL.GameLogic.Board();
            BLL.GameLogic.Board playerTwoBoard = new BLL.GameLogic.Board();

            if (whoIsFirst == 0)
            {
                playerOne.OnTurn = true;
                playerTwo.OnTurn = false;
            }
            else
            {
                playerOne.OnTurn = false;
                playerTwo.OnTurn = true;
            }

            

            if (playerOne.OnTurn)
            {
                PlaceShips(playerOne, playerOneBoard);
                PlaceShips(playerTwo, playerTwoBoard);
                GameUI.CommenceGame(playerOne, playerTwo, playerOneBoard, playerTwoBoard);
            }
            else
            {
                PlaceShips(playerTwo, playerTwoBoard);
                PlaceShips(playerOne, playerOneBoard);
                GameUI.CommenceGame(playerOne, playerTwo, playerOneBoard, playerTwoBoard);
            }
        }

        public static bool PlayAgain()
        {
            string onceMore;

            Console.Clear();
            Console.Write("WOULD YOU LIKE TO PLAY AGAIN? ENTER YES TO BEGIN ANOTHER GAME : ");
            onceMore = Console.ReadLine();

            if (onceMore.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                onceMore.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PlaceShips(Player player, BLL.GameLogic.Board board)
        { 
            bool setUpAccepted = false;

            BLL.Requests.PlaceShipRequest[] finalPlacement = new BLL.Requests.PlaceShipRequest[5];

            while (!setUpAccepted)
            {
                BLL.GameLogic.Board scrapBoard = new BLL.GameLogic.Board();
                DisplayManipulation.ResetDisplay(player);

                int shipsLeft = 4;
                BLL.Ships.ShipType currentShip = new BLL.Ships.ShipType();

                while (shipsLeft > -1)
                {
                    bool validResponse = false;

                    switch (shipsLeft)
                    {
                        case 4:
                            currentShip = BLL.Ships.ShipType.Destroyer;
                            break;
                        case 3:
                            currentShip = BLL.Ships.ShipType.Submarine;
                            break;
                        case 2:
                            currentShip = BLL.Ships.ShipType.Cruiser;
                            break;
                        case 1:
                            currentShip = BLL.Ships.ShipType.Battleship;
                            break;
                        case 0:
                            currentShip = BLL.Ships.ShipType.Carrier;
                            break;
                    }

                    bool invalidShipPlacement = false;

                    while (!validResponse)
                    {
                        string userInput = null;

                        bool validCoord = false;
                        bool invalidFirstCoord = false;
                        bool invalidSecondCoord = false;
                        bool noEntry = false;

                        while (!validCoord)
                        {
                            Console.Clear();

                            player.ShipPlacementDisplay(player.Color);

                            if (invalidFirstCoord)
                            {
                                Console.WriteLine("INVALID FIRST COORDINATE ENTRY");
                            }
                            if (invalidSecondCoord)
                            {
                                Console.WriteLine("INVALID SECOND COORDINATE ENTRY");
                            }
                            if (invalidShipPlacement)
                            {
                                Console.WriteLine("YOU PLACED YOUR " + currentShip.ToString().ToUpper() + " IN A INVALID POSITION!");
                            }
                            if (noEntry)
                            {
                                Console.WriteLine("YOUR ENTRY LACKED COORDINATES ENTIRELY");
                            }

                            Console.Write("ENTER VALID COORDINATES FOR " + currentShip.ToString().ToUpper() + " PLACEMENT : ");
                            userInput = Console.ReadLine();

                            if (userInput.Length > 0)
                            {
                                string first = userInput.Substring(0, 1).ToUpper();
                                string second = userInput.Substring(1);

                                int firstCoord = first[0] - 'A' + 1;
                                int secondCoord;

                                if (userInput.Length < 2)
                                {
                                    invalidFirstCoord = true;
                                    invalidSecondCoord = true;
                                }
                                else if (!int.TryParse(second, out secondCoord))
                                {
                                    invalidSecondCoord = true;
                                    invalidFirstCoord = false;
                                }
                                else if (secondCoord < 1 || secondCoord > 10 && firstCoord < 1 || firstCoord > 10)
                                {
                                    invalidFirstCoord = true;
                                    invalidSecondCoord = true;
                                }
                                else if (firstCoord < 1 || firstCoord > 10)
                                {
                                    invalidFirstCoord = true;
                                    invalidSecondCoord = false;
                                }
                                else if (secondCoord < 1 || secondCoord > 10)
                                {
                                    invalidFirstCoord = false;
                                    invalidSecondCoord = true;
                                }
                                else
                                {
                                    validCoord = true;
                                }
                            }
                            else
                            {
                                noEntry = true;
                            }
                        }

                        int[] coordRequest = new int[4];

                        coordRequest = Decipher.CoordinateTranslator(userInput);

                        //switch (shipsLeft)
                        //{
                        //    case 4:
                        //        player.Display[coordRequest[2], coordRequest[3]] = "D";
                        //        break;
                        //    case 3:
                        //        player.Display[coordRequest[2], coordRequest[3]] = "S";
                        //        break;
                        //    case 2:
                        //        player.Display[coordRequest[2], coordRequest[3]] = "U";
                        //        break;
                        //    case 1:
                        //        player.Display[coordRequest[2], coordRequest[3]] = "B";
                        //        break;
                        //    case 0:
                        //        player.Display[coordRequest[2], coordRequest[3]] = "C";
                        //        break;
                        //}

                        BLL.Requests.Coordinate shipPlacementCoord = new BLL.Requests.Coordinate(coordRequest[0], coordRequest[1]);

                        string directionEntry = null;
                        bool validDirection = false;
                        BLL.Requests.ShipDirection shipDirection = new BLL.Requests.ShipDirection();

                        while (!validDirection)
                        {
                            Console.Clear();

                            player.ShipPlacementDisplay(player.Color);
                            bool invalidEntry = false;

                            if (invalidEntry)
                            {
                                Console.WriteLine("INVALID DIRECTION ENTRY");
                            }

                            Console.Write("ENTER VALID DIRECTION FOR SHIP PLACEMENT : ");
                            directionEntry = Console.ReadLine();
                            directionEntry = directionEntry.ToUpper();

                            switch (directionEntry)
                            {
                                case "UP":
                                    shipDirection = BLL.Requests.ShipDirection.Up;
                                    validDirection = true;
                                    break;
                                case "DOWN":
                                    shipDirection = BLL.Requests.ShipDirection.Down;
                                    validDirection = true;
                                    break;
                                case "LEFT":
                                    shipDirection = BLL.Requests.ShipDirection.Left;
                                    validDirection = true;
                                    break;
                                case "RIGHT":
                                    shipDirection = BLL.Requests.ShipDirection.Right;
                                    validDirection = true;
                                    break;
                                default:
                                    invalidEntry = true;
                                    Console.Clear();
                                    break;
                            }
                        }

                        //Decipher.PlaceShipDisplayAdjustment(player, coordRequest, directionEntry, shipsLeft);

                        BLL.Requests.PlaceShipRequest request = new BLL.Requests.PlaceShipRequest();
                        request.Coordinate = shipPlacementCoord;
                        request.Direction = shipDirection;
                        request.ShipType = currentShip;

                        if (scrapBoard.PlaceShip(request) == BLL.Responses.ShipPlacement.Ok)
                        {
                            finalPlacement[shipsLeft] = request;
                            validResponse = true;
                            Decipher.PlaceShipDisplayAdjustment(player, coordRequest, directionEntry, shipsLeft);
                            switch (shipsLeft)
                            {
                                case 4:
                                    player.Display[coordRequest[2], coordRequest[3]] = "D";
                                    break;
                                case 3:
                                    player.Display[coordRequest[2], coordRequest[3]] = "S";
                                    break;
                                case 2:
                                    player.Display[coordRequest[2], coordRequest[3]] = "U";
                                    break;
                                case 1:
                                    player.Display[coordRequest[2], coordRequest[3]] = "B";
                                    break;
                                case 0:
                                    player.Display[coordRequest[2], coordRequest[3]] = "C";
                                    break;
                            }
                            shipsLeft--;
                        }
                        else
                        {
                            invalidShipPlacement = true;
                        }
                    }
                }

                Console.Clear();

                player.ShipPlacementDisplay(player.Color);

                Console.Write("DO YOU ACCEPT YOUR CURRENT SHIP PLACEMENT? ENTER YES TO CONFIRM : ");
                string confirmPlacement = Console.ReadLine();

                if (confirmPlacement.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                    confirmPlacement.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    setUpAccepted = true;
                }
            }

            board.PlaceShip(finalPlacement[4]);
            board.PlaceShip(finalPlacement[3]);
            board.PlaceShip(finalPlacement[2]);
            board.PlaceShip(finalPlacement[1]);
            board.PlaceShip(finalPlacement[0]);
        }
    }
}
