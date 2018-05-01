using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SGBank.Tests
//{
//    [TestFixture]
//    public class PremiumAccountTests
//    {
//        [Test]
//        [TestCase("66666", "Premium Account", 100, AccountType.Free, 250, false)]
//        [TestCase("66666", "Premium Account", 100, AccountType.Premium, -100, false)]
//        [TestCase("66666", "Premium Account", 100, AccountType.Premium, 250, true)]
//        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
//        {
//            IDeposit deposit = new NoLimitDepositRule();
//            Account account = new Account();

//            account.AccountNumber = accountNumber;
//            account.Name = name;
//            account.Balance = balance;
//            account.Type = accountType;

//            AccountDepositResponse actual = deposit.Deposit(account, amount);

//            Assert.AreEqual(expectedResult, actual.Success);
//        }

//        [Test]
//        [TestCase("66666", "Premium Account", 100, AccountType.Free, -100, 100, false)]
//        [TestCase("66666", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
//        [TestCase("66666", "Premium Account", 500, AccountType.Premium, -1500, 500, false)]
//        [TestCase("66666", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)]
//        [TestCase("66666", "Premium Account", 1000, AccountType.Premium, -1500, -500, true)]
//        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
//        {
//            IWithdraw withdrawal = new PremiumAccountWithdrawRule();
//            Account account = new Account();

//            account.AccountNumber = accountNumber;
//            account.Name = name;
//            account.Balance = balance;
//            account.Type = accountType;

//            AccountWithdrawReponse actual = withdrawal.Withdraw(account, amount);

//            Assert.AreEqual(expectedResult, actual.Success);
//        }
//    }
//}
