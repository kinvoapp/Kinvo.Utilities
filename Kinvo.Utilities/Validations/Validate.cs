using Kinvo.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kinvo.Utilities.Validations
{
    /// <summary>
    /// Provides a set of assertion checks.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Tests if a object is null.
        /// Throws ArgumentNullException with passed message.
        /// </summary>
        /// <param name="theObj">a object instance</param>
        /// <param name="msg">message to throw if the object is null</param>
        public static void NotNull(object theObj, string msg)
        {
            if (theObj == null)
            {
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "A object instance can't be null";
                }

                throw new BusinessException(msg, new ArgumentNullException(msg));
            }
        }

        /// <summary>
        /// Tests if a string is null or empty.
        /// Throws ArgumentNullException if object is null.
        /// </summary>
        /// <param name="theObj">a object instance</param>      
        public static void NotNullOrEmpty(string theObj)
        {
            NotNullOrEmpty(theObj, null);
        }

        /// <summary>
        /// Tests if a string is null or empty.
        /// Throws ArgumentNullException with passed message.
        /// </summary>
        /// <param name="theObj">a object instance</param>
        /// <param name="msg">message to throw if the object is null</param>
        public static void NotNullOrEmpty(string theObj, string msg)
        {
            if (String.IsNullOrEmpty(theObj))
            {
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "A object instance can't be null";
                }

                throw new BusinessException(msg, new ArgumentNullException(msg));
            }
        }

        /// <summary>
        /// Tests if a object is null.
        /// Throws ArgumentNullException if object is null.
        /// </summary>
        /// <param name="theObj">a object instance</param>      
        public static void NotNull(object theObj)
        {
            NotNull(theObj, null);
        }

        /// <summary>
        /// Tests if provided bool parameter is true.
        /// Throws ArgumentNullException with passed message if value is false.
        /// </summary>
        /// <param name="isTrue">bool value</param>
        /// <param name="msg">message to throw if the object is null</param>
        public static void IsTrue(bool isTrue, string msg)
        {
            if (!isTrue)
            {
                throw new BusinessException(msg, new ArgumentException(msg));
            }
        }

        public static void GreaterThan(IComparable theObj, IComparable compareValue, string msg = null)
        {
            if (theObj.CompareTo(compareValue) > 0)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "A object comparisson is not greater than other";

            throw new BusinessException(msg, new ArgumentException(msg));
        }

        public static void LessThan(IComparable theObj, IComparable compareValue, string msg = null)
        {
            if (theObj.CompareTo(compareValue) < 0)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "A object comparisson is not less than other";

            throw new BusinessException(msg, new ArgumentException(msg));
        }


        public static void GreaterOrEqualThan(IComparable theObj, IComparable compareValue, string msg = null)
        {
            if (theObj.CompareTo(compareValue) >= 0)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "A object comparisson is not greater or equal than other";

            throw new BusinessException(msg, new ArgumentException(msg));
        }

        public static void LessOrEqualThan(IComparable theObj, IComparable compareValue, string msg = null)
        {
            if (theObj.CompareTo(compareValue) <= 0)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "A object comparisson is not less or equal than other";

            throw new BusinessException(msg, new ArgumentException(msg));
        }

        public static void EqualThan(IComparable theObj, IComparable compareValue, string msg = null)
        {
            if (theObj.CompareTo(compareValue) == 0)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "A object comparisson is not equal than other";

            throw new BusinessException(msg, new ArgumentException(msg));
        }

        public static void Length(string text, int minLength, int maxLength, string msg = null)
        {
            if (text.Length >= minLength && text.Length <= maxLength)
                return;

            if (String.IsNullOrEmpty(msg))
                msg = "Text is out of length limits.";

            throw new BusinessException(msg, new ArgumentException(msg));
        }

        /// <summary>
        /// Tests if provided array of objects doesnt contain null values.
        /// Throws ArgumentNullException if it has null value.
        /// </summary>
        /// <param name="objects">array of objects</param>
        public static void NoNullElements(object[] objects)
        {
            foreach (object obj in objects)
            {
                NotNull(obj);
            }
        }

        /// <summary>
        /// Tests if provided list of objects doesnt contain null values.
        /// Throws ArgumentNullException if it has null value.
        /// </summary>
        /// <param name="objects">list of objects</param>
        public static void NoNullElements<T>(IList<T> objects)
        {
            foreach (object obj in objects)
            {
                NotNull(obj);
            }
        }

        /// <summary>
        /// Tests if provided list of objects is not null or empty.
        /// Throws ArgumentNullException if it is null or is empty.
        /// </summary>
        /// <param name="objects">list of objects</param>
        public static void NotEmpty<T>(IList<T> objects, string msg)
        {
            if (objects == null || objects.Count == 0)
            {
                throw new BusinessException(msg, new ArgumentException(msg));
            }
        }

        /// <summary>
        /// Test if a mail address is valid
        /// </summary>
        /// <param name="email">mail adress</param>
        public static bool IsValidEmail(string emailAddress)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,8}|[0-9]{1,8})(\]?)$";

            Regex rg = new Regex(strRegex);

            return rg.IsMatch(emailAddress);

            //try
            //{
            //    var addr = new System.Net.Mail.MailAddress(emailAddress);
            //    return addr.Address == emailAddress;
            //}
            //catch
            //{
            //    return false;
            //}

        }

        /// <summary>
        /// Test if a string contains only alphanumeric caracters
        /// </summary>
        public static bool IsValidAlphaNumeric(string inputStr)
        {
            //make sure the user provided us with data to check
            //if not then return false
            if (string.IsNullOrEmpty(inputStr))
                return false;

            //now we need to loop through the string, examining each character
            for (int i = 0; i < inputStr.Length; i++)
            {
                //if this character isn't a letter and it isn't a number then return false
                //because it means this isn't a valid alpha numeric string
                if (!(char.IsLetter(inputStr[i])) && (!(char.IsNumber(inputStr[i]))))
                    return false;
            }
            //we made it this far so return true
            return true;
        }

        /// <summary>
        /// Test if a CPF is valid
        /// </summary>
        public static bool IsValidCPF(string vrCPF)
        {
            string value = vrCPF.Replace(".", "");
            value = value.Replace("-", "");
            value = "00000000000" + value;
            value = value.Substring(value.Length - 11, 11);

            if (value.Length != 11)
                return false;

            bool equal = true;

            for (int i = 1; i < 11 && equal; i++)
                if (value[i] != value[0])
                    equal = false;

            if (equal || value == "12345678909")
                return false;

            int[] numbers = new int[11];

            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(
                  value[i].ToString());

            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];

            int result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;
            }
            else
                if (numbers[10] != 11 - result)
                return false;

            return true;
        }

        /// <summary>
        /// Test if a CNPJ is valid
        /// </summary>
        /// <param name="vrCNPJ"></param>
        /// <returns></returns>
        public static bool IsValidCNPJ(string vrCNPJ)
        {
            if (string.IsNullOrWhiteSpace(vrCNPJ)) return false;

            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            CNPJ = CNPJ.Replace(" ", "");
            CNPJ = CNPJ.ToUpperInvariant();
            CNPJ = "00000000000000" + CNPJ;
            CNPJ = CNPJ.Substring(CNPJ.Length - 14, 14);

            if (!Regex.IsMatch(CNPJ, @"^[A-Z0-9]{12}[0-9]{2}$"))
                return false;

            int ChartToValue(char c)
            {
                if (c >= '0' && c <= '9') return c - '0';
                if (c >= 'A' && c <= 'Z') return c - 48;
                return -1;
            }

            int[] weightDV1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weightDV2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum1 = 0;
            for (int i = 0; i < 12; i++)
            {
                int v = ChartToValue(CNPJ[i]);
                sum1 += v * weightDV1[i];
            }
            int r1 = sum1 % 11;
            int dv1 = (r1 < 2) ? 0 : 11 - r1;

            int sum2 = 0;
            for (int i = 0; i < 12; i++)
            {
                int v = ChartToValue(CNPJ[i]);
                sum2 += v * weightDV2[i];
            }

            sum2 += dv1 * weightDV2[12];
            int r2 = sum2 % 11;
            int dv2 = (r2 < 2) ? 0 : 11 - r2;

            int dvInformed1 = CNPJ[12] - '0';
            int dvInformed2 = CNPJ[13] - '0';

            return dv1 == dvInformed1 && dv2 == dvInformed2;
        }

        public static void DateTime(string date)
        {
            DateTime(date, string.Empty);
        }
        public static void DateTime(string date, string errorMessage)
        {
            DateTime result = System.DateTime.MinValue;

            var message = !String.IsNullOrEmpty(errorMessage) ? errorMessage : "Invalid date time!";

            IsTrue(System.DateTime.TryParse(date, out result), message);
        }

        public static bool IsTextOnly(string text)
        {
            return System.Text.RegularExpressions.Regex.Matches(text, @"[a-zA-Z]").Count > 0;
        }
    }
}
