using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtension
    {
        public static decimal ToDecimalOrDefault(this string value, decimal defaultValue = 0)
        {
            decimal result;
            return decimal.TryParse(value, out result) ? result : defaultValue;
        }

        public static int ToIntOrDefault(this string value, int defaultValue = 0)
        {
            int result;
            return int.TryParse(value, out result) ? result : defaultValue;
        }

        public static short ToShortOrDefault(this string value, short defaultValue = 0)
        {
            short result;
            return short.TryParse(value, out result) ? result : defaultValue;
        }

        public static int FromAlphabetToInt(this string s)
        {
            var splittedString = s.ToCharArray();
            Array.Reverse(splittedString);
            int index = -1;
            for(int i = 0; i<splittedString.Length; i++)
            {
                var currentCharIndex = char.ToUpper(splittedString[i]) - 64;
                index += currentCharIndex*(int)(Math.Pow(26, i));
            }
            return index;
        }
    }
}
