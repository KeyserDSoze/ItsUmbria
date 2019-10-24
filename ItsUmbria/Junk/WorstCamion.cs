using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Junk
{
    public class WorstCamion
    {
        private static WorstCamion _Camion;
        public static WorstCamion Instance
        {
            get
            {
                if (_Camion == null)
                    _Camion = new WorstCamion();
                return _Camion;
            }
        }
        public void Burn(JunkType junkType)
        {
            switch (junkType)
            {
                case JunkType.Plastic:
                    Console.WriteLine($"Brucia {junkType}");
                    break;
                default:
                    throw new ArgumentException("Junk not found");
                    break;
                case JunkType.Glass:
                    Console.WriteLine($"Brucerà {junkType}");
                    break;
            }
        }
    }
}
