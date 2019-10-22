using Kinvo.Utilities.Exceptions;
using System;
using System.Collections.Generic;

namespace Kinvo.Utilities.Validations
{
    public class SummaryValidator
    {
        private List<string> _errors;

        public SummaryValidator()
        {
            _errors = new List<string>();
        }

        public void NotNull(object theObj, string msg)
        {
            if (theObj == null)
            {
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "A object instance can't be null";
                }

                _errors.Add(msg);
            }
        }

        public void NotNullOrEmpty(string theObj)
        {
            NotNullOrEmpty(theObj, null);
        }

        public void NotNullOrEmpty(string theObj, string msg)
        {
            if (String.IsNullOrEmpty(theObj))
            {
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "A object instance can't be null";
                }

                _errors.Add(msg);
            }
        }

        public void NotNull(object theObj)
        {
            NotNull(theObj, null);
        }

        public void IsTrue(bool isTrue, string msg)
        {
            if (!isTrue)
            {
                _errors.Add(msg);
            }
        }

        public void GreaterThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) > 0)
                return;

            _errors.Add(msg);

        }

        public void LessThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) < 0)
                return;

            _errors.Add(msg);
        }

        public void GreaterOrEqualThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) >= 0)
                return;

            _errors.Add(msg);
        }

        public void LessOrEqualThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) <= 0)
                return;

            _errors.Add(msg);
        }

        public void EqualThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) == 0)
                return;

            _errors.Add(msg);
        }

        public void NotEqualThan(IComparable theObj, IComparable compareValue, string msg)
        {
            if (theObj.CompareTo(compareValue) != 0)
                return;

            _errors.Add(msg);
        }

        public void Length(string text, int minLength, int maxLength, string msg)
        {
            if (text.Length >= minLength && text.Length <= maxLength)
                return;

            _errors.Add(msg);
        }

        public void NoNullElements(object[] objects)
        {
            foreach (object obj in objects)
            {
                NotNull(obj);
            }
        }

        public void NoNullElements<T>(IList<T> objects)
        {
            foreach (object obj in objects)
            {
                NotNull(obj);
            }
        }

        public void NotEmpty<T>(IList<T> objects, string msg)
        {
            if (objects == null || objects.Count == 0)
            {
                _errors.Add(msg);
            }
        }

        public void DateTime(string date)
        {
            DateTime(date, string.Empty);
        }
        public void DateTime(string date, string errorMessage)
        {
            DateTime result = System.DateTime.MinValue;

            var message = !String.IsNullOrEmpty(errorMessage) ? errorMessage : "Invalid date time!";

            IsTrue(System.DateTime.TryParse(date, out result), message);
        }


        public void Validate()
        {
            if (_errors.Count > 0)
                throw new BusinessException(_errors);
        }
    }
}
