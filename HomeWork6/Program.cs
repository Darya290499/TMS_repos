using HomeWork6.ClinicTask;
using HomeWork6.PhoneTask;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберете задание:");
            Console.WriteLine("1 - задание \"Телефон\"");
            Console.WriteLine("2 - задание \"Клиника\"");
            Console.WriteLine("0 - выход из программы");

            Console.WriteLine("\nВаш ввод:");
            var operation = GetOperation();

            switch (operation)
            {
                case 1:
                    PhoneTaskMethod();
                    break;
                case 2:
                    ClinicTaskMethod();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine();
        }
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

    #region Phone
    /// <summary>
    /// Создайте класс Phone, который содержит переменные number, model и weight.
    /// Создайте три экземпляра этого класса.
    /// Выведите на консоль значения их переменных.
    /// Добавить в класс Phone методы: receiveCall, имеет один параметр – имя звонящего. Выводит на консоль сообщение “Звонит { name}”. 
    /// getNumber – возвращает номер телефона.Вызвать эти методы для каждого из объектов.
    /// Добавить конструктор в класс Phone, который принимает на вход три параметра для инициализации переменных класса - number, model и weight.
    /// Добавить конструктор, который принимает на вход два параметра для инициализации переменных класса - number, model.
    /// Добавить конструктор без параметров.
    /// Вызвать из конструктора с тремя параметрами конструктор с двумя.
    /// Добавьте перегруженный метод receiveCall, который принимает два параметра - имя звонящего и номер телефона звонящего. 
    /// Вызвать этот метод.
    /// Создать метод sendMessage с аргументами переменной длины.
    /// Данный метод принимает на вход номера телефонов, которым будет отправлено.
    /// Метод выводит на консоль номера этих телефонов.
    /// </summary>
    protected static void PhoneTaskMethod()
    {
        var phones = new Phone[3];
        for (int i = 0; i < phones.Length; i++)
        {
            Console.WriteLine($"\nДанные {i+1}го телефона:");
            phones[i] = new Phone()
            {
                _number = GetPhoneNumber(),
                _model = GetPhoneModel(),
                _weight = GetPhoneWeight()
            };
        }
        Console.WriteLine("\nВывод информации по телефонам:");
        for (int i = 0; i < phones.Length; i++)
        {
            Console.WriteLine($"\nИнформация о телефоне {i + 1}:");
            Console.WriteLine($"Номер: {phones[i]._number}");
            Console.WriteLine($"Модель: {phones[i]._model}");
            Console.WriteLine($"Вес: {phones[i]._weight}");
        }
        Console.WriteLine("\nИмитация звонков");
        for (int i = 0; i < phones.Length; i++)
        {
            Console.WriteLine($"\nВведите имя звонящего для {i + 1} телефона");
            phones[i].RecieveCall(Console.ReadLine());
        }

        Console.WriteLine("\nВведите информацию по новому устройству");
        var newPhone = new Phone(GetPhoneNumber(), GetPhoneModel(), GetPhoneWeight()); 
        
        Console.WriteLine("\nВывод информации по новому телефону:");
            Console.WriteLine($"Номер: {newPhone._number}");
            Console.WriteLine($"Модель: {newPhone._model}");
            Console.WriteLine($"Вес: {newPhone._weight}");
        
        Console.WriteLine("\nИмитация звонка на новый телефон");
        Console.WriteLine($"\nВведите имя звонящего телефона");
        var name = Console.ReadLine();
        Console.WriteLine($"Введите номер звонящего телефона");
        newPhone.RecieveCall(name,GetPhoneNumber());

        Console.WriteLine("\nИмитация отправки сообщений с нового телефона");
        newPhone.SendMessage(phones.Select(p => p._number).ToArray());

        Console.WriteLine("\nИмитация отправки сообщений с нового телефона с вводом текста");
        Console.WriteLine("\nВведите сообщение для отправки");
        newPhone.SendMessage(phones.Select(p => p._number).ToArray(), Console.ReadLine());

    }

    protected static string GetPhoneNumber()
    {
        var number = string.Empty;
        Console.WriteLine($"\nВведите номер в формате +7-ххх-ххх-хх-хх:");
        while(true)
        {
            number = Console.ReadLine();
            if(Regex.IsMatch(number, @"^\+7(-\d{3}){2}(-\d{2}){2}$"))
                return number;
            Console.WriteLine("Номер не соответсвует шаблону. Пожалуйста, повторите ввод");

        }
    }
  
    protected static string GetPhoneModel()
    {
        Console.WriteLine($"\nВведите модель телефона:");
        return Console.ReadLine();
    }

    protected static decimal GetPhoneWeight()
    {
        var weightStr = string.Empty;
        Console.WriteLine($"\nВведите вес телефона:");
        while (true)
        {
            weightStr = Console.ReadLine();
           if(Decimal.TryParse(weightStr.Replace(".",","),out var weight))
                return weight;
            Console.WriteLine("Введенное значение не явяется целым или дробным числом. Пожалуйста, повторите ввод");
        }
    }
   
    #endregion

    #region Clinic
    /// <summary>
    /// Пусть в клинике будет три врача: хирург, терапевт и дантист.
    /// Каждый врач имеет метод «лечить», но каждый врач лечит по-своему.
    /// Так же предусмотреть класс «Пациент» и класс «План лечения».
    /// Создать объект класса «Пациент» и добавить пациенту план лечения.
    /// Так же создать метод, который будет назначать врача пациенту согласно плану лечения.
    /// Если план лечения имеет код 1 – назначить хирурга и выполнить метод лечить.
    /// Если план лечения имеет код 2 – назначить дантиста и выполнить метод лечить.
    /// Если план лечения имеет любой другой код – назначить терапевта и выполнить метод лечить.
    /// </summary>
    protected static void ClinicTaskMethod()
    {
        var doctors = new Doctor[3];
        var specializations = new List<string> { "Хирург", "Терапевт", "Дантист" };
        for (int i = 0; i < doctors.Length; i++)
        {
            Console.WriteLine($"\nВведите данные по {i + 1}му врачу:");
            doctors[i] = InputDoctor(specializations);
            specializations.Remove(doctors[i].Specialization);
        }

        Console.WriteLine("\nВывод информации о врачах:");
        for (int i = 0; i < doctors.Length; i++)
            doctors[i].Output();

        Console.WriteLine("\nВведите данные пациента");
        var patient = InputPatient();

        Console.WriteLine("\nВведите информацию о плане лечения пациента");
        patient.Plan = InputTreatmentPlan(doctors);

        Console.WriteLine($"\nПациент: {patient.Surname} {patient.Name}");
        patient.Plan.Heal();
    }

    #region Doctors
    protected static Doctor InputDoctor(List<string> specializations)
    {
        Console.WriteLine("\nВведите фамилию врача");
        var surname = Console.ReadLine();
        Console.WriteLine("\nВведите имя врача");
        var name = Console.ReadLine();

        var specialization = specializations.Count > 1 ? InputSpecialization(specializations) : specializations[0];
        return new Doctor(surname, name, specialization);
    }

    protected static string InputSpecialization(List<string> specializations)
    {
        Console.WriteLine("\nВыберете специализацию врача:");
        for (int i = 0; i < specializations.Count; i++)
            Console.WriteLine($"{i + 1} - {specializations[i]}");
        Console.WriteLine("\nВаш ввод:");
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var spec) && (spec > 0 && spec <= specializations.Count))
                return specializations[spec - 1];
            Console.WriteLine("Не удалось распознать специализацию. Пожалуйста, повторите ввод");
        }

    }
    #endregion

    #region Patients
    protected static Patient InputPatient()
    {
        Console.WriteLine("\nВведите фамилию пациента");
        var surname = Console.ReadLine();
        Console.WriteLine("\nВведите имя пациента");
        var name = Console.ReadLine();
        return new Patient(surname, name);
    }
    #endregion

    #region TreatmentPlans
    protected static TreatmentPlan InputTreatmentPlan(Doctor[] doctors)
    {
        Console.WriteLine("\nВведите код плана лечение (от 1 до 5)");
        var code = 0;
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out code) && (code >= 1 && code <= 5))
                break;
            Console.WriteLine("Не удалось распознать код. Пожалуйста, повторите ввод");
        }
        var treatmentPlan = new TreatmentPlan(code);
        switch(code)
        {
            case 1:
                Console.WriteLine("\nВыбран врач хирург");
                treatmentPlan.SetDoctor(doctors.Where(d => d.Specialization.Contains("Хирург")).First());
                break;
            case 2:
                Console.WriteLine("\nВыбран врач дантист");
                treatmentPlan.SetDoctor(doctors.Where(d => d.Specialization.Contains("Дантист")).First());
                break;
            default:
                Console.WriteLine("\nВыбран врач терапевт");
                treatmentPlan.SetDoctor(doctors.Where(d => d.Specialization.Contains("Терапевт")).First());
                break;
        }

        return treatmentPlan;
    }
    #endregion

    #endregion
}