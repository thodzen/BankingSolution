using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _currentBalance = 5000;
        private ICalculateBonuses _bonusCalculator;
        private INarcOnAccounts _feds;

        public BankAccount(ICalculateBonuses bonusCalculator, INarcOnAccounts feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

        public decimal GetBalance()
        {
            return _currentBalance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            GuardAmount(amountToDeposit);
            decimal amountOfBonus = _bonusCalculator.GetDepositBonusFor(amountToDeposit, _currentBalance);
            _currentBalance += amountToDeposit + amountOfBonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            GuardAmount(amountToWithdraw);
            GuardOverdraft(amountToWithdraw);


            _feds.NotifyOfWithdraw(this, amountToWithdraw);
            _currentBalance -= amountToWithdraw;
        }

        private void GuardAmount(decimal amountToDeposit)
        {
            if (amountToDeposit <= 0)
            {
                throw new BadAmountException();
            }
        }
        
        public void GuardOverdraft(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _currentBalance)
            {
                throw new OverdraftException();
            }
        }
    }
}