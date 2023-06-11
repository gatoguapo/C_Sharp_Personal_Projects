using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public class Validations
    {
        public bool emptyTxt(string txt)
        {
            return string.IsNullOrEmpty(txt);
        }

        public bool domainEmailValidation(string email)
        {
            string dominiosValidos = @"\.com$|\.org$|\.net$|\.edu$";
            Regex regex = new Regex(dominiosValidos);

            return regex.IsMatch(email);
        }

        public bool minLengthPasswordValidated(string password)
        {
            return password.Length >= 5;
        }
    }
}
