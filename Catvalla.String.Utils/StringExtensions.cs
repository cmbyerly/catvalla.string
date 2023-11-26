using System;
using System.Text;

namespace Catvalla.String.Utils
{
    /// <summary>
    /// Some string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces in the string while ignoring the case on find.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="findString">The find string.</param>
        /// <param name="replaceString">The replace string.</param>
        /// <returns>The string with the replaced values.</returns>
        public static string ReplaceIgnoreCase(this string str, string findString, string replaceString)
        {
            string sourceLowerString = str.ToLowerInvariant();
            string lowerFindString = findString.ToLowerInvariant();

            if (lowerFindString != replaceString.ToLowerInvariant())
            {
                if (sourceLowerString.Contains(lowerFindString))
                {
                    int firstIndex = sourceLowerString.IndexOf(lowerFindString);

                    str = str.Remove(firstIndex, lowerFindString.Length);

                    str = str.Insert(firstIndex, replaceString);
                    
                    sourceLowerString = str.ToLowerInvariant();

                    firstIndex = sourceLowerString.IndexOf(lowerFindString);

                    if (firstIndex >= 0)
                    {
                        str = str.ReplaceIgnoreCase(findString, replaceString);
                    }
                }
            }
            else
            {
                str = str.Replace(findString, replaceString);
            }
            
            return str;
        }

        /// <summary>
        /// Removes the find string value while ignoring the case on find.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="findString">The find string.</param>
        /// <returns>The string without the wanted values.</returns>
        public static string RemoveIgnoreCase(this string str, string findString)
        {
            string sourceLowerString = str.ToLowerInvariant();
            string lowerFindString = findString.ToLowerInvariant();

            if (sourceLowerString.Contains(lowerFindString))
            {
                int firstIndex = sourceLowerString.IndexOf(lowerFindString);

                str = str.Remove(firstIndex, lowerFindString.Length);

                sourceLowerString = str.ToLowerInvariant();

                firstIndex = sourceLowerString.IndexOf(lowerFindString);

                if (firstIndex >= 0)
                {
                    str = str.RemoveIgnoreCase(findString);
                }
            }

            return str;
        }

        /// <summary>
        /// Camel cases the string. It also strips the special characters from the string.
        /// This is a helper so I can build out a set of property names from column names.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The case string sans the special characters</returns>
        public static string ToCamelCase(this string str)
        {
            StringBuilder camelString = new StringBuilder();

            List<string> parts = new List<string>();

            StringBuilder partBuilder = new StringBuilder();

            foreach (Rune rune in str.AsSpan().EnumerateRunes())
            {
                if (Rune.IsLetterOrDigit(rune))
                {
                    partBuilder.Append(rune.ToString());
                }
                else
                {
                    parts.Add(partBuilder.ToString());
                    partBuilder = new StringBuilder();
                }
            }

            parts.Add(partBuilder.ToString());

            for (int i = 0; i < parts.Count; i++)
            {
                string temp;

                if (i > 0)
                {
                    temp = parts[i].ToLowerInvariant();
                    temp = temp.Substring(0, 1).ToUpperInvariant() + temp.Substring(1, temp.Length - 1);
                }
                else
                {
                    temp = parts[i].ToLowerInvariant();
                }

                camelString.Append(temp);
            }

            return camelString.ToString();
        }

        /// <summary>
        /// Pascal cases the string. It also strips the special characters from the string.
        /// This is a helper so I can build out a set of property names from column names.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The case string sans the special characters</returns>
        public static string ToPascalCase(this string str)
        {
            StringBuilder camelString = new StringBuilder();

            List<string> parts = new List<string>();

            StringBuilder partBuilder = new StringBuilder();

            foreach (Rune rune in str.AsSpan().EnumerateRunes())
            {
                if (Rune.IsLetterOrDigit(rune))
                {
                    partBuilder.Append(rune.ToString());
                }
                else
                {
                    parts.Add(partBuilder.ToString());
                    partBuilder = new StringBuilder();
                }
            }

            parts.Add(partBuilder.ToString());

            for (int i = 0; i < parts.Count; i++)
            {
                string temp;

                temp = parts[i].ToLowerInvariant();
                temp = temp.Substring(0, 1).ToUpperInvariant() + temp.Substring(1, temp.Length - 1);

                camelString.Append(temp);
            }

            return camelString.ToString();
        }
    }
}
