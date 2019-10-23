using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.MemoryUsage
{
    public class StackOrHeap : ITest
    {
        private static SimpleStruct StaticSimpleStruct = new SimpleStruct();
        private static SimpleClass StaticSimpleClass = new SimpleClass(2, new DateTime(2019, 1, 1));
        public SimpleStruct SimpleStruct = new SimpleStruct();
        public SimpleClass SimpleClass = new SimpleClass(2, DateTime.Today);

        public void Do()
        {
            SimpleClass staticSimpleClassAsVariable = StaticSimpleClass;
            staticSimpleClassAsVariable.A = "Changed";
            Console.WriteLine($"{StaticSimpleClass.A} vs {staticSimpleClassAsVariable.A}");

            SimpleStruct staticSimpleStructAsVariable = StaticSimpleStruct;
            staticSimpleStructAsVariable.X = 7;
            Console.WriteLine($"{StaticSimpleStruct.X} vs {staticSimpleStructAsVariable.X}");

            SimpleClass simpleClassAsVariable = SimpleClass;
            simpleClassAsVariable.A = "Changed";
            Console.WriteLine($"{SimpleClass.A} vs {simpleClassAsVariable.A}");

            SimpleStruct simpleStructAsVariable = SimpleStruct;
            simpleStructAsVariable.X = 7;
            Console.WriteLine($"{SimpleStruct.X} vs {simpleStructAsVariable.X}");
        }
    }
    public struct SimpleStruct
    {
        public int X { get; set; }
        public int Y;
    }
    public class SimpleClass
    {
        public string A { get; set; } = "NotChanged";
        public string B { get; }
        public int C { get; }
        private int D;
        private DateTime E;
        public SimpleClass(int d, DateTime e)
        {
            this.D = d;
            this.E = e;
        }
        public void Do()
        {
            int t = 0;
            DateTime x = DateTime.UtcNow;
            string a = string.Empty;
            this.D = 3;
            this.E = x;
            SimpleStruct simpleStruct = new SimpleStruct();
            simpleStruct.X = 4;
        }
    }
}
