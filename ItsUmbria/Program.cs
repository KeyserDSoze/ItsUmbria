using ItsUmbria.MemoryUsage;
using ItsUmbria.Singleton;
using ItsUmbria.Solution;
using ItsUmbria.Stuff;
using System;
using System.Text;

namespace ItsUmbria
{
    class Program
    {
        private static Reader Reader = new Reader();
        private static string Result = string.Empty;
        static void Main(string[] args)
        {
            while ((Result = Reader.WhatDoYouWantToSeeInAction()) != "exit")
            {
                try
                {
                    Reader.DoWork(int.Parse(Result));
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
            }
           

            
            //IPerimeterable perimeterable = new IsosceleTriangle();
            //perimeterable.CalculatePerimeter();
            //IAreable areable = new IsosceleTriangle();
            //areable.CalculateArea();
            //ILineable line = new Line();
            //line.CalculateLine();
        }
        static void Run()
        {
            Animal animal = new Horse()
            {
                Name = "Loud"
            };
            Console.WriteLine(animal.Name);
            IRunnable runner = animal as IRunnable;
            if (runner != null)
                runner.Run();
        }
    }
}
