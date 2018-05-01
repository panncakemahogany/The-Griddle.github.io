using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public override string ToString()
        {
            string type = null;

            switch (Type)
            {
                case AccountType.Free:
                    type = "F";
                    break;
                case AccountType.Basic:
                    type = "B";
                    break;
                case AccountType.Premium:
                    type = "P";
                    break;
            }

            return $"{AccountNumber},{Balance}," + type;
        }
    }
}
