namespace PaymentSystem
{
    public class BankAccount : PaymentAccount
    {
        public BankAccount(string accountHolder, decimal balance) : base(accountHolder, balance) { }

        public override void ProcessPayment(decimal amount)
        {
            base.ProcessPayment(amount);
        }
    }
}