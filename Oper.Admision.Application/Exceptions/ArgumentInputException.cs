using System.Globalization;

namespace Oper.Admision.Application.Exceptions
{
    public class ArgumentInputException : Exception
    {
        public ArgumentInputException() : base() { }
        public ArgumentInputException(string message) : base(message) { }
        public ArgumentInputException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }

    }
}
