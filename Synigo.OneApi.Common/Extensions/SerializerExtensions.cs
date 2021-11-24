using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Synigo.OneApi.Common.Extensions
{
    public static class SerializerExtensions
    {
        /// <summary>
        /// Extension method to deserialize strings and to be able to use just the one implemention so we
        /// can easily change serializer (if wanted)
        /// </summary>
        /// <typeparam name="T">The type of object to return</typeparam>
        /// <param name="serializedData">The data to deserialize</param>
        /// <exception cref="JsonException">When deserialization fails</exception>
        /// <returns>An instance of T</returns>
        /// 
        public static T Deserialize<T>(this string str)
        {
            return str == null
                ? default(T)
                : JsonSerializer.Deserialize<T>(str);
        }

        /// <summary>
        /// Extension method to serialize data 
        /// </summary>
        /// <param name="instance">The instance to serialize</param>
        /// <exception cref="JsonException">When serialization fails</exception>
        /// <returns>a string version of the instance</returns>
        public static string Serialize<T>(this T obj)
        {
            if (obj == null) return "";
            return JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// Extension method to serialize enums to string values
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="enumerations"></param>
        /// <returns></returns>
        public static string SerializeEnumeration<T>(this ICollection<T> enumerations)
          where T : Enum
        {
            if (enumerations == null)
                return "";
            return JsonSerializer.Serialize(enumerations.Select(e => e.EnumToEnumMemberValue()).ToList());
        }

        /// <summary>
        /// Extension method to deserialize string to collection of enum values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<T> DeserializeEnumCollection<T>(this string str)
          where T : Enum
        {
            return str == null
                ? new List<T>()
                : JsonSerializer.Deserialize<ICollection<string>>(str).Select(e => e.EnumMemberValueToEnum<T>()).ToList();
        }
    }
}
