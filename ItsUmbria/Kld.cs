using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria
{
    public class Kld
    {
        public string Property { get; set; }
        private string Field;
        public Kld(string field) 
        {
            this.Field = field;
        }
        public void Do() 
        {
            Console.WriteLine(this.Field);
        }
    }
}
