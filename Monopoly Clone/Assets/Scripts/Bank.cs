public static class Bank
{
    public static void SetStartingFunds(BankAccount bankAccount, int amount)
    {
        bankAccount.SetBalance(amount);
    }
    
    public static void Deposit(BankAccount bankAccount, int amount)
    {
        bankAccount.Deposit(amount);;
    }

    public static void Withdraw(BankAccount bankAccount, int amount)
    {
        bankAccount.Withdraw(amount);
    }
}
