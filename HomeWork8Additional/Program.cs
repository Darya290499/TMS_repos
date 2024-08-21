using HomeWork8Additional.Figures;
using HomeWork8Additional.Workers;

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
        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("1 - работа с фигурами");
        Console.WriteLine("2 - работа с работниками");
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
            FigureTask();
        }
        else
        {
            WorkerTask();
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

    #region Figures
    public static void FigureTask()
    {
        var array = new Figure[5];
        Console.WriteLine("\nСоздание массива из 5 (пяти) фигур");
        for (int i = 0; i < array.Length; i++)
        {
            FigureMenuText();
            switch (GetFigureNum())
            {
                case 1:
                    array[i] = new Circle(CheckDecimalInput("радиус"));
                    break;
                case 2:
                    array[i] = new Rectangle(CheckDecimalInput("первую сторону треугольника"), CheckDecimalInput("вторую сторону треугольника"));
                    break;
                case 3:
                    array[i] = CheckTriangle();
                    break;
            }                    
        }
        Console.WriteLine("\nМассив фигур:");
        foreach (Figure f in array)        
            Console.WriteLine($"{f.Type}, перметр - {f.Perimeter}");

        
        Console.WriteLine($"\nСумма периметра фигур: {array.Sum(a => a.Perimeter)}");
    }
    protected static void FigureMenuText()
    {
        Console.WriteLine("\nВыберите фигуру: ");
        Console.WriteLine("1 - круг");
        Console.WriteLine("2 - прямоугольник");
        Console.WriteLine("3 - треугольник");

        Console.WriteLine("\nВаш выбор:");
    }

    protected static int GetFigureNum()
    {
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var operation) && (operation >= 1 && operation <= 3))
                return operation;
            Console.WriteLine("Не удалось распознать номер фигуры. Пожалуйста, повторите ввод");
        }
    }

    protected static Triangle CheckTriangle()
    {
        while (true)
        {
            var a = CheckDecimalInput("первую сторону треугольника");
            var b = CheckDecimalInput("вторую сторону треугольника");
            var c = CheckDecimalInput("третью сторону треугольника");
            if ((a + b > c) && (b + c > a) && (a + c > b))
                return new Triangle(a, b, c);
            Console.WriteLine("\nТреугольник с такими сторонами не существует");
        }
        
    }
    #endregion
    #region Workers
    public static void WorkerTask()
    {
        var workers = new List<Worker>();
        Console.WriteLine("Введите информацию о сотрудниках компании");
        var workersCount = CheckIntInput("количество сотрудников");
        Console.WriteLine("\nЗаполните информацию о сотрудниках");
        for (int i = 0; i < workersCount; i++)
        {
            Console.WriteLine($"\nСотрудник {i + 1}");
            workers.Add(GetWorkerInfo(string.Empty));
        }


        Console.WriteLine("\nЗаполните информацию о бухгалтере");
        var worker = GetWorkerInfo("a");
        var accountCount = CheckIntInput("количество счетов, за которые отвечает бухгалтер");
        var accaunts = new List<string>();
        for (int i = 0; i < accountCount; i++)
        {
            Console.WriteLine($"\nВведите номер {i + 1}-го счета");
            accaunts.Add(Console.ReadLine());
        }
        var accountant = new Accountant(worker.Surname, worker.Name, worker.Post, worker.Department, accaunts);

        Console.WriteLine("\nЗаполните информацию о директоре");
        worker = GetWorkerInfo("d");
        var director = new Director(worker.Surname, worker.Name, worker.Post, worker.Department, workers);

        OutputWorkerInfo(director, accountant);
    }

    public static Worker GetWorkerInfo(string type)
    {
        Console.WriteLine("\nФамилия");
        var surname = Console.ReadLine();
        Console.WriteLine("\nИмя");
        var name = Console.ReadLine();
        var post = string.Empty;
        var department = string.Empty;
        if (type.ToLower() != "d" && type.ToLower() != "a")
        {
            Console.WriteLine("\nДолжность");
            post = Console.ReadLine();
            Console.WriteLine("\nОтдел");
            department = Console.ReadLine();
        }
        return new Worker(surname, name, post, department);   
    }

    public static void OutputWorkerInfo(Director director, Accountant accountant)
    {
        Console.WriteLine("\nИнформация о бухгалтере");
        accountant.GetSurnameName();
        accountant.GetPost();
        accountant.GetAccountingNames();

        Console.WriteLine("\nИнформация о директоре");
        director.GetSurnameName();
        director.GetPost();
        Console.WriteLine("\nПодчиненные директора:");

        for (int i = 0; i < director.Subordinates.Count; i++)
        {
            var worker = director.Subordinates[i];
            Console.WriteLine($"\nСотрудник {i + 1}");
            worker.GetSurnameName();
            worker.GetDep();
            worker.GetPost();
        }
    }

    #endregion
}