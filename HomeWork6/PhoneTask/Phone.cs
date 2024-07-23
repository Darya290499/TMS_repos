namespace HomeWork6.PhoneTask
{
    public class Phone
    {
        public string _number;
        public string _model;
        public decimal _weight;

        public Phone() { }

        public Phone(string number, string model)
        {
            _number = number;
            _model = model;
        }

        public Phone(string number, string model, decimal weight) : this(number, model)
        {
            _weight = weight;
        }

        public void RecieveCall(string name) => Console.WriteLine($"\nВам звонит {name}");
        
        public void RecieveCall(string name, string number) => Console.WriteLine($"\nВам звонит {name}\nНомер {number}");

        public string GetNumber() => _number;

        public void SendMessage(string[] numbers)
        {
                Console.WriteLine("\nОтправка сообщения по номерам:");
                foreach (var number in numbers)
                    Console.WriteLine(number);            
        }
        
        public void SendMessage(string[] numbers, string textMessage)
        {
            Console.WriteLine($"\nТекст сообщения:\n{textMessage}\nОтправка по номерам:");
            foreach (var number in numbers)            
                Console.WriteLine(number);            
        }
    }
}