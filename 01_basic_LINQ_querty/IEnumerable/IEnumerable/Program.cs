using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable
{
    class Program
    {
        static void Main()
        {
            string sentence = "Random words";

            // The return type is IEnumerable<char>
            var simpleLinq = from s in sentence
                             select s;

            Console.WriteLine(string.Join(" ", simpleLinq));

            // The purpose of IEnumerable<T> interface is to unable foreach loop
            foreach (var s in simpleLinq)
            {
                Console.WriteLine(s);
            }

            // We cannot use indexing with [] on type IEnumerable<T>
            // That's why for loop cannot be performed here
        //    for (int i = 0; i < x.Count(); i++)
        //    {
        //        Console.WriteLine(simpleLinq[i]);
        //    }
        }
    }
}