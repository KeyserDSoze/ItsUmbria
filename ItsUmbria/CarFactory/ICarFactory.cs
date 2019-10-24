using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public interface ICarFactory
    {
        ICarModel CreateCar(CarType carType);
    }
}
