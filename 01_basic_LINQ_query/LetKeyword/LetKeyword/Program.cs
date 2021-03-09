using System;
using System.Linq;
using System.Collections.Generic;

namespace LetKeyword
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
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 27, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 31, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 23, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 45, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 65, 6, 165, Gender.Male)
            };

            var peopleWithA = from p in people
                              let firstcharacter = p.FirstName.ToLower()[0]
                              where firstcharacter == 'a'
                              let fullName = String.Format($"{p.FirstName} {p.LastName}")
                              select new YoungPerson { FullName = fullName };

            foreach (var p in peopleWithA)
                Console.WriteLine(p.FullName);



            List<List<int>> lists = new List<List<int>>
            {
                new List<int>() {1, 2, 3},
                new List<int>() {4, 5, 6},
                new List<int>() {7, 8, 9}
            };

            // 1. Put all the numbers into one single collection
            // 2. Retrieve squared numbers, but only those that are uder 50

            var allNumbers = from l in lists
                             from n in l
                             let square = Math.Pow(n, 2)
                             where square < 50
                             select String.Format($"{n} * {n} = {square}");

            foreach (var n in allNumbers)
                Console.WriteLine(n);

        }
    }
}