﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task02._1
{
    internal static class Helper
    {
        private static readonly string patternMatch = @"^\d{3}-\d-\d{2}-\d{6}-\d|\d{13}$";
        private static readonly string hyphenCheck = "-";
        private static readonly string replaceTo = string.Empty;

        public static string UnifyISBN(this string ISBN)
        {
            if (ISBN is null)
            {
                throw new ArgumentNullException("ISBN is null");
            }

            if (Regex.IsMatch(ISBN, patternMatch))
            {
                if (Regex.IsMatch(ISBN, hyphenCheck))
                {
                    return Regex.Replace(ISBN, hyphenCheck, replaceTo);
                }
            }
            else
            {
                throw new FormatException("ISBN has to be digits in either format: XXXXXXXXXXXXX or XXX-X-XX-XXXXXX-X");
            }

            return ISBN;
        }
    }
}
