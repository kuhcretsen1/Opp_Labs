namespace PaymentSystem
{
    public class PaymentProcessor
    {
        public void Process(PaymentAccount account, decimal amount)
        {
            account.ProcessPayment(amount);
        }
    }
}