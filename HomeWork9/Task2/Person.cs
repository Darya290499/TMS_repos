namespace HomeWork9.Task2
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Sex { get; set; }
        public int Age {  get; set; }
        
        public Person() { }

        public Person(string name, string surname, string sex)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
        }

        public void SetAge(int age) => Age = age;

        public virtual void Greet() => Console.WriteLine($"Привет! Меня зовут {Surname} {Name}");       
    }
}
