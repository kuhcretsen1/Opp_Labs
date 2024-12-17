using System;
using System.Collections.Generic;

public interface IDigitalWallet
{
    decimal CheckBalance();
    bool Deposit(decimal amount);
    bool Withdraw(decimal amount);
    List<string> GetTransactionLog();
    bool Authenticate(string login, string password);
    void SetAuthProvider(ILoginProvider authProvider);
}

public interface ILoginProvider
{
    bool Validate(string login, string password);
}

public class GmailAuthProvider : ILoginProvider
{
    private readonly string _email;
    private readonly string _password;

    public GmailAuthProvider(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public bool Validate(string login, string password) => _email == login && _password == password;
}

public abstract class PaymentSystem
{
    public abstract void ProcessPayment(decimal amount);
}


public class Privat24AuthProvider : ILoginProvider
{
    private readonly string _phoneNumber;
    private readonly string _password;

    public Privat24AuthProvider(string phoneNumber, string password)
    {
        _phoneNumber = phoneNumber;
        _password = password;
    }

    public bool Validate(string login, string password) => _phoneNumber == login && _password == password;
}

public class DigitalWallet : IDigitalWallet
{
    private const decimal InitialBalance = 0.0m;
    private const decimal WithdrawalLimit = 10000.0m;
    private const int MaxTransactions = 100;

    private decimal _balance;
    private bool _isAuthenticated;
    private ILoginProvider _authProvider;
    private readonly List<string> _transactionLog = new List<string>();

    public DigitalWallet() => _balance = InitialBalance;

    public void SetAuthProvider(ILoginProvider authProvider) => _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));

    public bool Authenticate(string login, string password)
    {
        if (_authProvider == null)
        {
            Console.WriteLine("Authentication provider is not set.");
            return false;
        }

        if (_authProvider.Validate(login, password))
        {
            _isAuthenticated = true;
            Console.WriteLine("Authentication successful.");
            return true;
        }

        Console.WriteLine("Invalid credentials.");
        return false;
    }

    private bool EnsureAuthenticated()
    {
        if (!_isAuthenticated)
        {
            Console.WriteLine("User not authenticated.");
            return false;
        }
        return true;
    }

    public decimal CheckBalance()
    {
        return EnsureAuthenticated() ? _balance : 0.0m;
    }

    public bool Deposit(decimal amount)
    {
        if (!EnsureAuthenticated() || amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return false;
        }

        _balance += amount;
        AddTransaction($"Deposited: {amount:C}");
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (!EnsureAuthenticated() || amount <= 0 || amount > _balance || amount > WithdrawalLimit)
        {
            Console.WriteLine("Invalid withdrawal amount.");
            return false;
        }

        _balance -= amount;
        AddTransaction($"Withdrew: {amount:C}");
        return true;
    }

    public abstract class PaymentSystem
    {
        public abstract void ProcessPayment(decimal amount);
    }

    
    private void AddTransaction(string message)
    {
        if (_transactionLog.Count >= MaxTransactions)
        {
            _transactionLog.RemoveAt(0);
        }
        _transactionLog.Add(message);
    }

    public List<string> GetTransactionLog() => EnsureAuthenticated() ? new List<string>(_transactionLog) : new List<string>();
}

class Program
{
    private static readonly Dictionary<string, Action<DigitalWallet>> Commands = new()
    {
        { "deposit", wallet =>
            {
                Console.Write("Enter amount to deposit: ");
                if (decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
                {
                    if (wallet.Deposit(amount))
                    {
                        Console.WriteLine($"Deposited: {amount:C}");
                    }
                }
            }
        },
        { "withdraw", wallet =>
            {
                Console.Write("Enter amount to withdraw: ");
                if (decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
                {
                    if (wallet.Withdraw(amount))
                    {
                        Console.WriteLine($"Withdrew: {amount:C}");
                    }
                }
            }
        },
        { "balance", wallet =>
            {
                Console.WriteLine($"Current balance: {wallet.CheckBalance():C}");
            }
        },
        { "transactions", wallet =>
            {
                var transactions = wallet.GetTransactionLog();
                Console.WriteLine("Transaction log:");
                transactions.ForEach(Console.WriteLine);
            }
        },
        { "auth", wallet =>
            {
                Console.Write("Enter auth provider type (gmail / privat24): ");
                var authType = Console.ReadLine();
                Console.Write("Enter login: ");
                var login = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                ILoginProvider newProvider = authType switch
                {
                    "gmail" => new GmailAuthProvider(login, password),
                    "privat24" => new Privat24AuthProvider(login, password),
                    _ => throw new ArgumentException("Invalid auth provider type.")
                };

                wallet.SetAuthProvider(newProvider);
                Console.WriteLine("Authentication provider updated.");
            }
        },
        { "authenticate", wallet =>
            {
                Console.Write("Enter login: ");
                var login = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                if (wallet.Authenticate(login, password))
                {
                    Console.WriteLine("Authentication successful.");
                }
            }
        }
    };

    static void Main()
    {
        var wallet = new DigitalWallet();

        while (true)
        {
            Console.WriteLine("Commands: deposit, withdraw, balance, transactions, auth, authenticate, exit");
            var command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            if (Commands.TryGetValue(command, out var action))
            {
                action(wallet);
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
    }
}