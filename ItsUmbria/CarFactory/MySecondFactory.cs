using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    class MySecondFactory : ICarFactory
    {
        //La mia seconda azienda è in grado di creare una macchina del tipo Coupé,
        //predispongo comunque un default che va in errore per future possibili implementazioni
        public ICarModel CreateCar(CarType carType)
        {
            switch (carType)
            {
                case CarType.Coupe:
                    return new Coupe();
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
