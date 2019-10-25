using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public interface ICarFactory
    {
        CarModel CreateCar(CarType carType);
    }
}
