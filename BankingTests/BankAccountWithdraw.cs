﻿using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountWithdraw
    {

        private BankAccount _account;
        private decimal _openingBalance;

        public BankAccountWithdraw()
        {
            _account = new BankAccount(new DummyBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            _openingBalance = _account.GetBalance();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void WithdrawingMoneyDecresesBalance(decimal amountToWithdraw)
        {
            _account.Withdraw(amountToWithdraw);


            var expectedBalance = _openingBalance - amountToWithdraw;
            Assert.Equal(expectedBalance, _account.GetBalance());
        }

        [Fact]
        public void YouCanTakeAllYourMoney()
        {
            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

    }
}
