using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public class CarManagerTest : ITest
    {
        public void Do()
        {
            CarManager manager = new CarManager();
            CarModel car = manager.GetCar("dd", CarType.Coupe);
            Console.WriteLine($"Car color {car.Color}");
            car.Color = "White";
            car = manager.GetCar("dd", CarType.Coupe);
            Console.WriteLine($"Car color {car.Color}");
            manager = new CarManager();
            Console.WriteLine($"Car color {manager.GetCar("dd", CarType.Coupe).Color}");
            manager.GetCar("dd", CarType.Coupe).Color = "White";
            Console.WriteLine($"Car color {manager.GetCar("dd", CarType.Coupe).Color}");
        }
    }
    public class CarManager
    {
        private static Dictionary<string, CarModel> Cars = new Dictionary<string, CarModel>();
        private ICarFactory CarFactory = new MySecondFactory();
        public CarModel GetCar(string targa, CarType carType)
        {
            if (!Cars.ContainsKey(targa))
            {
                Cars.Add(targa, this.CarFactory.CreateCar(carType));
            }
            return Cars[targa];
        }
    }
}
