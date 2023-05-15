public class BankAccount
{
    public int StartBalance { get; }
    public int BalanceRemaining { get; private set; }

    public BankAccount()
    {
        StartBalance = 0;
        BalanceRemaining = StartBalance;
    }

    public BankAccount(int startingBalance)
    {
        StartBalance = startingBalance;
        BalanceRemaining = StartBalance;
    }

    public void SetBalance(int amount)
    {
        BalanceRemaining = amount;
    }

    /// <summary>
    /// For paying money directly into another bank account
    /// </summary>
    public void Pay(BankAccount bankAccount, int amount)
    {
        BalanceRemaining -= amount;
        bankAccount.Deposit(amount);
    }
    
    /// <summary>
    /// For withdrawing funds from account
    /// </summary>
    public void Withdraw(int cost)
    {
        BalanceRemaining -= cost;
    }
        
    /// <summary>
    /// For depositing funds into account
    /// </summary>
    public void Deposit(int amount)
    {
        BalanceRemaining += amount;
    }
    
    public bool CanAfford(int cost)
    {
        return cost <= BalanceRemaining;
    }
}
