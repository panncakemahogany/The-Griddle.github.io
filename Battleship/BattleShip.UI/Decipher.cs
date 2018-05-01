using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Decipher
    {
        public static int[] CoordinateTranslator(string userInput)
        {
            int[] translation = new int[4];
            
            string first = userInput.Substring(0, 1).ToUpper();
            string second = userInput.Substring(1);

            int firstCoord = first[0] - 'A' + 1;
            int secondCoord;

            if (!int.TryParse(second, out secondCoord))
            {
                Console.WriteLine("Could not interpret second coordinate");
            }

            int secondDisplay = 0;

            switch (first)
            {
                case "A":
                    secondDisplay = 1;
                    break;
                case "B":
                    secondDisplay = 2;
                    break;
                case "C":
                    secondDisplay = 3;
                    break;
                case "D":
                    secondDisplay = 4;
                    break;
                case "E":
                    secondDisplay = 5;
                    break;
                case "F":
                    secondDisplay = 6;
                    break;
                case "G":
                    secondDisplay = 7;
                    break;
                case "H":
                    secondDisplay = 8;
                    break;
                case "I":
                    secondDisplay = 9;
                    break;
                case "J":
                    secondDisplay = 10;
                    break;
            }

            int firstDisplay = 0;

            switch (secondCoord)
            {
                case 1:
                    firstDisplay = 3;
                    break;
                case 2:
                    firstDisplay = 5;
                    break;
                case 3:
                    firstDisplay = 7;
                    break;
                case 4:
                    firstDisplay = 9;
                    break;
                case 5:
                    firstDisplay = 11;
                    break;
                case 6:
                    firstDisplay = 13;
                    break;
                case 7:
                    firstDisplay = 15;
                    break;
                case 8:
                    firstDisplay = 17;
                    break;
                case 9:
                    firstDisplay = 19;
                    break;
                case 10:
                    firstDisplay = 21;
                    break;
            }

            translation[0] = firstCoord;
            translation[1] = secondCoord;
            translation[2] = secondDisplay;
            translation[3] = firstDisplay;

            return translation;
        }

        public static void PlaceShipDisplayAdjustment(Player player, int[] coordRequest, string directionEntry, int shipsLeft)
        {
            if (directionEntry == "UP")
            {
                switch (shipsLeft)
                {
                    case 4:
                        player.Display[coordRequest[2] - 1, coordRequest[3]] = "D";
                        break;
                    case 3:
                        player.Display[coordRequest[2] - 1, coordRequest[3]] = "S";
                        player.Display[coordRequest[2] - 2, coordRequest[3]] = "S";
                        break;
                    case 2:
                        player.Display[coordRequest[2] - 1, coordRequest[3]] = "U";
                        player.Display[coordRequest[2] - 2, coordRequest[3]] = "U";
                        break;
                    case 1:
                        player.Display[coordRequest[2] - 1, coordRequest[3]] = "B";
                        player.Display[coordRequest[2] - 2, coordRequest[3]] = "B";
                        player.Display[coordRequest[2] - 3, coordRequest[3]] = "B";
                        break;
                    case 0:
                        player.Display[coordRequest[2] - 1, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] - 2, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] - 3, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] - 4, coordRequest[3]] = "C";
                        break;
                }
            }
            else if (directionEntry == "DOWN")
            {
                switch (shipsLeft)
                {
                    case 4:
                        player.Display[coordRequest[2] + 1, coordRequest[3]] = "D";
                        break;
                    case 3:
                        player.Display[coordRequest[2] + 1, coordRequest[3]] = "S";
                        player.Display[coordRequest[2] + 2, coordRequest[3]] = "S";
                        break;
                    case 2:
                        player.Display[coordRequest[2] + 1, coordRequest[3]] = "U";
                        player.Display[coordRequest[2] + 2, coordRequest[3]] = "U";
                        break;
                    case 1:
                        player.Display[coordRequest[2] + 1, coordRequest[3]] = "B";
                        player.Display[coordRequest[2] + 2, coordRequest[3]] = "B";
                        player.Display[coordRequest[2] + 3, coordRequest[3]] = "B";
                        break;
                    case 0:
                        player.Display[coordRequest[2] + 1, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] + 2, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] + 3, coordRequest[3]] = "C";
                        player.Display[coordRequest[2] + 4, coordRequest[3]] = "C";
                        break;
                }
            }
            else if (directionEntry == "LEFT")
            {
                switch (shipsLeft)
                {
                    case 4:
                        player.Display[coordRequest[2], coordRequest[3] - 2] = "D";
                        break;
                    case 3:
                        player.Display[coordRequest[2], coordRequest[3] - 2] = "S";
                        player.Display[coordRequest[2], coordRequest[3] - 4] = "S";
                        break;
                    case 2:
                        player.Display[coordRequest[2], coordRequest[3] - 2] = "U";
                        player.Display[coordRequest[2], coordRequest[3] - 4] = "U";
                        break;
                    case 1:
                        player.Display[coordRequest[2], coordRequest[3] - 2] = "B";
                        player.Display[coordRequest[2], coordRequest[3] - 4] = "B";
                        player.Display[coordRequest[2], coordRequest[3] - 6] = "B";
                        break;
                    case 0:
                        player.Display[coordRequest[2], coordRequest[3] - 2] = "C";
                        player.Display[coordRequest[2], coordRequest[3] - 4] = "C";
                        player.Display[coordRequest[2], coordRequest[3] - 6] = "C";
                        player.Display[coordRequest[2], coordRequest[3] - 8] = "C";
                        break;
                }
            }
            else
            {
                switch (shipsLeft)
                {
                    case 4:
                        player.Display[coordRequest[2], coordRequest[3] + 2] = "D";
                        break;
                    case 3:
                        player.Display[coordRequest[2], coordRequest[3] + 2] = "S";
                        player.Display[coordRequest[2], coordRequest[3] + 4] = "S";
                        break;
                    case 2:
                        player.Display[coordRequest[2], coordRequest[3] + 2] = "U";
                        player.Display[coordRequest[2], coordRequest[3] + 4] = "U";
                        break;
                    case 1:
                        player.Display[coordRequest[2], coordRequest[3] + 2] = "B";
                        player.Display[coordRequest[2], coordRequest[3] + 4] = "B";
                        player.Display[coordRequest[2], coordRequest[3] + 6] = "B";
                        break;
                    case 0:
                        player.Display[coordRequest[2], coordRequest[3] + 2] = "C";
                        player.Display[coordRequest[2], coordRequest[3] + 4] = "C";
                        player.Display[coordRequest[2], coordRequest[3] + 6] = "C";
                        player.Display[coordRequest[2], coordRequest[3] + 8] = "C";
                        break;
                }
            }
        }
    }
}
