
using System.Linq;
using System;

namespace ValidationLibrary
{
    public static class StringOperation
    {
        public static string GetValidName(string nameToValidate)
        {
            if (string.IsNullOrEmpty(nameToValidate))
            {
                throw new ArgumentException("Input string is missing or zero-length.");
            }

            nameToValidate = nameToValidate.Trim();

            nameToValidate = new string(nameToValidate
                .Where(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == ' ')
                .ToArray());

            string[] words = nameToValidate.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }
            nameToValidate = string.Join(" ", words);

            if (nameToValidate.Length > 50)
            {
                nameToValidate = nameToValidate.Substring(0, 50);
            }

            if (string.IsNullOrEmpty(nameToValidate))
            {
                throw new ArgumentException("Output string is empty.");
            }

            return nameToValidate;
        }
    }
}