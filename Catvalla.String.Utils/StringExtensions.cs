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
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string str, string findString, string replaceString)
        {
            string sourceLowerString = str.ToLower();
            string lowerFindString = findString.ToLower();

            if (lowerFindString != replaceString.ToLower())
            {
                if (sourceLowerString.Contains(lowerFindString))
                {
                    int firstIndex = sourceLowerString.IndexOf(lowerFindString);

                    str = str.Remove(firstIndex, lowerFindString.Length);

                    str = str.Insert(firstIndex, replaceString);
                    
                    sourceLowerString = str.ToLower();

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
        /// <returns></returns>
        public static string RemoveIgnoreCase(this string str, string findString)
        {
            string sourceLowerString = str.ToLower();
            string lowerFindString = findString.ToLower();

            if (sourceLowerString.Contains(lowerFindString))
            {
                int firstIndex = sourceLowerString.IndexOf(lowerFindString);

                str = str.Remove(firstIndex, lowerFindString.Length);

                sourceLowerString = str.ToLower();

                firstIndex = sourceLowerString.IndexOf(lowerFindString);

                if (firstIndex >= 0)
                {
                    str = str.RemoveIgnoreCase(findString);
                }
            }

            return str;
        }
    }
}
