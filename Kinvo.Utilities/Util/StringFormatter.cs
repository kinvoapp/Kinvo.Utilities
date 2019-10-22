using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Utilities.Util
{
    public static class StringFormatter
    {
        ///
        /// Format a value under mask
        ///
        /// Mask ex.:##/##/#### ou ##.###,##
        public static string Format(string value, string mask)
        {
            StringBuilder dado = new StringBuilder();
            // Remove NaN character
            foreach (char c in value)
            {
                if (Char.IsNumber(c))
                    dado.Append(c);
            }
            int indMascara = mask.Length;
            int indCampo = dado.Length;
            for (; indCampo > 0 && indMascara > 0; )
            {
                if (mask[--indMascara] == '#')
                    indCampo--;
            }
            StringBuilder saida = new StringBuilder();
            for (; indMascara < mask.Length; indMascara++)
            {
                saida.Append((mask[indMascara] == '#') ? dado[indCampo++] : mask[indMascara]);
            }
            return saida.ToString();
        }

        ///
        /// Format a CPF to mask ###.###.###-##
        ///
        public static string FormatCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return string.Empty;

            cpf = "00000000000" + cpf;
            cpf = cpf.Substring(cpf.Length - 11, 11);
            
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "");
            return Format(cpf, "###.###.###-##");
        }

        ///
        /// Format a CNPJ to mask ##.###.###/####-##
        ///
        public static string FormatCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return string.Empty;

            cnpj = "00000000000000" + cnpj;
            cnpj = cnpj.Substring(cnpj.Length - 14, 14);

            cnpj = cnpj.Replace("-", "").Replace("/", "").Replace(".", "");
            return Format(cnpj, "##.###.###/####-##");
        }

        /// <summary>
        /// Remove all non-numeric characters
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string ClearMask(string token)
        {
            if (!string.IsNullOrEmpty(token))
                return token
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "")
                    .Replace(")", "")
                    .Replace("(", "")
                    .Replace(" ", string.Empty);
            else
                return null;
        }

        /// <summary>
        /// Remove diacritics from a string. Ex.: RemoveDiacritics("Héllo") => "Hello"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string LimitString(string str, int limit, string sufix)
        {
            if (str.Length >= limit)
                return str.Substring(0, limit) + "...";

            return str;
        }
    }
}
