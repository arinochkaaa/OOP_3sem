using System;
using System.Collections.Generic;

namespace lab8
{
    public static class StringProcessor
    {
        public static string ProcessString(string input, List<Func<string, string>> processors)
        {
            string result = input;
            foreach (var processor in processors)
            {
                result = processor(result);
            }
            return result;
        }

        public static string RemovePunctuation(string input)
        {
            char[] punctuation = { '.', ',', '!', '?', ';', ':' };
            foreach (var symbol in punctuation)
            {
                input = input.Replace(symbol.ToString(), "");
            }
            return input;
        }

        public static string TrimSpaces(string input)
        {
            return input.Trim();
        }

        public static string ConvertToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string AddSymbols(string input)
        {
            return $"[обработано] {input}";
        }

        public static string ReplaceSpaces(string input)
        {
            return input.Replace(" ", "_");
        }
    }
}
