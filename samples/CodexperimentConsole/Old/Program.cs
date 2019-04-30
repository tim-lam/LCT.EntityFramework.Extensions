using System;
using Codexperiment;

namespace CodexperimentConsole.Old
{


    internal class Program
    {
        private /*static*/ void Main(string[] args)
        {
            var newInstance = new NonStaticClass1();
            
            Console.WriteLine(newInstance.NonStaticString);

            newInstance.SetNonStaticPropertyWithStatic();

            Console.WriteLine(newInstance.NonStaticString);

            Console.Read();
        }
    }


    //private static void Main(string[] args)
    //{
    //    Console.WriteLine(StaticClass1.StaticString);

    //    StaticClass1.StaticString = "I was changed by setter.";

    //    Console.WriteLine(StaticClass1.StaticString);

    //    Console.Read();
    //}


}
