using System.Collections.Generic;

namespace DateTimeExtensions.Common
{
    public static class DictionaryExtensions
    {
        public static void AddIfInexistent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }
    }
}
