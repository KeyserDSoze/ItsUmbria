using System;
using System.Collections.Generic;
using System.Text;
using static ItsUmbria.Stuff2.StuffFactory;

namespace ItsUmbria.Stuff2
{
    public class Test : ITest
    {
        public void Do()
        {
            // Standard
            Console.ForegroundColor = ConsoleColor.Green;
            Paperino paperino = new Paperino();
            paperino.Print();
            Topolino topo = new Topolino();
            topo.Print();

            // Factory
            Console.ForegroundColor = ConsoleColor.Red;
            IPrintable character = new StuffFactory().Create(CharacterType.Paperino);
            character.Print();
            Console.ResetColor();
        }
    }
    public class Paperino : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Paperino");
        }
    }
    public class Pippo : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Pippo");
        }
    }
    public class Topolino : IPrintable
    {
        public void Print()
        {
            Console.WriteLine(nameof(Topolino));
        }
    }
    public interface IPrintable
    {
        void Print();
    }
}
