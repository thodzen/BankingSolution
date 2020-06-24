﻿using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountWithdraw
    {
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void WithdrawingMoneyDecresesBalance(decimal amountToWithdraw)
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            //var amountToWithdraw = 1M;

            account.Withdraw(amountToWithdraw);

            var expectedBalance = openingBalance - amountToWithdraw;
            Assert.Equal(expectedBalance, account.GetBalance());
        }

        [Fact]
        public void YouCanTakeAllYourMoney()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.GetBalance());
        }

    }
}
