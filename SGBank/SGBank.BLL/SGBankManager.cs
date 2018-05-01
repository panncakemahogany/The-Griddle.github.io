using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class SGBankManager
    {
        private ISGBankRepository sgBankRepository;

        public SGBankManager(ISGBankRepository sqlRepository)
        {
            sgBankRepository = sqlRepository;
        }

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = sgBankRepository.LoadAccount(accountNumber);

            if(response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public CustomerLookupResponse LookupCustomer(string customerName)
        {
            CustomerLookupResponse response = new CustomerLookupResponse();

            response.Customer = sgBankRepository.LoadCustomer(customerName);

            if (response.Customer == null)
            {
                response.Success = false;
                response.Message = $"{customerName} is not a registered customer of SGBank.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = sgBankRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.Success)
            {
                sgBankRepository.SaveAccount(response.Account);
            }

            return response;
        }

        public AccountWithdrawReponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawReponse response = new AccountWithdrawReponse();

            response.Account = sgBankRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);

            if (response.Success)
            {
                amount = response.Amount;
                sgBankRepository.SaveAccount(response.Account);
            }

            return response;
        }
    }
}
