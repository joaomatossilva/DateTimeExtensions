using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions.Common
{
#if NET35
    public class Lazy<T>
    {
        private bool _initialized;
        private readonly Func<T> _initializer;
        private T _value;

        public Lazy(Func<T> initializer)
        {
            _initializer = initializer;
        }

        public T Value
        {
            get
            {
                if (!_initialized)
                {
                    lock (this)
                    {
                        if (!_initialized)
                        {
                            _value = _initializer();
                            _initialized = true;
                        }
                    }
                }

                return _value;
            }
        }

        public bool IsValueCreated => _initialized;
    }
#endif
}
