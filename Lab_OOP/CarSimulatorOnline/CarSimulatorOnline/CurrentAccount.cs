public class CurrentAccount
{
    private decimal balance;

    public CurrentAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void AddFunds(decimal amount) => balance += amount;

    public bool DeductFunds(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    public void ShowBalance() => Console.WriteLine($"Current balance: ${balance}");
}