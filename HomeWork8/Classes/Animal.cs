namespace HomeWork8.Classes
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public void SetName()
        {
            Console.WriteLine($"Введите имя");
            Name = Console.ReadLine();
        }

        public void GetName() => Console.WriteLine($"Имя - {Name}");
        public abstract void Eat();
    }
}
/*Создайте программу на C#, реализующую абстрактный класс Animal со свойством Name текстового
типа и тремя методами SetName (строковое имя), GetName и Eat. Метод Eat будет абстрактным
методом типа void.
Вам также потребуется создать класс Dog, который реализует описанный выше класс Animal и метод
Eat, сообщающий, что собака ест.
Чтобы протестировать программу, спросите у пользователя имя собаки и создайте новый объект типа
Dog из Main программы, дайте объекту Dog имя, а затем выполните методы GetName и Eat.*/