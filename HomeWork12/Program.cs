using HomeWork12;
using System.Text.RegularExpressions;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Проверка ввода регистрационных данных без конкретизации ошибок");
        InputRegister();
        Console.WriteLine("\nПроверка ввода регистрационных данных c конкретизацией ошибок");
        InputRegisterWithMessages();
        Console.ReadLine();
    }

    public static void InputRegister()
    {
        var loginCheck = false;
        var passwordCheck = false;
        var confirmPasswordCheck = false;
        var registration = new Registration();
        Console.WriteLine("\nВведите логин");
        while (!loginCheck)
        {
            try
            {
                registration.Login = Console.ReadLine();
                if (registration.Login.Length < 20 || registration.Login.Contains(' '))
                    throw new WrongLoginException();
                loginCheck = true;
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите логин заново");
            }
        }

        Console.WriteLine("\nВведите пароль");
        while (!passwordCheck)
        {
            try
            {
                registration.Password = Console.ReadLine();
                if (registration.Password.Contains(' ') || registration.Password.Length < 20 || !Regex.IsMatch(registration.Password, @"\d+"))
                    throw new WrongPasswordException();
                passwordCheck = true;
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите пароль заново");
            }
        }

        Console.WriteLine("\nПодтвердите пароль");
        while (!confirmPasswordCheck)
        {
            try
            {
                registration.ConfirmPassword = Console.ReadLine();
                if (registration.ConfirmPassword != registration.Password)
                    throw new WrongPasswordException();
                confirmPasswordCheck = true;
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите повторный пароль заново");
            }
        }

        Console.WriteLine("\nВведенные регистрационные данные:");
        Console.WriteLine($"Логин {registration.Login}");
        Console.WriteLine($"Пароль {registration.Password}");
    }

    public static void InputRegisterWithMessages()
    {
        var loginCheck = false;
        var passwordCheck = false;
        var confirmPasswordCheck = false;
        var registration = new Registration();
        Console.WriteLine("\nВведите логин");
        while (!loginCheck)
        {
            try
            {
                registration.Login = Console.ReadLine();
                if (registration.Login.Length < 20)
                    throw new WrongLoginException("Логин должен быть длиной не менее 20 символов");
                if (registration.Login.Contains(' '))
                    throw new WrongLoginException("Логин не должен содержать пробелы");
                loginCheck = true;
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите логин заново");
            }
        }

        Console.WriteLine("\nВведите пароль");
        while (!passwordCheck)
        {
            try
            {
                registration.Password = Console.ReadLine();
                if (registration.Password.Contains(' '))
                    throw new WrongPasswordException("Пароль не должен содержать пробелов");
                if (registration.Password.Length < 20)
                    throw new WrongPasswordException("Пароль должен должен быть длиной не менее 20 символов");
                if (!Regex.IsMatch(registration.Password, @"\d+"))
                    throw new WrongPasswordException("Пароль должен содержать хотя бы одну цифру");
                passwordCheck = true;
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите пароль заново");
            }
        }

        Console.WriteLine("\nПодтвердите пароль");
        while (!confirmPasswordCheck)
        {
            try
            {
                registration.ConfirmPassword = Console.ReadLine();
                if (registration.ConfirmPassword != registration.Password)
                    throw new WrongPasswordException("Введенные пароли не совпадают");
                confirmPasswordCheck = true;
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nВведите повторный пароль заново");
            }
        }

        Console.WriteLine("\nВведенные регистрационные данные:");
        Console.WriteLine($"Логин {registration.Login}");
        Console.WriteLine($"Пароль {registration.Password}");
    }
}

/*Создать класс, в котором будет статический метод.
Этот метод принимает на вход три параметра:
- Login
- Password
- ConfirmPassword
Все поля имеют тип данных String.
Длина Login должна быть меньше 20 символов и не должен содержать
пробелы.
Если Login не соответствует этим требованиям, необходимо выбросить
WrongLoginException.
Длина password должна быть меньше 20 символов, не должен содержать
пробелом и должен содержать хотя бы одну цифру.
Также Password и ConfirmPassword должны быть равны.
Если Password не соответствует этим требованиям, необходимо
выбросить WrongPasswordException.
WrongPasswordException и WrongLoginException - пользовательские
классы исключения с двумя конструкторами – один по умолчанию, второй
принимает сообщение исключения и передает его в конструктор класса
Exception.
Метод возвращает true, если значения верны или false в другом случае.*/