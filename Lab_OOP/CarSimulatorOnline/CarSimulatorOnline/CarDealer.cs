public class CarDealer
{
    public string Name { get; }
    public Inventory Inventory { get; }
    public CurrentAccount Account { get; }

    public CarDealer(string name, decimal initialBalance)
    {
        Name = name;
        Inventory = new Inventory();
        Account = new CurrentAccount(initialBalance);
    }

    public void BuyCar(Car car)
    {
        if (Account.DeductFunds(car.Price))
        {
            Inventory.AddCar(car);
            Console.WriteLine($"{Name} bought {car}.");
        }
        else
        {
            Console.WriteLine($"{Name} cannot afford {car}.");
        }
    }

    public void SellCar(Car car, CarDealer buyer)
    {
        if (Inventory.FindCar(car.Manufacturer, car.Model) != null)
        {
            if (buyer.Account.DeductFunds(car.Price))
            {
                Inventory.RemoveCar(car);
                buyer.Inventory.AddCar(car);
                Account.AddFunds(car.Price);
                Console.WriteLine($"{Name} sold {car} to {buyer.Name}.");
            }
            else
            {
                Console.WriteLine($"{buyer.Name} cannot afford {car}.");
            }
        }
        else
        {
            Console.WriteLine($"{Name} doesn't have {car} in inventory.");
        }
    }

    public void ExchangeCars(CarDealer otherDealer, Car myCar, Car theirCar)
    {
        if (Inventory.FindCar(myCar.Manufacturer, myCar.Model) != null &&
            otherDealer.Inventory.FindCar(theirCar.Manufacturer, theirCar.Model) != null)
        {
            decimal priceDifference = myCar.Price - theirCar.Price;

            if (priceDifference > 0)
            {
                if (otherDealer.Account.DeductFunds(priceDifference))
                {
                    ExecuteExchange(otherDealer, myCar, theirCar);
                    Console.WriteLine($"{otherDealer.Name} доплатив різницю в ${priceDifference}.");
                }
                else
                {
                    Console.WriteLine($"{otherDealer.Name} не може дозволити собі покрити різницю.");
                }
            }
            else if (priceDifference < 0)
            {
                if (Account.DeductFunds(-priceDifference))
                {
                    ExecuteExchange(otherDealer, myCar, theirCar);
                    Console.WriteLine($"{Name} доплатив різницю в ${-priceDifference}.");
                }
                else
                {
                    Console.WriteLine($"{Name} не може дозволити собі покрити різницю.");
                }
            }
            else
            {
                ExecuteExchange(otherDealer, myCar, theirCar);
                Console.WriteLine("Обмін завершено без додаткової оплати.");
            }
        }
        else
        {
            Console.WriteLine("Один або обидва автомобілі недоступні для обміну.");
        }
    }

    private void ExecuteExchange(CarDealer otherDealer, Car myCar, Car theirCar)
    {
        Inventory.RemoveCar(myCar);
        otherDealer.Inventory.RemoveCar(theirCar);
        Inventory.AddCar(theirCar);
        otherDealer.Inventory.AddCar(myCar);
    }
}
