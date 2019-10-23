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
        }
    }
}
