using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Junk
{
    public class Plastic : IJunk
    {
        public void Burn()
        {
            Console.WriteLine("Plastic burns");
        }
    }
}
