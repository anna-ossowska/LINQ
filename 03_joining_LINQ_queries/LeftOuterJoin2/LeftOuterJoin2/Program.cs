using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftOuterJoin2
{
    public class Supplier
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
    }


    class Program
    {
        static void Main()
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", State= "NY", Age = 22},
                new Buyer() { Name = "Peter", State= "AL", Age = 40},
                new Buyer() { Name = "Paul", State = "OH", Age = 30 },
                new Buyer() { Name = "Maria", State= "UT", Age = 35 },
                new Buyer() { Name = "Joshua",State = "TX", Age = 40 },
                new Buyer() { Name = "Sylvia",State = "MI", Age = 22 },
                new Buyer() { Name = "Rebecca", State = "AL", Age = 30 },
                new Buyer() { Name = "Jaime", State= "OR", Age = 35 },
                new Buyer() { Name = "Pierce", State = "OH", Age = 40 }
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", State = "NY", Age = 22 },
                new Supplier() { Name = "Charles", State = "NY", Age = 40 },
                new Supplier() { Name = "Hailee", State = "AL", Age = 40 },
                new Supplier() { Name = "Taylor", State = "MD", Age = 30 }
            };

            // The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null;
            // otherwise, it evaluates the right-hand operand and returns its result. 
            var leftOuterJoin = from s in suppliers
                                join b in buyers on s.State equals b.State into buyersGroup
                                from bg in buyersGroup.DefaultIfEmpty()
                                select new
                                {
                                    s.Name,
                                    s.State,
                                    BuyersName = bg?.Name ?? "No name"
                                };

            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.Name}, {item.State} | {item.BuyersName}");
            }
        }
    }
}

