using System;

namespace Kinvo.Utilities.Exceptions
{
    public class CriticalException : Exception
    {
        public CriticalException()
            : base() { }

        public CriticalException(string message)
            : base(message) { }

        public CriticalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public CriticalException(string message, Exception innerException)
            : base(message, innerException) { }

        public CriticalException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

}
