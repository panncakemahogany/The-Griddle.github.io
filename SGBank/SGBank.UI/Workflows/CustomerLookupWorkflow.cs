using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class CustomerLookupWorkflow
    {
        public void Execute()
        {
            SGBankManager manager = SGBankManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup a customer");
            Console.WriteLine("--------------------------");
            Console.Write("Enter a customer name : ");
            string customerName = Console.ReadLine();

            CustomerLookupResponse response = manager.LookupCustomer(customerName);

            if (response.Success)
            {
                ConsoleIO.DisplayCustomerDetails(response.Customer);
            }
            else
            {
                Console.WriteLine("An error occurred : ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
