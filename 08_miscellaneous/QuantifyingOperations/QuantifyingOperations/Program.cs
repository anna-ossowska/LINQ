using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantifyingOperations
{
    class Program
    {
        static void Main()
        {
            List<int> ints = new List<int>() { 2, 5, 9, 3, 7, 11, 67, 23, 3, 1, 22, 2, 1, 3 };
            string s1 = "A short sentence.";

            Console.WriteLine(ints.All(n => n < 100));

            Console.WriteLine(ints.Contains(2));

            Console.WriteLine(s1.Contains('A'));

            Console.WriteLine(ints.Any(n => n > 70));

            // Simple way of checking if a string is empty
            Console.WriteLine(s1.Any());

            string empty = string.Empty;
            Console.WriteLine(empty.Any());
        }
    }
}