using HomeWork7.Classes;
using HomeWork7.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            MenuText();
            var operation = GetOperation();
            if (operation == 0)
                Environment.Exit(0);
            MakeOperation(operation);
        }
    }

    protected static void MenuText()
    {
        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("1 - работа с классами");
        Console.WriteLine("2 - работа со структурами");
        Console.WriteLine("0 - выход из приложения");

        Console.WriteLine("\nВаш выбор:");
    }
    protected static int GetOperation()
    {
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var operation) && (operation >= 0 && operation <= 2))
                return operation;
            Console.WriteLine("Не удалось распознать номер операции. Пожалуйста, повторите ввод");
        }
    }
    protected static void MakeOperation(int operation)
    {
        if (operation == 1)
        {
            Console.WriteLine("\nКлассы");
            var inventoryArray = new Inventory[CheckIntInput("количество складов")];
            for (int i = 0; i < inventoryArray.Length; i++)
            {
                Console.WriteLine($"\nСклад №{i + 1}\nДобавьте продукты");
                var productCount = CheckIntInput("количество продуктов");
                var productsList = new List<Product>();
                for (int j = 0; j < productCount; j++)
                    productsList.Add(new Product(CheckProductId(productsList), InputProductName(),
                        CheckDecimalInput("цену продукта"), CheckIntInput("количество продукта")));
                inventoryArray[i] = new Inventory(i + 1, productsList);
            }
            Console.WriteLine("");
            foreach (var inventory in inventoryArray)
                inventory.OutputInventoryInfo();
        }
        else
        {

            Console.WriteLine("\nСтруктуры");
            var inventoryArray = new InventoryStruct[CheckIntInput("количество складов")];
            for (int i = 0; i < inventoryArray.Length; i++)
            {
                Console.WriteLine($"\nСклад №{i + 1}\nДобавьте продукты");
                var productCount = CheckIntInput("количество продуктов");
                var productsList = new List<ProductStruct>();
                for (int j = 0; j < productCount; j++)
                    productsList.Add(new ProductStruct(CheckProductStructId(productsList), InputProductName(),
                        CheckDecimalInput("цену продукта"), CheckIntInput("количество продукта")));
                inventoryArray[i] = new InventoryStruct(i + 1, productsList);
            }
            Console.WriteLine("");
            foreach (var inventory in inventoryArray)
                inventory.OutputInventoryInfo();
        }
    }
    protected static int CheckIntInput(string text)
    {
        while (true)
        {
            Console.WriteLine($"\nВведите {text}:");
            if (Int32.TryParse(Console.ReadLine(), out int variable))
                if (variable > 0) return variable;
                else Console.WriteLine("Введенное число должно быть больше нуля");
            else
                Console.WriteLine("Полученная строка не является целым числом. Повторите ввод");
        }
    }

    protected static decimal CheckDecimalInput(string text)
    {
        while (true)
        {
            Console.WriteLine($"\nВведите {text}:");
            if (Decimal.TryParse(Console.ReadLine().Replace('.', ','), out decimal variable))
                if (variable > 0) return variable;
                else Console.WriteLine("Введенное число должно быть больше нуля");
            else
                Console.WriteLine("Полученная строка не является числом. Повторите ввод");
        }
    }

    protected static int CheckProductId(List<Product> products)
    {
        while (true)
        {
            var productId = CheckIntInput("id продукта");
            if (!products.Any(p => p.Id == productId)) return productId;
            Console.WriteLine("Продукт с таким id уже существует. Повторите ввод");
        }
    }

    protected static int CheckProductStructId(List<ProductStruct> products)
    {
        while (true)
        {
            var productId = CheckIntInput("id продукта");
            if (!products.Any(p => p.Id == productId)) return productId;
            Console.WriteLine("Продукт с таким id уже существует. Повторите ввод");
        }
    }
    
    protected static string InputProductName()
    {
        Console.WriteLine("\nВедите название продукта");
        return Console.ReadLine();
    }

}