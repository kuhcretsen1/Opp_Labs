using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private readonly List<Car> cars = new List<Car>();

    public void AddCar(Car car) => cars.Add(car);

    public bool RemoveCar(Car car) => cars.Remove(car);

    public Car FindCar(string manufacturer, string model)
    {
        return cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
    }

    public void ShowInventory()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("No cars available.");
        }
        else
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}