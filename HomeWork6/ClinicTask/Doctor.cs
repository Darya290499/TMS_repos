namespace HomeWork6.ClinicTask
{
    public class Doctor
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Doctor() { }

        public Doctor(string surname, string name, string specialization)
        {
            Surname = surname;
            Name = name;
            Specialization = specialization;
        }

        public void Output()
        {
            Console.WriteLine($"\nВрач: {Name} {Surname}");
            Console.WriteLine($"Специализация врача: {Specialization}");
        }
    }
}
/*Пусть в клинике будет три врача: хирург, терапевт и дантист.
Каждый врач имеет метод «лечить», но каждый врач лечит по-своему.
Так же предусмотреть класс «Пациент» и класс «План лечения».
Создать объект класса «Пациент» и добавить пациенту план лечения.
Так же создать метод, который будет назначать врача пациенту согласно
плану лечения.
Если план лечения имеет код 1 – назначить хирурга и выполнить метод
лечить.
Если план лечения имеет код 2 – назначить дантиста и выполнить метод
лечить.
Если план лечения имеет любой другой код – назначить терапевта и
выполнить метод лечить.*/
