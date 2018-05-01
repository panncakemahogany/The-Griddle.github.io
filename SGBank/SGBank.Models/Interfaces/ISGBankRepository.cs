using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Interfaces
{
    public interface ISGBankRepository
    {
        Account LoadAccount(string AccountNumber);
        void SaveAccount(Account account);
        Customer LoadCustomer(string customerName);
        void SaveCustomer(Customer customer);
    }
}
