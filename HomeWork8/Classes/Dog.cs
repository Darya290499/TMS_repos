namespace HomeWork8.Classes
{
    public class Dog : Animal
    {
        public override void Eat() =>
            Console.WriteLine($"Собака {Name} ест");
        
    }
}
