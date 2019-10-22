using System;
using System.Collections.Generic;

namespace Kinvo.Utilities.Exceptions
{
    public class BusinessException : Exception
    {
        public List<string> BusinessErrors { get; set; }
        public int ErrorCode { get; set; }

        public BusinessException()
            : base() { }

        public BusinessException(string message)
            : base(message) { }

        public BusinessException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException) { }

        public BusinessException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        public BusinessException(List<string> errors)
             : base(String.Join(" | ", errors))
        {
            this.BusinessErrors = errors;
        }

        public BusinessException(List<string> message, int error_code)
            : base(String.Join(" | ", message))
        {
            this.BusinessErrors = message;
            this.ErrorCode = error_code;
        }
    }

}
