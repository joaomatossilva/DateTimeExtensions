using System;

namespace DateTimeExtensions.Strategies {
	public interface INaturalTimeStrategy {
		string ToNaturalText(TimeSpan span, bool round);
		string ToExactNaturalText(TimeSpan span);
	}
}
