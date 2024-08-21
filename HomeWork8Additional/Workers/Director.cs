namespace HomeWork8Additional.Workers
{
    public class Director : Worker
    {
        public List<Worker> Subordinates {  get; set; }

        public Director() : base()
        {
            Post = "Директор";
        }

        public Director(string surname, string name, string post, string department, List<Worker> subordinates)
           : base(surname, name, post, department)
        {
            Post = "Директор";
            Subordinates = subordinates;
        }
    }
}
