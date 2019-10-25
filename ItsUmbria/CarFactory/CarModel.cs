using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CarFactory
{
    public abstract class CarModel
    {
        public string Targa { get; }
        public CarModel(string targa) => this.Targa = targa;
    }
}
