namespace HomeWork12
{
    public class WrongLoginException : Exception
    {
        private string _message;
        public string Message { get => _message; set => _message = value; }
        public WrongLoginException()
        {
            Message = "Ошибка создания логина";
        }
        public WrongLoginException(string message) : base(message)
        {
            Message = $"Ошибка создания логина\n{message}";
        }
    }
}
