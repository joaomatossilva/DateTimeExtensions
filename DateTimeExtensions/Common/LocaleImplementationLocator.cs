using System;
using System.Linq;

namespace DateTimeExtensions.Common {
	public static class LocaleImplementationLocator {

		public static T FindImplementationOf<T>(string locale) {
			var type = typeof(T);
			var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
				.SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && 
					p.GetCustomAttributes(typeof(LocaleAttribute), false).Any(a => ((LocaleAttribute)a).Locale.Equals(locale)));
			
			var implementationType = types.FirstOrDefault();
			if (implementationType == null) {
				return default(T);
			}

			var instance = (T)Activator.CreateInstance(implementationType);
			if (instance == null) {
				//throw new StrategyNotFoundException(string.Format("Could not create a new instance of type '{0}'.", typeName));
				return default(T);
			}
			return instance;
		}
	}
}
