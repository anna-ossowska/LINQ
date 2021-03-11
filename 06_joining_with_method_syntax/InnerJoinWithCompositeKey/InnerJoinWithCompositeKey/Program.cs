using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerJoinWithCompositeKey
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
                new Buyer() { Name = "Joshua",State = "TX", Age = 32 },
                new Buyer() { Name = "Sylvia",State = "MI", Age = 22 },
                new Buyer() { Name = "Rebecca", State = "AL", Age = 30 },
                new Buyer() { Name = "Jaime", State= "OR", Age = 35 },
                new Buyer() { Name = "Pierce", State = "OH", Age = 40 }
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", State = "NY", Age = 22 },
                new Supplier() { Name = "Charles", State = "NY", Age = 40 },
                new Supplier() { Name = "Hailee", State = "MD", Age = 27 },
                new Supplier() { Name = "Taylor", State = "TX", Age = 32 }
            };

            var compositeJoin = suppliers.Join(buyers, s => new { s.State, s.Age },
                                                       b => new { b.State, b.Age },
                                                       (s, b) => new
                                                       {
                                                           State = s.State,
                                                           Age = s.Age,
                                                           SupplierName = s.Name,
                                                           BuyersName = b.Name
                                                       });

            foreach (var item in compositeJoin)
            {
                Console.WriteLine($"Supplier info: {item.State}, {item.SupplierName}, {item.Age}");
                Console.WriteLine($"\tMatching buyers: {item.BuyersName}");
            }
        }
    }
}