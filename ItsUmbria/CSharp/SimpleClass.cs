using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    //C# reference
    //https://docs.microsoft.com/it-it/dotnet/csharp/getting-started/
    //https://github.com/KeyserDSoze/Test/blob/master/Test/CSharpV1/Version1.cs
    public class SimpleClass
    {
        //Questo è un campo
        public string A;
        //Questa è una proprietà
        public string B { get; set; }
        //Questo è un costruttore
        public SimpleClass()
        {
        }
        //Questo è un metodo
        public void Run()
        {

        }
    }
    //Si differenzia dalla classe perchè genera oggetti che finiscono direttamente nello stack.
    //Solitamente le struct sono fatte in maniera immutabile, il loro cambiamento può passare solo da una nuova istanza dell'oggetto.
    public struct SimpleStruct
    {
        public int X { get; }
        public SimpleStruct(int x)
        {
            this.X = x;
        }
    }
    //Classes Only:
    //Can support inheritance
    //Are reference(pointer) types
    //The reference can be null
    //Have memory overhead per new instance

    //Structs Only:
    //Cannot support inheritance
    //Are value types
    //Are passed by value(like integers)
    //Cannot have a null reference(unless Nullable is used)
    //Do not have a memory overhead per new instance - unless 'boxed'
}
