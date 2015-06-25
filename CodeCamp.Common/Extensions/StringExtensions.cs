
namespace CodeCamp.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Truncate a string to max length, trimming away trailing spaces
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || (str.Length <= maxLength))
                return str;
            return str.Substring(0, maxLength).TrimEnd(' ');
        }

        /// <summary>
        /// Truncate a string if greater than specified length.  If specified max length
        /// less than 5, and string is greater than max length, simply truncate.
        /// If specified max length is greater than 4, string is truncated to specified max length - 3, 
        /// trailing spaces are timmed, and elipses are added.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TruncateWithElipses(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || (maxLength <= 0))
                return str;
            if (maxLength < 5)
                return Truncate(str, maxLength);
            if (str.Length <= maxLength)
                return str;

            int trimLen = str.Substring(0, (maxLength - 3)).LastIndexOf(' ');
            if ((maxLength - trimLen) > (maxLength / 2))
                trimLen = (maxLength - 3);

            return string.Concat(str.Substring(0, (trimLen)).TrimEnd(' '), "...");
        }
    }
}
