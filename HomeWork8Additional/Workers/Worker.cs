namespace HomeWork8Additional.Workers
{
    public class Worker : IPost
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Post {  get; set; }
        public string Department { get; set; }

        public Worker() { }
        public Worker(string surname, string name, string post, string department)
        {
            Surname = surname;
            Name = name;
            Post = post;
            Department = department;
        }

        public void GetSurnameName() => Console.WriteLine($"Фамилия и имя: {Surname} {Name}");
        public void GetPost() => Console.WriteLine($"Должность: {Post}");
        public void GetDep() => Console.WriteLine($"Отдел: {Department}");


    }
}
