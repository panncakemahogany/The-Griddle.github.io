using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number : {account.AccountNumber}");
            Console.WriteLine("Customer[s]");
            Console.WriteLine("==================================");
            foreach (Customer c in account.Customers)
            {
                Console.WriteLine($"ID : {c.CustomerID} | Name : {c.Name}");
            }
            Console.WriteLine($"Balance : {account.Balance:c}");
        }

        public static void DisplayCustomerDetails(Customer customer)
        {
            Console.WriteLine($"Name : {customer.Name}");
            Console.WriteLine($"Address : {customer.StreetAddress}");
            Console.WriteLine($"City : {customer.City}");
            Console.WriteLine($"State : {customer.State}");
            Console.WriteLine("Account[s]");
            Console.WriteLine("==================================");
            foreach (Account a in customer.Accounts)
            {
                Console.WriteLine($"Account Number : {a.AccountNumber} | Balance : {a.Balance:c}");
            }
        }
    }
}
