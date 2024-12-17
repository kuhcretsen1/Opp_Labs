namespace PaymentSystem
{
    public class PayoneerAccount : PaymentAccount
    {
        public PayoneerAccount(string accountHolder, decimal balance) : base(accountHolder, balance) { }

        public override void ProcessPayment(decimal amount)
        {
            base.ProcessPayment(amount);
        }
    }
}
