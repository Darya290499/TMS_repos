namespace HomeWork9.Task2
{
    public class Teacher : Person
    { 
        public string Subject { get; set; }
        public Teacher() : base() { }

        public Teacher(string name, string surname, string sex, string subject) : base(name, surname, sex)
        {
            Subject = subject;
        }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine($"Я учитель");
        }
        public void Explain() => Console.WriteLine($"Я преподаю предмет \"{Subject}\"");
    }
}