using System;

namespace PaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            PaymentAccount bank = new BankAccount("John Doe", 1000);
            PaymentAccount payoneer = new PayoneerAccount("Jane Smith", 500);
            PaymentAccount wise = new WiseAccount("Mike Johnson", 300);

            processor.Process(bank, 200);
            processor.Process(payoneer, 600);  
            processor.Process(wise, 100);
        }
    }
}