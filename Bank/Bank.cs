// a bank account
// Unit tests
// Componenet tests
// Specflow acceptance tests in a separate test project

using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank
{
    // a simple euro bank account
    public class Account
    {
        private double balance;                             // the account balance
        private double overdraftLimit;

        // construct a bank acocunt with specified opening
        // balance and overdraft limit
        public Account(double balance, double overdraftLimit)
        {
            //THERE WAS A BUG IN THE SYSTEM
            //IT DID NOT CHECK IF overdraftLimit WAS GREATER THAN 0

            if (balance >= 0)  //execution path 1
            {
                this.balance = balance;
            }
            else  //execution path 3
            {
                                            //changed
                throw new ArgumentException("balance must be >= 0");
            }
            //new code
            if (overdraftLimit >= 0)  //execution path 3
            {
                this.overdraftLimit = overdraftLimit;
            }
            else  //execution path 4
            {
                throw new ArgumentException("overdraft limit must be >= 0");
            }
        }

        // chain, 0 balance and overdraft
        public Account() : this(0, 0)
        {

        }

        // read-only property
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        // property
        public double OverdraftLimit
        {
            get 
            {
                return overdraftLimit;
            }
            set
            {
                if (value >= 0)
                {
                    this.overdraftLimit = value;
                }
                else
                {
                    throw new ArgumentException("overdraft limit must be >= 0");
                }
            }
        }

        // deposit some money
        public void Deposit(double amount)
        {
            if (amount > 0) //execution path 1
            {
                balance += amount;
            }
            else //execution path 2
            {
                throw new ArgumentException("amount must be > 0");
            }
        }

        // withdraw some money if sufficient funds
        public void Withdraw(double amount)
        {
            if (amount > 0) 
            {
                if (balance + overdraftLimit >= amount) //execution path 1
                {
                    balance -= amount;
                }
                else //execution path 2
                {
                    throw new ArgumentException("Insufficent funds for this transaction");
                }
            }
            else //execution path 3
            {
                throw new ArgumentException("amount must be > 0");
            }
        }
    }
}
