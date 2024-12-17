public class Car
{
    public string Manufacturer { get; }
    public string Model { get; }
    public decimal Price { get; }

    public Car(string manufacturer, string model, decimal price)
    {
        Manufacturer = manufacturer;
        Model = model;
        Price = price;
    }
    public virtual void Drive()
    {
        Console.WriteLine($"Driving a regular car: {Manufacturer} {Model}");
    }
    
    public override string ToString() => $"{Manufacturer} {Model} - ${Price}";
}

public class GasolineCar : Car
{
    public GasolineCar(string manufacturer, string model, decimal price) 
        : base(manufacturer, model, price) {}

    public override void Drive()
    {
        Console.WriteLine($"Driving a gasoline car: {Manufacturer} {Model}");
    }
}
    
public class ElectricCar : Car
{
    public ElectricCar(string manufacturer, string model, decimal price) 
        : base(manufacturer, model, price) {}

    public override void Drive()
    {
        Console.WriteLine($"Driving an electric car: {Manufacturer} {Model}");
    }
}