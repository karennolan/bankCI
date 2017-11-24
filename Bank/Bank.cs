// a bank account - and some unit tests, unit tests in a separate test project
// VSTS project for CI containing unit tests, code coverage
// and code quality checks
// local git repo managed through VS


using System;

namespace Bank
{
    // a simple euro bank account
    public class Account
    {
        private double balance;                             // the account balance
        private double overdraftLimit;

        // construct a bank acocunt with specified overdraft limit
        public Account(double overdraftLimit)
        {
            if (overdraftLimit >= 0)
            {
                this.balance = 0;
                this.overdraftLimit = overdraftLimit;
            }
            else
            {
                throw new ArgumentException("overdraft limit must be >= 0");
            }
        }

        // read-only property
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        // read-only property
        public double OverdraftLimit
        {
            get 
            {
                return overdraftLimit; 
            }
        }


        // deposit some money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                throw new ArgumentException("amount must be > 0");
            }
        }

        // withdraw some money if sufficient funds
        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (balance + overdraftLimit >= amount)
                {
                    balance -= amount;
                }
                else
                {
                    throw new ArgumentException("Insufficent funds for this transaction");
                }
            }
            else
            {
                throw new ArgumentException("amount must be > 0");
            }
        }

    }
}
