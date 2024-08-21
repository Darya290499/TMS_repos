using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12
{
    public class WrongPasswordException : Exception
    {
        private string _message;
        public string Message { get => _message; set => _message = value; }
        public WrongPasswordException()
        {
            _message = "Ошибка создания пароля";
        }
        public WrongPasswordException(string message) : base(message)
        {
            _message = $"Ошибка создания пароля\n{message}";
        }
    }
}
