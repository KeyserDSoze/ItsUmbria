using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ItsUmbria
{
    public class Reader
    {
        private IList<ITest> Tests = new List<ITest>();
        public Reader()
        {
            this.Tests = Assembly.GetAssembly(this.GetType()).GetTypes()
                .Where(x => x.GetInterface(nameof(ITest)) != null)
                .OrderBy(x => x.FullName)
                .Select(x => Activator.CreateInstance(x) as ITest)
                .ToList();
        }

        public void DoWork(int value)
        {
            if (value < this.Tests.Count)
                this.Tests[value].Do();
        }

        public string WhatDoYouWantToSeeInAction()
        {
            int value = 0;
            foreach (ITest test in this.Tests)
                Console.WriteLine($"For {test.ToName()} use {value++}");
            Console.WriteLine("Write 'exit' if you want to close this app.");
            return Console.ReadLine();
        }
    }
}
