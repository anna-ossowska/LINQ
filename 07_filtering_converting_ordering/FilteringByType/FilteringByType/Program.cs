using System;
using System.Collections.Generic;
using System.Linq;

namespace FilteringByType
{
    class Program
    {
        public class Person
        {
            public int Age { get; set; }
            public int ID { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
        }

        public class Buyer : Person
        {
        }

        public class Supplier : Person
        {
        }

        static void Main()
        {
            // Extract all the integers from the array
            object[] mix = { 1, "string", new List<int> { 2, 64, 54, 4, 9, 10 }, "even", "odd", 3, 6, 7 };
            var allIntgers = mix.OfType<int>();

            Console.WriteLine(string.Join(", ", allIntgers));

            List<Person> people = new List<Person>()
            {
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 },
                new Supplier() { Age = 32 }
            };

            // Extract all the suppliers older than 20
            var allSuppliers = people.OfType<Supplier>().Where(s => s.Age > 20);

            foreach (var s in allSuppliers)
            {
                Console.WriteLine(s.Age);
                Console.WriteLine(s.GetType());
            }

            // 2nd solution with the method syntax
            var allSuppliers2 = from p in people
                                where p is Supplier
                                where p.Age > 20
                                select p;

            foreach (var s in allSuppliers2)
            {
                Console.WriteLine(s.Age);
                Console.WriteLine(s.GetType());
            }

            // 3rd solution with the method syntax
            var allSuppliers3 = from p in people
                                where p is Supplier
                                let s = p as Supplier
                                where s.Age > 20
                                select p;

            foreach (var s in allSuppliers3)
            {
                Console.WriteLine(s.Age);
                Console.WriteLine(s.GetType());
            }
        }
    }
}
