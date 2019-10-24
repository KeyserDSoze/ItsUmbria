using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    public class IdentityCard
    {
        public string Name { get; }
        public string Surname { get; }
        public DateTime BirthDate { get; }
        public IdentityCard(string name, string surname, DateTime birthDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
        }
    }
}
