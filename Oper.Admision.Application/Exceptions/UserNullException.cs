using System.Runtime.Serialization;

namespace Oper.Admision.Application.Exceptions
{
    [Serializable]
    public class UserNullException : Exception
    {
        private object p;

        public UserNullException()
        {
        }

        public UserNullException(object p)
        {
            this.p = p;
        }

        public UserNullException(string message) : base(message)
        {
        }

        public UserNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}