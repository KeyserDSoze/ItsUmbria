using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Junk
{
    public class CamionTest : ITest
    {
        public void Do()
        {
            Camion.Instance.Burn(JunkType.Glass);
            Camion.Instance.Burn(JunkType.Plastic);
        }
    }
    public class Camion
    {
        private static Camion _Camion;
        public static Camion Instance
        {
            get
            {
                if (_Camion == null)
                    _Camion = new Camion();
                return _Camion;
            }
        }
        public void Burn(JunkType junkType)
        {
            IJunk junk;
            switch (junkType)
            {
                case JunkType.Plastic:
                    junk = new Plastic();
                    break;
                default:
                case JunkType.Glass:
                    junk = new Glass();
                    break;
            }
            junk.Burn();
        }
    }
}
