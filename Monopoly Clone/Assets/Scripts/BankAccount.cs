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

    public void Withdraw(int cost)
    {
        BalanceRemaining -= cost;
    }
        
    public void Deposit(int amount)
    {
        BalanceRemaining += amount;
    }
    
    public bool CanAfford(int cost)
    {
        return cost <= BalanceRemaining;
    }
}
