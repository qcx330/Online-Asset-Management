using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssetManagement.ManageAssetUtils
{
    public class Utils
    {
        private static readonly Random Random = new Random();
        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            return regex.Replace(normalizedString, string.Empty);
        }
        public static string FormatDate(string date)
        {
            if (date.Length != 8)
            {
                throw new ArgumentException("Date string must be exactly 8 characters long.");
            }
            string month = date.Substring(0, 2);
            string day = date.Substring(2, 2);
            string year = date.Substring(4, 4);
            return $"{day}/{month}/{year}";
        }
        public static string FormatUsername(string firstName, string lastName)
        {
            string normalizedFirstName = RemoveDiacritics(firstName).ToLower();
            string normalizedLastName = RemoveDiacritics(lastName).ToLower();

            string[] lastNameParts = normalizedLastName.Split(' ');
            string formattedName = normalizedFirstName;
            foreach (string part in lastNameParts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    formattedName += part[0];
                }
            }
            return formattedName;
        }
        public static string FormatAssetName(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string[] words = input.ToLower().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }

            return string.Join(' ', words);
        }
        public static string NameToPrefix(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var acronym = string.Concat(words.Select(word => char.ToUpper(word[0])));

            return acronym;
        }
        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue + 1); 
        }
        public static string GetFirstNameFromFullName(string input)
        {
            string[] words = input.Split(' ');
            if (words.Length > 0)
            {
                return words[0];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}