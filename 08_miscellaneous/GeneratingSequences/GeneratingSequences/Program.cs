using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratingSequences
{
    class Program
    {
        static void Main()
        {
            // Repeat a string 10 times
            var repeatWords = Enumerable.Repeat("string", 10);


            // Create a range of 10 numbers starting from 4
            var numbers = Enumerable.Range(4, 10);


            // Generate odd numbers belonging to the 1-15 range
            var oddNumbers = Enumerable.Range(1, 15).Where(n => n % 2 != 0);


            // The same results using the query syntax
            var oddNubers2 = from n in Enumerable.Range(1, 15)
                             where n % 2 != 0
                             select n;


            // Generate square numbers belonging to the 1-10 range
            var squared = Enumerable.Range(1, 10).Select(n => Math.Pow(n, 2));


            // The same results using the query syntax
            var squared2 = from n in Enumerable.Range(1, 10)
                           select n * n;


            // Generate 10 random numbers belonging to the 1-100 range
            var rand = new Random();
            var randomNums = Enumerable.Range(1, 10).Select(_ => rand.Next(1, 100));


            // Generate all the English alphabet letters
            // 'a' - 97
            // 'z' - 122
            
            var asciiRange = Enumerable.Range(97, 26);
            var englishLetters = new List<char>();

            foreach (var n in asciiRange)
            {
                englishLetters.Add((char)n);
            }

            foreach (var letter in englishLetters)
            {
                Console.WriteLine(letter);
            }

            // Another solution
            var englishLetters2 = Enumerable.Range(0, 26).Select(c => (char)(c + 'a'));
        }
    }
}
