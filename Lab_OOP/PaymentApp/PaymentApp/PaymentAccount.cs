using System;

namespace PaymentSystem
{
    public abstract class PaymentAccount
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

        protected const decimal MinPaymentAmount = 1.00m;
        protected const string InsufficientBalanceMessage = "Insufficient balance.";

        public PaymentAccount(string accountHolder, decimal balance)
        {
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public virtual void ProcessPayment(decimal amount)
        {
            if (amount < MinPaymentAmount)
            {
                Console.WriteLine($"{this.GetType().Name}: Minimum payment amount is {MinPaymentAmount}.");
                return;
            }

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"{this.GetType().Name}: {amount} processed. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}: {InsufficientBalanceMessage}");
            }
        }
    }
}