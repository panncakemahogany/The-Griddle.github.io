using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.QueryInputs
{
    public class Query
    {
        public static string GetDateFromUser()
        {
            Console.Clear();
            Console.Write("Enter a date in MM/DD/YYYY format : ");
            string input = Console.ReadLine();

            return input;
        }

        public static string GetOrderNumberFromUser()
        {
            Console.Clear();
            Console.Write("Enter the order number of order you wish to select : ");
            string input = Console.ReadLine();

            return input;
        }

        public static string GetNameFromUser()
        {
            Console.Clear();
            Console.Write("Enter a name for this order : ");
            string input = Console.ReadLine();

            return input;
        }

        public static string GetProductFromUser()
        {
            Console.Clear();
            Instructions.ListAvailableProducts();
            Console.Write("Enter either the number or product name to select a product for this order : ");
            string input = Console.ReadLine();

            return input;
        }

        public static string GetTaxesFromUser()
        {
            Console.Clear();
            Console.Write("Enter a state for this order : ");
            string input = Console.ReadLine();

            return input;
        }

        public static string GetAreaFromUser()
        {
            Console.Clear();
            Console.Write("Enter an area value for this order : ");
            string input = Console.ReadLine();

            return input;
        }
    }
}
