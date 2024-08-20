using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public Product() { }

        public Product(int id, string name, decimal price, int count)
        {
            Id = id;
            Name = name;
            Price = price;
            Count = count;
        }
    }
}