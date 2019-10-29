using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.MemoryUsage
{
    //Heap
    public class StackOrHeap : ITest
    {
        //Heap
        private static SimpleStruct StaticSimpleStruct = new SimpleStruct();
        //Heap
        private static SimpleClass StaticSimpleClass = new SimpleClass(2, new DateTime(2019, 1, 1));

        //Heap
        public SimpleStruct SimpleStruct = new SimpleStruct();
        //Heap
        public SimpleClass SimpleClass = new SimpleClass(2, DateTime.Today);

        //Stack
        public void Do()
        {
            //Heap
            SimpleClass staticSimpleClassAsVariable = StaticSimpleClass;
            //Heap
            staticSimpleClassAsVariable.A = "Changed";
            Console.WriteLine($"{StaticSimpleClass.A} vs {staticSimpleClassAsVariable.A}");

            //Stack
            SimpleStruct staticSimpleStructAsVariable = StaticSimpleStruct;
            staticSimpleStructAsVariable.X = 7;
            Console.WriteLine($"{StaticSimpleStruct.X} vs {staticSimpleStructAsVariable.X}");

            //Heap
            SimpleClass simpleClassAsVariable = SimpleClass;
            simpleClassAsVariable.A = "Changed";
            Console.WriteLine($"{SimpleClass.A} vs {simpleClassAsVariable.A}");

            //Stack
            SimpleStruct simpleStructAsVariable = this.SimpleStruct;
            simpleStructAsVariable.X = 7;
            Console.WriteLine($"{SimpleStruct.X} vs {simpleStructAsVariable.X}");
        }
    }
    //Depends on Scope
    public struct SimpleStruct
    {
        public int X { get; set; }
        public int Y;
    }
    //Heap
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
        //Stack
        public void Do()
        {
            //Stack
            int t = 0;
            //Stack
            DateTime x = DateTime.UtcNow;
            //Heap
            string a = string.Empty;
            //Heap
            this.D = 3;
            //Heap
            this.E = x;
            //Stack
            SimpleStruct simpleStruct = new SimpleStruct();
            //Stack
            simpleStruct.X = 4;
        }
    }
}
