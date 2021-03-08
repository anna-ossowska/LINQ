using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQQueriesOnObjects
{
    public enum Gender
    {
        Female,
        Male
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public Gender Gender { get; set; }

        public Person(string name, int age, int height, Gender gender)
        {
            this.Name = name;
            this.Age = age;
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
                new Person("Jane", 27, 150, Gender.Female),
                new Person("Tod", 31, 170, Gender.Male),
                new Person("Jack", 28, 180, Gender.Male),
                new Person("Mary", 27, 160, Gender.Female),
                new Person("Alex", 45, 170, Gender.Male)
            };

            var fourCharPeople = from p in people
                                 where p.Name.Length == 4
                                 select p.Name;

            foreach (var p in fourCharPeople)
                Console.WriteLine(p);


            var orderByHeight = from p in people
                                orderby p.Height descending, p.Name
                                select p;

            foreach (var p in orderByHeight)
                Console.WriteLine($"{p.Name} : {p.Height}");
        }
    }
}
