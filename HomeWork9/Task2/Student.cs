namespace HomeWork9.Task2
{
    public class Student : Person
    {
        public Student() : base() { }

        public Student(string name, string surname, string sex) : base(name, surname, sex) { }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine($"Я студент{(Sex == "М" ? string.Empty : "ка")}");
        }

        public void ShowAge()
        {
            var lastNum = Age % 10;
            string years = string.Empty;
            switch (lastNum)
            {
                case 1:
                    years = "год";
                    break;
                case 2 or 3 or 4:
                    years = "года";
                    break;
                default:
                    years = "лет";
                    break;
            }
            Console.WriteLine($"Мой возраст: {Age} {years}");
        }

    }
}