using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.QueryInputs
{
    public class Alert
    {
        public static void AlertUserInvalidInput(Response response)
        {
            Console.Clear();
            Console.WriteLine(response.Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void OrderNumberNotOnList(int orderNumber)
        {
            Console.Clear();
            Console.WriteLine($"The order number {orderNumber} does not appear on file.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
