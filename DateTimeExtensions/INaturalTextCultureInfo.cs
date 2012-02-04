using System;

namespace DateTimeExtensions {
	public interface INaturalTextCultureInfo {
		string ToNaturalText(TimeSpan span, bool round);
		string ToExactNaturalText(TimeSpan span);
	}
}
