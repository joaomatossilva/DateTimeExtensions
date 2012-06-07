using System;

namespace DateTimeExtensions.NaturalText {
	public interface INaturalTimeStrategy {
		string ToNaturalText(DateDiff dateDiff, bool round);
		string ToExactNaturalText(DateDiff dateDiff);
	}
}
