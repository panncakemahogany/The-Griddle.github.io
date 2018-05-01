using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class EFDbSGBankEntities : DbContext
    {
        public EFDbSGBankEntities() : base("SGBank")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
