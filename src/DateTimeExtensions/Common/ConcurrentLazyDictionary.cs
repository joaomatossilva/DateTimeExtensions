using System;
using System.Collections.Concurrent;

namespace DateTimeExtensions.Common
{
    internal class ConcurrentLazyDictionary<TKey,TValue>
    {
        private ConcurrentDictionary<TKey, Lazy<TValue>> innerDictionary;

        public ConcurrentLazyDictionary()
        {
            innerDictionary = new ConcurrentDictionary<TKey, Lazy<TValue>>();
        }

        public TValue GetOrAdd(TKey key, Func<TValue> valueFactory)
        {
            var lazyValue = innerDictionary.GetOrAdd(key, new Lazy<TValue>(valueFactory));
            return lazyValue.Value;
        }
    }
}
