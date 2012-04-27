using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class HolidayStrategyLocatorByName {
		private const string HOLIDAY_STRATEGY_NAME = "HolidayStrategy";
		private const string NATURAL_TIME_STRATEGY_NAME = "NaturalTimeStrategy";
		private const string WORKINGDAYOFWEEK_STRATEGY_NAME = "WorkingDayOfWeekStrategy";
		private const string NAMESPACE = "DateTimeExtensions.Strategies";

		public static IHolidayStrategy LocateHolidayStrategyForName(string name) {
			string strategyPrefix = name.ToUpperInvariant().Replace("-", "_");
			string strategyName = NAMESPACE + "." + strategyPrefix + HOLIDAY_STRATEGY_NAME;
			IHolidayStrategy holidayStrategy = CreateObjectInstance<IHolidayStrategy>(strategyName);
			if (holidayStrategy == null) {
				holidayStrategy = new DefaultHolidayStrategy();
			}
			return holidayStrategy;
		}

		public static IWorkingDayOfWeekStrategy LocateDayOfWeekStrategyForName(string name) {
			string strategyPrefix = name.ToUpperInvariant().Replace("-", "_");
			string strategyName = NAMESPACE + "." + strategyPrefix + WORKINGDAYOFWEEK_STRATEGY_NAME;
			IWorkingDayOfWeekStrategy workingDayOfWeekStrategy = CreateObjectInstance<IWorkingDayOfWeekStrategy>(strategyName);
			if (workingDayOfWeekStrategy == null) {
				workingDayOfWeekStrategy = new DefaultWorkingDayOfWeekStrategy();
			}
			return workingDayOfWeekStrategy;
		}

		public static INaturalTimeStrategy LocateNaturalTimeStrategyForName(string name) {
			string strategyPrefix = name.ToUpperInvariant().Replace("-", "_");
			string strategyName = NAMESPACE + "." + strategyPrefix + NATURAL_TIME_STRATEGY_NAME;
			var naturalTimeStrategy = CreateObjectInstance<INaturalTimeStrategy>(strategyName);
			if (naturalTimeStrategy == null) {
				naturalTimeStrategy = new DefaultNaturalTimeStrategy();
			}
			return naturalTimeStrategy;
		}

		private static T CreateObjectInstance<T>(string typeName) {
			if (typeName == null) {
				throw new ArgumentNullException("typeName");
			}
			Type type = Type.GetType(typeName);
			if (type == null) {
				//throw new StrategyNotFoundException(string.Format("Type name '{0}' was not found.", typeName));
				return default(T);
			}
			T instance = (T)Activator.CreateInstance(type);
			if (instance == null) {
				//throw new StrategyNotFoundException(string.Format("Could not create a new instance of type '{0}'.", typeName));
				return default(T);
			}
			return instance;
		}		
	}
}
