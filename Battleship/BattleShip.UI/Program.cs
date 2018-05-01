using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(199, 50);
            Console.ForegroundColor = ConsoleColor.Cyan;

            Player playerOne = new Player();
            Player playerTwo = new Player();

            playerOne.Color = ConsoleColor.Green;
            playerTwo.Color = ConsoleColor.Red;

            MainMenu(playerOne, playerTwo);
        }

        static void MainMenu(Player playerOne, Player playerTwo)
        {
            Start screen = new Start();
            screen.Run();

            bool isRunning = true;

            while (isRunning)
            {
                //Start Game
                Console.Clear();
                screen.Title();
                Console.WriteLine("______________________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("                               ENTER 'PLAY' TO START A NEW GAME");
                Console.WriteLine("                               --------------------------------");
                Console.WriteLine("                               ENTER 'QUIT' TO EXIT THE PROGRAM");
                Console.WriteLine("                               ================================");
                Console.Write("                               ENTER YOUR COMMAND : ");
                string userInput = Console.ReadLine();

                if (userInput.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                {
                    isRunning = false;
                }
                else if (userInput.Equals("play", StringComparison.CurrentCultureIgnoreCase))
                {
                    bool playing = true;
                    
                    GetPlayerNames(playerOne, playerTwo);

                    while (playing)
                    {
                        GameSetUp.NewGame(playerOne, playerTwo);
                        playing = GameSetUp.PlayAgain();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ACCESS DENIED : INVALID ENTRY DETECTED");
                    Console.Write("PRESS RETURN TO RETRY COMMAND ENTRY");
                    Console.ReadLine();
                }
            }
        }

        static void GetPlayerNames(Player playerOne, Player playerTwo)
        {
            string nameInput;
            string verifyName;
            bool firstNameNotSet = true;
            bool secondNameNotSet = true;

            while (firstNameNotSet)
            {
                //Getting first name
                Console.Clear();
                Console.Write("ENTER FIRST PLAYER'S NAME : ");
                nameInput = Console.ReadLine();

                //Verifying first name
                Console.Clear();
                Console.WriteLine("YOUR PLAYER NAME WILL BE SET TO " + nameInput.ToUpper());
                Console.Write("IS THIS NAME OKAY? ENTER YES TO CONFIRM : ");
                verifyName = Console.ReadLine();

                if (verifyName.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                    verifyName.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    playerOne.Name = nameInput.ToUpper();
                    firstNameNotSet = false;
                }
            }

            while (secondNameNotSet)
            {
                //Getting second name
                Console.Clear();
                Console.Write("ENTER SECOND PLAYER'S NAME : ");
                nameInput = Console.ReadLine();

                //Verifying second name
                Console.Clear();
                Console.WriteLine("YOUR PLAYER NAME WILL BE SET TO " + nameInput.ToUpper());
                Console.Write("IS THIS NAME OKAY? ENTER YES TO CONFIRM : ");
                verifyName = Console.ReadLine();

                if (verifyName.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                    verifyName.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    playerTwo.Name = nameInput.ToUpper();
                    secondNameNotSet = false;
                }
            }
        }
    }
}
