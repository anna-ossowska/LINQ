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

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 12, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 56, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 18, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 16, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // Count number of people in each Gender group
            var howManyInGenderGroups = people.GroupBy(p => p.Gender)
                                              .Select(g => new
                                              {
                                                  Gender = g.Key,
                                                  NumberOfPeople = g.Count()
                                              });

            foreach (var p in howManyInGenderGroups)
            {
                Console.WriteLine($"{p.Gender}");
                Console.WriteLine($"\t{p.NumberOfPeople}");
            }
        }
    }
}

