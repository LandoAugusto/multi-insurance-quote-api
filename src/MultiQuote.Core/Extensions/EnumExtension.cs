using System.ComponentModel;

namespace MultiQuoteApi.Core.Extensions
{
    public static class EnumExtension
    {

        public static T ParseEnum<T>(this string value) where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        public static T ParseFromDefaultValue<T>(this string value) where T : struct
        {
            try
            {
                var list = System.Enum.GetValues(typeof(T));
                foreach (var item in list)
                {
                    var enumType = item.GetType();
                    var field = enumType.GetField(item.ToString());
                    var attributes = field.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                    if (((DefaultValueAttribute)attributes[0]).Value.Equals(value))
                    {
                        return (T)item;
                    }
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public static string GetEnumDescription<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
        {
            try
            {

                // variables  
                var enumType = value.GetType();
                var field = enumType.GetField(value.ToString());
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                // return  
                return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;

            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ToDescription(this System.Enum value)
        {
            try
            {
                var enumType = value.GetType();
                var field = enumType.GetField(value.ToString());
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ToDefaultValue(this System.Enum value)
        {
            try
            {
                var enumType = value.GetType();
                var field = enumType.GetField(value.ToString());
                var attributes = field.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                return attributes.Length == 0 ? value.ToString() : ((DefaultValueAttribute)attributes[0]).Value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
