﻿using System;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {
        decimal ICalculateBonuses.GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance)
        {
            //return currentBalance >= 1000 ? amountToDeposit * .1M : 0;
            if (currentBalance >= 10000)
            {
                //return amountToDeposit * .1M;
                if (BeforeCutoff())
                {
                    return amountToDeposit * .1M;
                }
                else
                {
                    return amountToDeposit * .05M;
                }
            }
            else
            {
                return 0;
            }
        }

        protected virtual bool BeforeCutoff()
        {
            return DateTime.Now.Hour < 17;
        }
    }
}