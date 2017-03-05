using System.Globalization;

namespace DateTimeExtensions.Tests
{
    public static class TargetFrameworkExtensions
    {
        public static void SetCurrentCultureInfo(this CultureInfo cultureInfo)
        {
#if NET451
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
#else
            CultureInfo.CurrentCulture = cultureInfo;
#endif
        }

        public static void SetCurrentUICultureInfo(this CultureInfo cultureInfo)
        {
#if NET451
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
#else
            CultureInfo.CurrentUICulture = cultureInfo;
#endif
        }
    }
}
