using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExamples
{
    class Program
    {
        static void Main()
        {
            string[] words = { "hello", "world", "bye", "hi" };
            int[] numbers = { 1, 5, 8, 3 };

            var wordsWithE = from word in words
                             // same as: where word.Contains('e') && (word.Length < 5)
                             where word.Contains('e')
                             where word.Length < 5
                             select word;

            foreach (var word in wordsWithE)
                Console.WriteLine(word);

            var getTheNumbers = from n in numbers
                                where n > 1
                                orderby n descending
                                select n;

            foreach (var n in getTheNumbers)
                Console.WriteLine(n);
        }
    }
}
