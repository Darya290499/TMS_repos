namespace HomeWork7.Structures
{
    public struct InventoryStruct
    {
        public int Id { get; set; }
        public List<ProductStruct> Products { get; set; }
        public decimal ProductsSum { get; set; }

        public InventoryStruct(int id)
        {
            Id = id;
        }

        public InventoryStruct(int id, List<ProductStruct> products)
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