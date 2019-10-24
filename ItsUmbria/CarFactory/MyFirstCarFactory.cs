using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public class MyFirstCarFactory : ICarFactory
    {
        //La mia prima azienda non è in grado di creare una macchina del tipo Coupé
        public ICarModel CreateCar(CarType carType)
        {
            switch (carType)
            {
                case CarType.Sportive:
                    return new Sportive();
                case CarType.Suv:
                    return new Suv();
                default:
                    throw new ArgumentException($"CarType {carType} not creable.");
            }
        }
    }
}
