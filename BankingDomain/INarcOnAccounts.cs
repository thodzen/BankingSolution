namespace BankingDomain
{
    public interface INarcOnAccounts
    {
        void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw);
    }
}