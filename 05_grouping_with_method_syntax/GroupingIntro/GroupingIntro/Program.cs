using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupingIntro
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

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 27, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 29, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 28, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 34, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // Regular grouping (one key)
            var groupGender = people.Where(p => p.Age > 27)
                                    .GroupBy(p => p.Gender);

            foreach (var item in groupGender)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}, {p.Age}");
                }
            }

            // Regular grouping (one key)
            var groupAlphabetically = people.OrderBy(p => p.FirstName[0]).GroupBy(p => p.FirstName[0]);

            foreach (var item in groupAlphabetically)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}");
                }
            }

            // Grouping by multiple key
            var groupByGenderAndAge = people.GroupBy(p => new { p.Gender, p.Age}).OrderBy(p => p.Count());

            foreach (var item in groupByGenderAndAge)
            {
                Console.WriteLine($"{item.Key.Gender} | {item.Key.Age}");
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}");
                }
            }
        }
    }
}