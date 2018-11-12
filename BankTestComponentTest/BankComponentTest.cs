// standard unit tests using MSTest

using System;
using Bank;

using Microsoft.VisualStudio.TestTools.UnitTesting;                         // unit testing

namespace BankTestComponentTest 
{
    /// <summary>
    /// These component tests attempt to test units that work closely together to complete an action
    /// </summary>
    [TestClass]                                                             // a class containing unit tests
    public class BankUnitTest
    {
        public BankUnitTest()
        {
            //
        }


        [TestMethod]
        public void TestDepositAndWithdrawal1()
        {
            Account acc = new Account();
            acc.Deposit(100);
            acc.Withdraw(50);
            acc.Deposit(150);
            Assert.AreEqual(acc.Balance, 200);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal2()       // overdraw the account
        {
            Account acc = new Account(0, 1000);
            acc.Deposit(100);
            acc.Withdraw(1000);
            Assert.AreEqual(acc.Balance, -900);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal5()
        {
            Account acc = new Account();
            acc.Deposit(100);
            acc.Withdraw(0);                // must be positive
        }

        // also StringAssert and CollectionAssert
    }
}
