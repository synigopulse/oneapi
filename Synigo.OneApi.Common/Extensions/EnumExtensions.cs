using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Synigo.OneApi.Common.Extensions
{
    public static class EnumExtensions
    {

        public static T GetEnumValue<T>(this string val)
            where T : Enum
        {
            return (T)Enum.Parse(typeof(T), val, true);
        }

        public static Nullable<T> GetEnumValueNullable<T>(this string val)
            where T : struct, Enum

        {
            if (!Enum.TryParse<T>(val, true, out var returnVal))
                return null;

            return returnVal;
        }

        public static string EnumToEnumMemberValue<T>(this T val)
           where T : Enum
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, val);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }

        public static T EnumMemberValueToEnum<T>(this string str)
            where T : Enum
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }

            return default(T);
        }
    }
}
