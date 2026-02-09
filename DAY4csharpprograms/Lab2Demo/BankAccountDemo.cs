//Understanding Properties and validation
public class BankAccount
{
    public decimal Balance { get; private set; }

    public bool IsOverdrawn => Balance < 0;

    public BankAccount(decimal initialBalance = 0)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit must be positive");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdraw must be positive");

        Balance -= amount;
    }
}
