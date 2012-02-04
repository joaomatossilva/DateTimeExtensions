using System;

namespace DateTimeExtensions.Strategies {
	public interface INaturalTimeStrategy {
		string ToNaturalText(DateDiff dateDiff, bool round);
		string ToExactNaturalText(DateDiff dateDiff);
	}
}
