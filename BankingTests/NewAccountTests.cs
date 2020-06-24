using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    // f12 while you have your cursor on a function to go to that function
    // alt+f12 while you have your cursor on a function to pull up a mini-window with that function
    public class NewAccountTests
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            // "WTCYWYH" = "Write the code you wish you had"
            // Given I have a brand new bank account
            var account = new BankAccount();
            // When I retrive the balance
            decimal balance = account.GetBalance();
            
            // It has a balance of $5,000.00
            Assert.Equal(5000M, balance);
        }

    }
}
