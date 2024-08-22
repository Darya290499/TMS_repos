using HomeWork9.Task1;
using HomeWork9.Task2;
using HomeWork9.Task3;

public class Program
{
    private static void Main(string[] args)
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
        Console.WriteLine("1 - задание \"Задолженность\"");
        Console.WriteLine("2 - задание \"Учителя и студенты\"");
        Console.WriteLine("3 - задание \"Машины\"");
        Console.WriteLine("0 - выход из приложения");

        Console.WriteLine("\nВаш выбор:");
    }

    protected static int GetOperation()
    {
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var operation) && (operation >= 0 && operation <= 3))
                return operation;
            Console.WriteLine("Не удалось распознать номер операции. Пожалуйста, повторите ввод");
        }
    }
    protected static void MakeOperation(int operation)
    {
        switch (operation) {

            case 1:
                DebtTask();
                break;
            case 2:
                StudentProfessorTask();
                break;
            case 3:
                CarTask();
                break;
        }
    }

    #region DebtTask
    public static void DebtTask()
    {
        Console.WriteLine("\nЗадача кредит");
        Console.WriteLine("\nПервоначальные данные");
        Debt mortgage = new Debt(120000.0m, 1.01m);
        mortgage.PrintBalance();
        mortgage.PrintInterestRate();
        mortgage.WaitOneYear();
        Console.WriteLine("\nБаланс спустя год");
        mortgage.PrintBalance();
        // Wait 20 years
        int years = 0;
        while (years < 20)
        {
            mortgage.WaitOneYear();
            years = years + 1;
        }
        Console.WriteLine("\nБаланс спустя 20 лет");
        mortgage.PrintBalance();
    }
    #endregion

    #region StudentProfessorTask
    public static void StudentProfessorTask()
    {
        Console.WriteLine("\nЗадача про учителей и студентов");
        Console.WriteLine("\nВведите данные о человеке:");
        var person = GetPerson("p");
        person.SetAge(CheckAge(0, 100, "человека"));
        Console.WriteLine("\nИнтерактив человека:");
        person.Greet();

        Console.WriteLine("\nВведите данные студента:");
        var student = (Student)GetPerson("s");
        student.SetAge(CheckAge(18, 30, "студента"));
        Console.WriteLine("\nИнтерактив студента:");
        student.Greet();
        student.ShowAge();


        Console.WriteLine("\nВведите данные учителя:");
        var teacher = (Teacher)GetPerson("t");
        teacher.SetAge(CheckAge(22, 70, "учителя"));
        Console.WriteLine("\nИнтерактив учителя:");
        teacher.Greet();
        teacher.Explain();
    }

    public static int CheckAge(int minAge, int maxAge, string text)
    {
        while (true)
        {
            Console.WriteLine($"\nВведите возраст {text}:");
            if (Int32.TryParse(Console.ReadLine(), out int variable))
                if (variable >= minAge && variable <= maxAge) return variable;
                else Console.WriteLine($"Возраст {text} должен быть в диапазоне от {minAge} до {maxAge} включительно");
            else
                Console.WriteLine("Полученная строка не является целым числом. Повторите ввод");
        }
    }

    public static Person GetPerson(string type)
    {
        Console.WriteLine("\nФамилия");
        var surname = Console.ReadLine();
        Console.WriteLine("\nИмя");
        var name = Console.ReadLine();
        var sex = CheckSex();
        switch (type.ToLower())
        {
            case "t":
                Console.WriteLine("\nПреподаваемый предмет");
                var subject = Console.ReadLine();
                return new Teacher(name, surname, sex, subject);
            case "s":
                return new Student(name, surname, sex);
            default:
                return new Person(name, surname, sex);
        }

    }

    public static string CheckSex()
    {
        while (true)
        {
            Console.WriteLine("\nВведите пол (М | Ж):");
            var sex = Console.ReadLine();
            if (sex.ToUpper() == "М" || sex.ToUpper() == "Ж")
                return sex.ToUpper();
            Console.WriteLine("Пол указан некорректно. Повторите ввод");

        }
    }
    #endregion

    #region CarTask
    public static void CarTask()
    {
        Console.WriteLine("\nЗадача про машины");
        Console.WriteLine("\nВведите информацию о спортивной машине");
        var sportCar = new SportsCar(0, CheckInput(5, 12, "расход топлива на 100км"), CheckInput(SportsCar.minTunkVolume, SportsCar.maxTunkVolume, "объем бака"));
        var distance = CheckDistanceInput();
        sportCar.Drive(distance);
        var refuelOk = false;
        do
            refuelOk = sportCar.Refuel(CheckRefuelInput());
        while (!refuelOk);
        sportCar.Drive(distance);

        Console.WriteLine("\nВведите информацию о грузовике");
        var truck = new Truck(0, CheckInput(5, 12, "расход топлива на 100км"), CheckInput(Truck.minTunkVolume, Truck.maxTunkVolume, "объем бака"));
        distance = CheckDistanceInput();
        truck.Drive(distance);
        refuelOk = false;
        do
            refuelOk = truck.Refuel(CheckRefuelInput());
        while (!refuelOk);
        truck.Drive(distance);
    }

    protected static int CheckDistanceInput()
    {
        while (true)
        {
            Console.WriteLine($"\nВведите длину дистации:");
            if (Int32.TryParse(Console.ReadLine(), out int variable))
                if (variable > 0) return variable;
                else Console.WriteLine($"Введенное число должно быть больше нуля");
            else
                Console.WriteLine("Полученная строка не является целым числом. Повторите ввод");
        }
    }
    protected static int CheckRefuelInput()
    {
        while (true)
        {
            Console.WriteLine($"\nВведите количество литров топлива для дозаправки:");
            if (Int32.TryParse(Console.ReadLine(), out int variable))
                if (variable > 0) return variable;
                else Console.WriteLine($"Введенное число должно быть больше нуля");
            else
                Console.WriteLine("Полученная строка не является целым числом. Повторите ввод");
        }
    }

    protected static int CheckInput(int min, int max, string text)
    {
        while (true)
        {
            Console.WriteLine($"\nВведите {text}:");
            if (Int32.TryParse(Console.ReadLine(), out int variable))
                if (variable >= min && variable <= max) return variable;
                else Console.WriteLine($"Введенное число должно быть в диапазоне от {min} до {max} включительно");
            else
                Console.WriteLine("Полученная строка не является целым числом. Повторите ввод");
        }
    }
    #endregion

}