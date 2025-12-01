using System.Text.RegularExpressions;

namespace MultiQuoteApi.Core.Extensions
{
    public static class HelperExtension
    {
        public static string Format(this string format, params object[] args) =>
            string.Format(format, args);

        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        public static string OnlyNumerical(this string value)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(value, "");
        }
        public static string RemoveNonNumeric(this string value)
        {
            var reg = new Regex(@"[^0-9]");
            string ret = reg.Replace(value, string.Empty);
            return ret;
        }

        public static string AddPadLeft(this string value, int count)
        {
            return value.PadLeft(count, '0');
        }

        public static string AddPadLefted(this int value, int count)
        {
            return value.ToString().PadLeft(count, '0');
        }
    }
}

