using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupByMultipleKeys
{
    public enum Gender
    {
        Female,
        Male
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public int Height { get; set; }
        public Gender Gender { get; set; }

        public Person(string firstName, string lastName, int age, int id, int height, Gender gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Id = id;
            this.Height = height;
            this.Gender = gender;
        }
    }

    public class YoungPerson
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        public static void EmptyLine()
        {
            Console.WriteLine("\n");
        }

        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 27, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 21, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 27, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 34, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // Group by age and gender
            var multipleKeys = from p in people
                               // clause should always end with either select or group by (!)
                               // if additionally to what we have here, we want to order by number of people in each group,
                               // we need to create a new query
                               group p by new { p.Age, p.Gender };

            foreach (var key in multipleKeys)
            {
                Console.WriteLine(key.Key);
                foreach (var item in key)
                {
                    Console.WriteLine($"{item.FirstName}");
                }
            }

            EmptyLine();
            EmptyLine();

            // order by amount of people in each group
            var orderedKeys = from p in multipleKeys
                              orderby p.Count() descending
                              select p;

            foreach (var key in orderedKeys)
            {
                Console.WriteLine($"Gender: {key.Key.Gender} | Age: {key.Key.Age}"); // reformatting
                foreach (var item in key)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
