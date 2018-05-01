using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riley.Powerball.BLL.PowerIO;
using Riley.Powerball.BLL;
using Powerball.Output;

namespace Powerball.Input
{
    public class FindPick
    {
        public static void FindPickByChoice()
        {
            Console.Clear();
            Prompt.FindPickByChoiceDisplay();
            bool validChoice = false;

            while (!validChoice)
            {
                Console.Write("Enter your choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindPickByID();
                        validChoice = true;
                        break;
                    case "2":
                        FindPickByName();
                        validChoice = true;
                        break;
                    default:
                        Console.Clear();
                        Prompt.FindPickByChoiceDisplay();
                        Console.WriteLine("That was not a valid choice!");
                        break;
                }
            }
        }

        public static void FindPickByID()
        {
            Console.Clear();
            int identifier = 0;
            bool validIdentifier = false;

            while (!validIdentifier)
            {
                Console.Write("Enter a three digit ID number to display pick : ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out identifier))
                {
                    Console.Clear();
                    Console.WriteLine("That was not even a number!");
                }
                else if (identifier < 100 || identifier > 999)
                {
                    Console.Clear();
                    Console.WriteLine("That was not a three digit number!");
                }
                else
                {
                    validIdentifier = true;
                }
            }

            PickRepository pickFinder = new PickRepository();
            Pick result = pickFinder.FindById(identifier);

            if (result.Identifier < 100 || result.Identifier > 999)
            {
                Console.Clear();
                Console.WriteLine("That ID is not linked to any existing pick.");
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the Main Menu.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                PickDisplay.DisplayHeader();
                PickDisplay.DisplayPick(result);
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the Main Menu.");
                Console.ReadLine();
            }
        }

        public static void FindPickByName()
        {
            Console.Clear();
            Console.Write("Enter name of pick owner : ");
            string name = Console.ReadLine();

            PickRepository pickFinder = new PickRepository();
            List<Pick> results = pickFinder.FindByName(name);

            if (results.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("That name is not currently the owner of any existing pick.");
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the Main Menu.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                PickDisplay.DisplayHeader();
                foreach (Pick result in results)
                {
                    PickDisplay.DisplayPick(result);
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the Main Menu.");
                Console.ReadLine();
            }
        }
    }
}
