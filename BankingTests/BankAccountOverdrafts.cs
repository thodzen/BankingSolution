using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{

    
    public class BankAccountOverdrafts
    {
        public decimal _openingBalance;
        private BankAccount _account;

        public BankAccountOverdrafts()
        {
            _account = new BankAccount(new Mock<ICalculateBonuses>().Object, new Mock<INarcOnAccounts>().Object); // Used Moq installation but could have used DummyBonusCalculator()
            _openingBalance = _account.GetBalance();
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            try
            {
                _account.Withdraw(_openingBalance + 1);
            }
            catch (OverdraftException) 
            { 
                // I was expecting this... keep going
            }

            Assert.Equal(_openingBalance, _account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {

            Assert.Throws<OverdraftException>(() => _account.Withdraw(_openingBalance + 1));
        }
    }
}
