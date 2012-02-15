using System;

namespace DateTimeExtensions {
	public interface INaturalTextCultureInfo {
		string ToNaturalText(DateDiff span, bool round);
		string ToExactNaturalText(DateDiff span);
	}
}
