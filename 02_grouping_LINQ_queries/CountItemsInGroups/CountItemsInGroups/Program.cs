using System;
using System.Linq;
using System.Collections.Generic;

namespace CountItemsInGroups
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
                new Person("Jane", "Doe", 12, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 70, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 18, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 16, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 34, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // Count how many people are in each Gender group
            var howManyInEachGroup = from p in people
                                     group p by p.Gender into g
                                     select new { Gender = g.Key, NumOfPeople = g.Count() };

            foreach (var item in howManyInEachGroup)
            {
                Console.WriteLine($"{item.Gender}");
                Console.WriteLine($"{item.NumOfPeople}");
            }
        }
    }
}