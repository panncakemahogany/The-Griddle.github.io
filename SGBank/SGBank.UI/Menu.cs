using SGBank.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank Application");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Lookup a Customer");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch(userinput)
                {
                    case "1":
                        AccountLookupWorkflow accountLookupWorkflow = new AccountLookupWorkflow();
                        accountLookupWorkflow.Execute();
                        break;
                    case "2":
                        CustomerLookupWorkflow customerLookupWorkflow = new CustomerLookupWorkflow();
                        customerLookupWorkflow.Execute();
                        break;
                    case "3":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "4":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                    case "q":
                        return;
                }

            }

        }
    }
}
