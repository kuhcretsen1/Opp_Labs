namespace CarSimulatorOnline;
using System.Collections.Generic;

public interface ICarDealer
{
    void BuyCar(Car car);
    void SellCar(Car car);
    void ExchangeCar(ICarDealer otherDealer, Car myCar, Car theirCar);
}
