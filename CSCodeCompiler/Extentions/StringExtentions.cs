using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Extentions
{ 
    public static class StringExtentions
    {
        public static string RemoveAsChars(this string stringParam, string removeChars)
        {
            var chars = removeChars.ToCharArray();
            foreach (var ch in chars) 
                stringParam = stringParam.Replace(ch.ToString(),""); 
            return stringParam;
        }
        public static string ReverseString(this string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        public static string ReplaceWhitespace(this string input, string ReplaceWith)
        {
            do
            {
                input = input.Replace(" ", ReplaceWith);
            } while (input.Contains(" ")); 
            return input;
        }
        public static string RemoveWhiteAndBreaks(this string input, string ReplaceWith)
        {
            do
            {
                input = input.Replace(" ", "");
            } while (input.Contains(" "));
            input = input.Replace("\n", "").Replace("\r", "");
            return input;
        }
    }
}
