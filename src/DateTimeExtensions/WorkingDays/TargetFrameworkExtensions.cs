using System;
using System.Collections.Generic;
using System.Reflection;

namespace DateTimeExtensions.WorkingDays
{
    /// <summary>
    /// This is a copy of <see cref="DateTimeExtensions.Common.TargetFrameworkExtensions"/> only with the GetTypeInfo method because
    /// the Resorces are auto-generated and they use this method that doensn't exist on net35
    /// </summary>
    internal static class TargetFrameworkExtensions
    {
#if NET35
        internal static Type GetTypeInfo(this Type type)
        {
            return type;
        }
#endif
    }
}
