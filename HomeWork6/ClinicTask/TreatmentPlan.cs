namespace HomeWork6.ClinicTask
{
    public class TreatmentPlan
    {
        public int TreatmentCode { get; set; }
        public string TreatmentMethod { get; set; }
        public Doctor AssignDoctor { get; set; }

        public TreatmentPlan() { }

        public TreatmentPlan(int treatmentCode)
        {
            TreatmentCode = treatmentCode;
        }

        public void SetDoctor(Doctor doctor)
        {
            AssignDoctor = doctor;
            Console.WriteLine("\nВведите метод лечения:");
            TreatmentMethod = Console.ReadLine();
        }

        public void Heal()
        {
            Console.WriteLine($"\nЛечение производит врач {AssignDoctor.Name} {AssignDoctor.Surname}");
            Console.WriteLine($"Специализация врача: {AssignDoctor.Specialization}");
            Console.WriteLine($"Лечение происходит согласно следующему плану:");
            Console.WriteLine($"Код плана: {TreatmentCode}\nОписание метода лечения:\n{TreatmentMethod}");
        }

    }
}
