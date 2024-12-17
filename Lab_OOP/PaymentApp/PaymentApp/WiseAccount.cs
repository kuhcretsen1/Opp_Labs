namespace PaymentSystem
{
    public class WiseAccount : PaymentAccount
    {
        public WiseAccount(string accountHolder, decimal balance) : base(accountHolder, balance) { }

        public override void ProcessPayment(decimal amount)
        {
            base.ProcessPayment(amount);
        }
    }
}