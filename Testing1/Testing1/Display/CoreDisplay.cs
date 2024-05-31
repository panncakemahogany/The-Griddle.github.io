using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing1.Data;

namespace Testing1.Display
{
    internal class CoreDisplay
    {
        ConsoleColor foregroundColor { get; set; }
        ConsoleColor fackgroundColor { get; set; }
        bool errorState { get; set; }
        string errorMessage { get; set; }
        //open program read statuses and choose user
        public void StartMenu()
        {

        }
        //main menu
        public void MainMenu()
        {

        }
        //options
        public void OptionsMenu()
        {

        }
        //update options
        public void ChangeDisplayPreferences(OptionsData preferences)
        {

        }
        //select console routine/test
        public void SelectionMenu()
        {

        }
        //exit program
        public void ExitMenu()
        {
            if (errorState)
            {
                Console.WriteLine(errorMessage);
            }
            string userInput = UserStringInput();
        }
        //generalized error responses
        public void UserError()
        {
            Console.WriteLine(errorMessage);
        }
        //user input
        public string UserStringInput()
        {
            return Console.ReadLine();
        }
    }
}
