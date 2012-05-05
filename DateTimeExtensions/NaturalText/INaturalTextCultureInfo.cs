using System;

namespace DateTimeExtensions.NaturalText {
	public interface INaturalTextCultureInfo {
		string ToNaturalText(DateDiff span, bool round);
		string ToExactNaturalText(DateDiff span);
	}
}
