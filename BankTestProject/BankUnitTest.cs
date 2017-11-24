using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Bank;

using Microsoft.VisualStudio.TestTools.UnitTesting;                         // unit testing

namespace BankTestProject
{
    /// <summary>
    /// Summary description for BankUnitTest
    /// </summary>
    [TestClass]                                                             // a class containing unit tests
    public class BankUnitTest
    {
        public BankUnitTest()
        {
            //
        }

     
        [TestMethod]                                            // a unit test
        public void TestDeposit1()
        {
            Account acc = new Account(5000);                    // 5000 overdraft limit
            acc.Deposit(100);
            acc.Deposit(200);
            Assert.AreEqual(acc.Balance, 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]           // should throw an ArgumentException (or subclass) otherwise test fails
        public void CreateAccountWithInvalidOverdraftLimit()
        {
            Account acc = new Account(-5000);                    // -5000 overdraft limit
        }

        [TestMethod]
        public void TestDepositAndWithdrawal1()
        {
            Account acc = new Account(2000);                   
            acc.Deposit(100);
            acc.Withdraw(50);
            acc.Deposit(150);
            Assert.AreEqual(acc.Balance, 200);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal2()                 // overdraw the account
        {
            Account acc = new Account(1000);                    
            acc.Deposit(100);
            acc.Withdraw(1000);
            Assert.AreEqual(acc.Balance, -900);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal3()
        {
            Account acc = new Account(1000);
            acc.Withdraw(2000);                                 // overdraft limit exceeded
            Assert.Fail();                                      // force failure if this point reached
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal4()
        {
            Account acc = new Account(0);
            acc.Deposit(-100);                                  // must be positive
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]        
        public void TestDepositAndWithdrawal5()
        {
            Account acc = new Account(0);
            acc.Deposit(100);
            acc.Withdraw(0);                                    // must be positive
            Assert.Fail();
        }

        // also StringAssert and CollectionAssert
    }
}
