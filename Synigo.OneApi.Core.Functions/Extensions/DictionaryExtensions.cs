using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Primitives;
using Synigo.OneApi.Common.Extensions;

namespace Synigo.OneApi.Core.Functions.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Method returns value by key if key exists , else null
        /// </summary>
        /// <param name="dict">dictionary of key values</param>
        /// <param name="key">key of the value</param>
        /// <returns>value if key exists else null</returns>
        public static string GetStringValueOrNull(this Dictionary<string, StringValues> dict, string key)
        {
            return dict.ContainsKey(key) ? dict[key].FirstOrDefault() : null;
        }

        public static Nullable<T> GetEnumValueNullable<T>(this Dictionary<string, StringValues> dict, string key)
          where T : struct, Enum
        {
            return dict.ContainsKey(key) && !string.IsNullOrEmpty(dict[key].FirstOrDefault())
                ? dict[key].First().GetEnumValueNullable<T>() : null;
        }

    }
}
