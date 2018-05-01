using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerball.Output
{
    class Prompt
    {
        public static void MainMenuDisplay()
        {
            Console.WriteLine("_________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|           POWERBALL           |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|           MAIN MENU           |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|===============================|");
            Console.WriteLine("|                               |");
            Console.WriteLine("| ENTER NUMBER TO SELECT OPTION |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|       1 - ENTER A PICK.       |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|        2 - SHOW A PICK.       |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|           3 - DRAW!           |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|           4 - QUIT.           |");
            Console.WriteLine("|_______________________________|");
        }

        public static void FirstFiveInstructions()
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|    ENTER A STANDARD BALL NUMBER   |");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|    ENTER A NUMBER FROM 1 TO 69    |");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|                                   |");
            Console.WriteLine("| THE NUMBER MUST BE A UNIQUE ENTRY |");
            Console.WriteLine("| FOR EACH OF THE FIRST FIVE BALLS. |");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|   ENTER 'QUICKPICK' TO GENERATE   |");
            Console.WriteLine("|       A RANDOM VALID NUMBER       |");
            Console.WriteLine("|___________________________________|");
        }

        public static void PowerballInstructions()
        {
            Console.WriteLine("_______________________________");
            Console.WriteLine("|                             |");
            Console.WriteLine("|   ENTER A POWERBALL NUMBER  |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("|                             |");
            Console.WriteLine("| ENTER A NUMBER FROM 1 TO 26 |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("|                             |");
            Console.WriteLine("|  THE NUMBER ISN'T REQUIRED  |");
            Console.WriteLine("|        TO BE UNIQUE.        |");
            Console.WriteLine("|_____________________________|");
        }

        public static void FindPickByChoiceDisplay()
        {
            Console.WriteLine("_________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("| ENTER NUMBER TO SELECT OPTION |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|        1 - SEARCH BY ID       |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|                               |");
            Console.WriteLine("|       2 - SEARCH BY NAME      |");
            Console.WriteLine("|_______________________________|");
        }
    }
}
