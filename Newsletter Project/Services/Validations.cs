using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public class Validations
    {
        public static bool emptyTxt(string txt)
        {
            return string.IsNullOrEmpty(txt);
        }

        public static int emailFormatValidation(string email)
        {
            string dominiosValidos = @"\.com$|\.org$|\.net$|\.edu$";
            Regex regex = new Regex(dominiosValidos);
            if (!email.Contains("@"))
            {
                return 1;
            }
            if (!regex.IsMatch(email))
            {
                return 2;
            }
            return 0;
        }

        public static bool minLengthPasswordValidated(string password)
        {
            return password.Length < 5;
        }
    }
}
