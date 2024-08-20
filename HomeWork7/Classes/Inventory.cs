using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7.Classes
{
    public class Inventory
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal ProductsSum { get; set; }

        //public Inventory() { }

        public Inventory(int id)
        {
            Id = id;
        }

        public Inventory(int id, List<Product> products)
        {
            Id = id;
            Products = products;
            if (products.Count > 0)
                CountSum();
        }
        public void CountSum() => ProductsSum = Products.Sum(p => p.Price * p.Count);

        public void OutputInventoryInfo()
        {
            Console.WriteLine($"\nСклад №{Id}");
            Console.WriteLine("Перечень продуктов:");
            foreach (var product in Products)
                Console.WriteLine($"Продукт: {product.Name}, количество - {product.Count}");
            Console.WriteLine($"Общая стоимость: {ProductsSum}");
        }
    }
}
