using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies {
	public class NaturalTextStrategyLocatorByName {

		public static INaturalTimeStrategy LocateNaturalTimeStrategyForName(string name) {
			return LocaleImplementationLocator.FindImplementationOf<INaturalTimeStrategy>(name) ?? new DefaultNaturalTimeStrategy();
		}
	}
}
