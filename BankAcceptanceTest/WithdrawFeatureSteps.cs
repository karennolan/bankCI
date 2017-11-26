/*1. install SpecFlow extension into VS (and get trial license)
* 2. add unit test project, add reference to bank project
* 3. use Nuget to install SpecFlow runner package
* 4. add feature file and write features and scenarios
* 5. generate steps from feature file
* 6. complete steps in code
* 7. From Test menu "Run all Tests"
* 8. html doc in TestResults folder
*/

using Bank;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace BankAcceptanceTest
{
    [Binding]                   // bound to any feature file in project
    public class WithdrawFeatureSteps
    {
        private Account account;

        // put the system into known state
        [Given(@"the balance on my account is (.*)")]
        public void GivenTheBalanceOnMyAccountIs(double balance)
        {
            account = new Account(balance: balance, overdraftLimit: 0);
        }
        
        // put the system into known state
        [Given(@"there is an overdraft limit of (.*) on the account")]
        public void GivenThereIsAnOverdraftLimitOfOnTheAccount(double overdraftlimit)
        {
            account.OverdraftLimit = overdraftlimit;
            // = 0 would cause test to fail
        }
        
        // user peforms action
        [When(@"I withdraw (.*)")]
        public void WhenIWithdraw(double amount)
        {
            account.Withdraw(amount);
        }

        // observe outcomes
        [Then(@"the balance on the account should be (.*)")]
        public void ThenTheBalanceOnTheAccountShouldBe(double newbalance)
        {
            Assert.AreEqual(account.Balance, newbalance);
        }
    }

    // text of e.g. [Then()] needs to match exactly step in scenario
    // may need to re-build manually before running tests
}
