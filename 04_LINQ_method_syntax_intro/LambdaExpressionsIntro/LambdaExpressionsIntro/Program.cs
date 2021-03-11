using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressionsIntro
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 3, 6, 9, 12, 67, 13, 19, 1, 20, 32, 323, 89 };

            // query syntax
            var oddNumbers = from n in numbers
                             where n % 2 != 0
                             select n;

            foreach (var n in oddNumbers)
                Console.WriteLine(n);

            // method syntax
            var oddNumbers2 = numbers.Where(n => n % 2 != 0);

            foreach (var n in oddNumbers2)
                Console.WriteLine(n);
        }
    }
}
