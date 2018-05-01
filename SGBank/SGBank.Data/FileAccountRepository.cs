//using SGBank.Models;
//using SGBank.Models.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace SGBank.Data
//{
//    public class FileAccountRepository : IAccountRepository
//    {
//        public Account LoadAccount(string AccountNumber)
//        {
//            List<Account> accounts = AccountsFromFile();

//            foreach (Account a in accounts)
//            {
//                if (a.AccountNumber == AccountNumber)
//                {
//                    return a;
//                }
//                else
//                {
//                    continue;
//                }
//            }

//            return null;
//        }

//        public void SaveAccount(Account account, decimal amount)
//        {
//            string transaction = amount.ToString();

//            using (StreamWriter writer = new StreamWriter(Settings.BalanceFilePath, true))
//            {
//                writer.WriteLine($"{account.AccountNumber},{transaction}");
//            }
//        }

//        public List<Account> AccountsFromFile()
//        {
//            List<Account> accounts = new List<Account>();

//            using (StreamReader reader = new StreamReader(Settings.AccountFilePath))
//            {
//                reader.ReadLine();
//                string line;

//                while ((line = reader.ReadLine()) != null)
//                {
//                    string[] knowsAccount = line.Split(',');

//                    Account account = new Account();

//                    account.AccountNumber = knowsAccount[0];
//                    account.Name = knowsAccount[1];
//                    account.Balance = decimal.Parse(knowsAccount[2]);
//                    switch (knowsAccount[3])
//                    {
//                        case "F":
//                            account.Type = AccountType.Free;
//                            break;
//                        case "B":
//                            account.Type = AccountType.Basic;
//                            break;
//                        case "P":
//                            account.Type = AccountType.Premium;
//                            break;
//                    }

//                    accounts.Add(account);
//                }
//            }

//            foreach (Account a in accounts)
//            {
//                BalanceFromFile(a);
//            }

//            return accounts;
//        }

//        public void BalanceFromFile (Account account)
//        {
//            List<string[]> transactions = new List<string[]>();

//            using (StreamReader reader = new StreamReader(Settings.BalanceFilePath))
//            {
//                reader.ReadLine();
//                string line;

//                while ((line = reader.ReadLine()) != null)
//                {
//                    string[] knowsBalance = line.Split(',');
//                    transactions.Add(knowsBalance);
//                }
//            }

//            foreach (string[] transaction in transactions)
//            {
//                if (transaction[0] == account.AccountNumber)
//                {
//                    account.Balance += (decimal.Parse(transaction[1]));
//                }
//                else continue;
//            }
//        }
//    }
//}
