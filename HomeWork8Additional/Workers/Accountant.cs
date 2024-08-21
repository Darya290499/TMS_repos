namespace HomeWork8Additional.Workers
{
    public class Accountant : Worker
    { 
        public List<string> AccountingNames = new List<string>();
        public Accountant() : base() 
        {
            Post = "Бухгалтер";
        }

        public Accountant(string surname, string name, string post, string department, List<string> accountingNames)
            : base(surname, name, post, department)
        {
            Post = "Бухгалтер";
            AccountingNames = accountingNames;
        }

        public void GetAccountingNames() =>
            Console.WriteLine($"Список счетов: {String.Join(" ;", AccountingNames)}");

    }
}
