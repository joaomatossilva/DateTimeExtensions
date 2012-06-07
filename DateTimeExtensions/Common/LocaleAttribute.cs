using System;

namespace DateTimeExtensions.Common {
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class LocaleAttribute : Attribute{

		public string Locale { get; private set; }

		public LocaleAttribute(string locale) {
			Locale = locale;
		}
	}
}
