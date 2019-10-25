using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public class Manager
    {
        public ICarFactory CarFactory { get; } = new MyFirstCarFactory();
    }
    public class CarFactoryTest : ITest
    {
        public void Do()
        {
            Manager manager = new Manager();
            ICarFactory carFactory = new MyFirstCarFactory();
            CarModel car = manager.CarFactory.CreateCar(CarType.Coupe);
            car = manager.CarFactory.CreateCar(CarType.Coupe);
            Console.WriteLine($"Created {car.Targa}");
        }
    }
}
