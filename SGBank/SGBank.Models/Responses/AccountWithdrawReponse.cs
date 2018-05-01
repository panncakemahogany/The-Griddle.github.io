using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Responses
{
    public class AccountWithdrawReponse : Response
    {
        public Account Account;
        public decimal OldBalance;
        public decimal Amount;
    }
}
