using System;
using Bank;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace BankTestUnitTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BankUnitTest
    {
        //Class variables that can be used in all tests
        private Account testAcc;
        private double balance;
        private double overdraft;
        private double amount;

        //Initialise class variables before each test
        [TestInitialize]
        public void TestInit()
        {
            //Arrange 
            testAcc = new Account();
        }


        //Clean up class variables after each test
        [TestCleanup]
        public void TestCleanup()
        {
            //Tear down and clean up  
            testAcc = null;
            balance = 0;
            overdraft = 0;
            amount = 0;
        }

        /** 
         * Set of tests for constructors
         * There are 4 execution paths inside the Deposit method, so we need tests to ensure each path is tested
         */
        //Test Deposit method execution paths 1 and path 3
        [TestMethod]
        public void TestAccount_CreateAccountWithValidBalanceAndOverdraft_CreatesAccountSuccessfully()
        {
            //Assign
            balance = 1000;
            overdraft = 500;

            //Act
            this.testAcc = new Account(balance, overdraft);

            //Assert
            Assert.IsNotNull(this.testAcc);
            Assert.AreEqual(this.testAcc.Balance, balance);
            Assert.AreEqual(this.testAcc.OverdraftLimit, overdraft);
        }

        //Test Deposit method execution path 2
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]   //Should throw an ArgumentException (or subclass) otherwise test fails
        public void TestAccount_CreateAccountWithInvalidBalance_ThrowsArgumentException()
        {
            //Assign
            balance = -100;
            overdraft = 0;

            //Act
            this.testAcc = new Account(balance, overdraft);  // -100 balance

            //Assert
            //Do not need the Assert section as this is handled by the "ExpectedException"
        }

        //Test Deposit method execution path 4
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]   //Should throw an ArgumentException (or subclass) otherwise test fails
        public void TestAccount_CreateAccountWithInvalidOverdraftLimit_ThrowsArgumentException()
        {
            //Assign
            balance = 0;
            overdraft = -5000;

            //Act
            this.testAcc = new Account(balance, overdraft);   // -5000 overdraft limit

            //Assert
            //Do not need the Assert section as this is handled by the "ExpectedException"
        }


        //No tests needed for defauly constructor
        //public Account() : this(0, 0)
        //As this uses constructor chaining and straight away calls the overloaded constructor
        //public Account(double balance, double overdraftLimit)
        //which we have tests for above


        /** 
         * Set of tests for getter and setter methods
         */
        //No need to create unit tests for getter and setter methods as the virtual machine
        //that runs the C# code creates these for you
        //However, the setter method for the variables balance and OverdraftLimit throws an exception so I am going to include a unit test for this execution path
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "FAILED: overdraft limit must be >= 0")]   //Should throw an ArgumentException (or subclass) otherwise test fails
        public void TestSetOverDraftLimit_OverdraftLimitLessThan0_ThrowsArgumentException()
        {
            this.testAcc.OverdraftLimit = -500;       // -500 overdraft limit
        }


        /** 
         * Set of tests for Deposit method
         * There are 2 execution paths inside the Deposit method, so we need 2 tests to ensure each path is tested
         */
        //Test Deposit method execution path 1
        [TestMethod]                                        
        public void TestDeposit_Balance0Deposit200_Balance200()
        {
            //Assign
            // 0 balance, no overdraft limit in testAcc
            amount = 100;
            double expectedResult = (amount * 2);

            //Act
            this.testAcc.Deposit(amount);  //balance should now be 100
            this.testAcc.Deposit(amount);  //balance should now be 200

            //Assert
            Assert.AreEqual(this.testAcc.Balance, expectedResult);
        }

        //Test Deposit method execution path 2
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "FAILED: amount must be > 0")]
        public void TestDeposit_Balance0DepositMinus100_ThrowsArgumentException()
        {
            //Assign
            // 0 balance, no overdraft limit in testAcc
            amount = -100;

            //Act
            this.testAcc.Deposit(amount);         // must be positive

            //Assert
            //Do not need the Assert section as this is handled by the "ExpectedException"
        }


        /** 
         * Set of tests for Withdraw method
         * There are 3 execution paths inside the Withdraw method, so we need 3 tests to ensure each path is tested
         */
        //Test Withdraw method execution path 1
        [TestMethod]
        public void TestWithdraw_Withdraw50WhenBalance0AndOverdraftlimit50_NewBalanceMinus50()
        {
            //Assign
            amount = 50;
            this.testAcc.OverdraftLimit = amount;
            double expectedResult = -50;

            //Act
            this.testAcc.Withdraw(amount);

            //Assert
            Assert.AreEqual(this.testAcc.Balance, expectedResult);
        }

        //Test Withdraw method execution path 2
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "FAILED: Insufficent funds for this transaction")]
        public void TestWithdraw_Withdraw2000WhenBalance0AndOverdraftLimit1000_ThrowArgumentException()
        {
            //Assign
            // 0 balance, no overdraft limit in testAcc
            amount = 2000;
            this.testAcc.OverdraftLimit = (amount / 2); //1000

            //Act
            this.testAcc.Withdraw(amount);     // overdraft limit exceeded

            //Assert
            //Do not need the Assert section as this is handled by the "ExpectedException"
        }

        //Test Withdraw method execution path 3
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "FAILED: amount must be > 0")]
        public void TestWithdraw_WithdrawMinus100_ThrowArgumentException()
        {
            //Assign
            // 0 balance, no overdraft limit in testAcc
            amount = -100;

            //Act
            this.testAcc.Withdraw(amount);     // must be positive

            //Assert
            //Do not need the Assert section as this is handled by the "ExpectedException"
        }
    }
}
