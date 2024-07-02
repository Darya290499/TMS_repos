public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Калькулятор");
        string operation;
        while (true)
        {
            MenuText();
            operation = OperationInput();
            GetResult(operation);
            Console.WriteLine("Для завершения работы введите 'да' или 'yes'. Для продолжения введите любой символ");
            var answ = Console.ReadLine().ToLower();
            if (answ == "да" || answ == "д" || answ == "yes" || answ == "y")
                break;
        }
        Console.WriteLine("Программа завершена. Нажмите любою кнопку, чтобы закрыть приложение");
        Console.ReadKey();
    }

    protected static decimal GetResult(string operation)
    {
        decimal result = 0;
        decimal firstVar = 0, secondVar = 0;
        switch (operation)
        {
            case "+" or "сложение":
                VariableInput(ref firstVar, ref secondVar);
                result = firstVar + secondVar;
                Console.WriteLine($"Результат: {result}");
                break;
            case "-" or "вычитание":
                VariableInput(ref firstVar, ref secondVar);
                result = firstVar - secondVar;
                Console.WriteLine($"Результат: {result}");
                break;
            case "*" or "умножение":
                VariableInput(ref firstVar, ref secondVar);
                result = firstVar * secondVar;
                Console.WriteLine($"Результат: {Math.Round(result, 4)}");
                break;
            case "/" or "деление":
                VariableInput(ref firstVar, ref secondVar);
                result = firstVar / secondVar;
                Console.WriteLine($"Результат: {Math.Round(result, 4)}");
                break;
            case "%" or "процент" or "процент от числа":
                PercentInput(ref firstVar, ref secondVar);
                result = firstVar * secondVar / 100;
                Console.WriteLine($"Результат: {Math.Round(result, 4)}");
                break;
            case "sqrt" or "корень" or "квадратный корень" or "квадратный корень числа":
                SqrtInput(ref firstVar);
                result = (decimal)Math.Sqrt((double)firstVar);
                Console.WriteLine($"Результат: {Math.Round(result, 4)}");
                break;
            default:                
                break;
        }
        return result;
    }

    protected static void MenuText()
    {
        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("сложение '+'");
        Console.WriteLine("вычитание '-'");
        Console.WriteLine("умножение '*'");
        Console.WriteLine("деление '/'");
        Console.WriteLine("процент от числа '%'");
        Console.WriteLine("квадратный корень числа 'sqrt'");
    }

    protected static string OperationInput()
    {
        Console.WriteLine("Действие: ");
        string operation;
        while (true)
        {
            operation = Console.ReadLine().ToLower();
            if (operation == "сложение" || operation == "+" ||
                operation == "вычитание" || operation == "-" ||
                operation == "умножение" || operation == "*" ||
                operation == "деление" || operation == "/" ||
                operation == "процент от числа" || operation == "процент" || operation == "%" ||
                operation == "квадратный корень числа" || operation == "квадратный корень" || operation == "корень" || operation == "sqrt")
                break;
            Console.WriteLine("Неизвестная операция. Повторите ввод");
        }
        return operation;
    }

    protected static void VariableInput(ref decimal firstVar, ref decimal secondVar)
    {
        while (true)
        {
            Console.WriteLine($"Введите первое число:");
            var parse = Decimal.TryParse(Console.ReadLine().Replace(".", ","), out firstVar);
            if (parse) break;
            Console.WriteLine("Полученная строка не является числом. Повторите ввод");
        }
        while (true)
        {
            Console.WriteLine($"Введите второе число:");
            var parse = Decimal.TryParse(Console.ReadLine().Replace(".", ","), out secondVar);
            if (parse)
                break;
        }
    }
    
    protected static void PercentInput(ref decimal firstVar, ref decimal secondVar)
    {
        while (true)
        {
            Console.WriteLine($"Введите число:");
            var parse = Decimal.TryParse(Console.ReadLine().Replace(".", ","), out firstVar);
            if (parse) break;
            Console.WriteLine("Полученная строка не является числом. Повторите ввод");
        }
        while (true)
        {
            Console.WriteLine($"Введите процент:");
            var parse = Decimal.TryParse(Console.ReadLine().Replace(".", ","), out secondVar);
            if (!parse)
                Console.WriteLine("Полученная строка не является числом. Повторите ввод");
            else if (secondVar > 100)
                Console.WriteLine("Процент не может быть больше 100");
            else
                break;
        }        
    }
   
    protected static void SqrtInput(ref decimal firstVar)
    {
        while (true)
        {
            Console.WriteLine($"Введите число:");
            var parse = Decimal.TryParse(Console.ReadLine().Replace(".", ","), out firstVar);
            if (!parse)
                Console.WriteLine("Полученная строка не является числом. Повторите ввод");
            else if (firstVar < 0)
                Console.WriteLine("Число не может быть отрицательным");
            else
                break;
        }
    }

}