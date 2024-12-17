public static class Program
{
    public static class DealerConstants
    {
        public const decimal InitialBalanceDealer1 = 50000m;
        public const decimal InitialBalanceDealer2 = 40000m;
    }

    public static class CarPriceConstants
    {
        public const decimal ToyotaCorollaPrice = 20000m;
        public const decimal FordMustangPrice = 30000m;
        public const decimal TeslaModelSPrice = 60000m;
    }

    public static void Main(string[] args)
    {
        CarDealer dealer1 = new CarDealer("AutoWorld", DealerConstants.InitialBalanceDealer1);
        CarDealer dealer2 = new CarDealer("SuperCars", DealerConstants.InitialBalanceDealer2);

        dealer1.BuyCar(new GasolineCar("Toyota", "Corolla", CarPriceConstants.ToyotaCorollaPrice));
        dealer1.BuyCar(new GasolineCar("Ford", "Mustang", CarPriceConstants.FordMustangPrice));
        dealer2.BuyCar(new ElectricCar("Tesla", "Model S", CarPriceConstants.TeslaModelSPrice));

        List<Car> cars = new List<Car>
        {
            new GasolineCar("Ford", "Mustang", CarPriceConstants.FordMustangPrice),
            new ElectricCar("Tesla", "Model S", CarPriceConstants.TeslaModelSPrice)
        };

        foreach (var car in cars)
        {
            car.Drive(); 
        }

        bool running = true;

        var actions = new Dictionary<string, Action>
        {
            { "1", () => dealer1.Inventory.ShowInventory() },
            { "2", () => dealer2.Inventory.ShowInventory() },
            { "3", () => dealer1.ExchangeCars(dealer2, dealer1.Inventory.FindCar("Toyota", "Corolla"), dealer2.Inventory.FindCar("Tesla", "Model S")) },
            { "4", () => { running = false; Console.WriteLine("Вихід з програми."); } }
        };

        while (running)
        {
            Console.WriteLine("\nВиберіть дію:");
            Console.WriteLine("1. Показати інвентар дилера 1");
            Console.WriteLine("2. Показати інвентар дилера 2");
            Console.WriteLine("3. Обміняти автомобілі");
            Console.WriteLine("4. Вийти");

            string choice = Console.ReadLine();

            if (actions.ContainsKey(choice))
            {
                actions[choice].Invoke();
            }
            else
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            }
        }
    }
}
