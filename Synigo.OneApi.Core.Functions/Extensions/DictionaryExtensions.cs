using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Primitives;
using Synigo.OneApi.Common.Extensions;
using Synigo.OneApi.Model.Requests;

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

        public static Nullable<T> GetDataOrNull<T>(this Dictionary<string, StringValues> dict, string key)
           where T : struct
        {
            if (!dict.ContainsKey(key) || string.IsNullOrEmpty(dict[key].FirstOrDefault()))
                return null;

            return (T)Convert.ChangeType(dict[key].FirstOrDefault(), typeof(T));
        }

        public static List<T> GetEnumListValues<T>(this Dictionary<string, StringValues> dict, string key)
         where T : Enum
        {
            return dict.ContainsKey(key) && dict[key].Count() > 0 ?
                dict[key].Select(s => s.GetEnumValue<T>()).ToList() : new List<T>();
        }

        public static List<string> GetStringListValues(this Dictionary<string, StringValues> dict, string key)
        {
            return dict.ContainsKey(key) ?
                dict[key].ToList() : new List<string>();
        }

        public static Guid? GetGuidValueOrNull(this Dictionary<string, StringValues> dict, string key)
        {
            if (!dict.ContainsKey(key) || string.IsNullOrEmpty(dict[key].FirstOrDefault()))
                return null;

            if (!Guid.TryParse(dict[key].FirstOrDefault(), out var result))
                return null;

            return result;
        }

        public static PageRequest<T> GetPageRequest<T>(this Dictionary<string, StringValues> dict)
          where T : class, new()
        {
            var request = new PageRequest<T>() { Request = new T() };
            request.PageNumber = dict.ContainsKey("pageNumber") ? Convert.ToInt32(dict["pageNumber"].First()) : 1;
            request.PageSize = dict.ContainsKey("pageSize") ? Convert.ToInt32(dict["pageSize"].First()) : 10;
            request.Sort = dict.ContainsKey("sort") ? dict["sort"].ToList() : new List<string>();

            return request;
        }
    }
}
