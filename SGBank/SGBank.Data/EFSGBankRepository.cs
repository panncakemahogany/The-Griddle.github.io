using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class EFSGBankRepository : ISGBankRepository
    {
        public Account LoadAccount(string AccountNumber)
        {
            using (var context = new EFDbSGBankEntities())
            {
                return context.Accounts.FirstOrDefault(a => a.AccountNumber == AccountNumber);
            }
        }

        public void SaveAccount(Account account)
        {
            EFDbSGBankEntities entities = new EFDbSGBankEntities();
            entities.Accounts.Attach(account);
            entities.Entry(account).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public Customer LoadCustomer(string customerName)
        {
            using(var context = new EFDbSGBankEntities())
            {
                return context.Customers.FirstOrDefault(c => c.Name == customerName);
            }
        }

        public void SaveCustomer(Customer customer)
        {
            EFDbSGBankEntities entities = new EFDbSGBankEntities();
            entities.Customers.Attach(customer);
            entities.Entry(customer).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }
}
