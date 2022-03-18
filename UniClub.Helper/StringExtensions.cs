using System.Linq;
using System.Text.RegularExpressions;

namespace UniClub.Helpers
{
    public static class StringExtensions
    {
        public static string FromPascalToKebabCase(this string value)
            => value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();

        public static string FromPascalToSnakeCase(this string value) =>
           Regex.Replace(value, @"(\w)([A-Z])", "$1_$2").ToLower();

        public static string FromKebabToPascalCase(this string kebabCase)
        {
            var x = string.Join(string.Empty, kebabCase.Split('-').Select(str => str.Length > 0 ? char.ToUpper(str[0]) + str.Substring(1) : str));
            return x;
        }

    }
}
