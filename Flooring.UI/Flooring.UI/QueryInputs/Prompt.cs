using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.QueryInputs
{
    public class Prompt
    {
        public static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static bool ConfirmChanges(int board)
        {
            switch (board)
            {
                case 1:
                    Console.Write("Do you want to save this order? : ");
                    break;
                case 2:
                    Console.Write("Do you want to save your changes to this order? : ");
                    break;
                case 3:
                    Console.Write("Do you want to remove this order? : ");
                    break;
                default:
                    Console.WriteLine("ERROR : BOARD VALUE UNASSIGNED, DEVELOPER ISSUE");
                    break;
            }

            string userInput = Console.ReadLine();

            return InterpretYesOrNo(userInput);
        }
        
        public static bool IsUserSure()
        {
            Console.Clear();
            Console.Write("Are you sure? : ");
            string userInput = Console.ReadLine();

            return InterpretYesOrNo(userInput);
        }

        public static bool InterpretYesOrNo(string userInput)
        {
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "Y":
                    return true;
                case "YES":
                    return true;
                case "SURE":
                    return true;
                case "YUP":
                    return true;
                case "AFFIRMATIVE":
                    return true;
                default:
                    return false;
            }
        }
    }
}
