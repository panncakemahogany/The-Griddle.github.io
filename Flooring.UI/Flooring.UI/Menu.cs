using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.UI.Workflows;

namespace Flooring.UI
{
    public class Menu
    {
        public static void Run()
        {
            bool isRunning = true;
            int alertStatus = 0;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("**************************************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine();
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit program");
                Console.WriteLine();
                Console.WriteLine("**************************************************");

                switch (alertStatus)
                {
                    case 1:
                        Console.WriteLine("Invalid input! Enter number to select menu option.");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }

                alertStatus = 0;

                Console.Write("Enter command : ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrdersWorkflow display = new DisplayOrdersWorkflow();
                        display.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow add = new AddOrderWorkflow();
                        add.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow edit = new EditOrderWorkflow();
                        edit.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow remove = new RemoveOrderWorkflow();
                        remove.Execute();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        alertStatus = 1;
                        break;
                }
            }
        }
    }
}
