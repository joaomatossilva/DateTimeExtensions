using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class ES_ARHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		private static readonly IEnumerable<Holiday> TuristicHolidays =
			new Holiday[] { 
				ChristianHolidays.NewYear, 
				//The day before the carnival is an holiday also but since Carnival is allways a tuesday,
				//it can be included on the Turistic holiday bridge policy
				ChristianHolidays.Carnival,
				DayOfRemembrenceForTruthAndJustice,
				DayOfTheVeterans,
				GlobalHolidays.InternationalWorkersDay,
				DayOfTheFirstNationalGovernment,
				NationalFlagDay,
				IndependenceDay,
				ChristianHolidays.ImaculateConception,
				//TODO: only half day. should it be included?
				//this.InnerHolidays.Add(ChristianHolidays.ChristmasEve);
				ChristianHolidays.Christmas,
				//TODO: only half day. should it be included?
				//this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
			};

		public ES_ARHolidayStrategy() {
			foreach (var turisticHoliday in TuristicHolidays) {
				this.InnerHolidays.Add(turisticHoliday);
			}
			this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(AnniversaryOfDeathGeneralJoseSanMartin);
			this.InnerHolidays.Add(DayOfRespectForCulturalDiversity);
			this.InnerHolidays.Add(DayOfNationalSovereignity);
		}

		public override IDictionary<DateTime, Holiday> BuildObservancesMap(int year) {
			var observancesMap = new Dictionary<DateTime, Holiday>();
			this.BuildMoveableObservanceMap(year, DayOfRespectForCulturalDiversity, observancesMap);
			this.BuildMoveableObservanceMap(year, DayOfNationalSovereignity, observancesMap);
			foreach (var turisticHoliday in TuristicHolidays) {
				this.BuildTuristicObservanceMap(year, turisticHoliday, observancesMap);
			}
			this.BuildNormalObservanceMap(year, ChristianHolidays.MaundyThursday, observancesMap);
			this.BuildNormalObservanceMap(year, ChristianHolidays.GoodFriday, observancesMap);
			this.BuildNormalObservanceMap(year, AnniversaryOfDeathGeneralJoseSanMartin, observancesMap);
			return observancesMap;
		}

		private void BuildNormalObservanceMap(int year, Holiday holiday, Dictionary<DateTime, Holiday> map) {
			var holidayInstance = holiday.GetInstance(year);
			if (!holidayInstance.HasValue) {
				return;
			}
			map.Add(holidayInstance.Value, DayOfRespectForCulturalDiversity);
		}

		private void BuildTuristicObservanceMap(int year, Holiday holiday, Dictionary<DateTime, Holiday> map) {
			var holidayInstance = holiday.GetInstance(year);
			if (!holidayInstance.HasValue) {
				return;
			}
			map.Add(holidayInstance.Value, DayOfRespectForCulturalDiversity);
			//if holiday falls on tuesday, the holiday is also observed on the last monday
			if (holidayInstance.Value.DayOfWeek == DayOfWeek.Tuesday) {
				map.Add(holidayInstance.Value.LastDayOfWeek(DayOfWeek.Monday), holiday);
			}
			//if holiday falls on thursday, the holiday is also observed on the next friday
			if (holidayInstance.Value.DayOfWeek == DayOfWeek.Thursday) {
				map.Add(holidayInstance.Value.NextDayOfWeek(DayOfWeek.Friday), holiday);
			}
		}

		private void BuildMoveableObservanceMap(int year, Holiday holiday, Dictionary<DateTime, Holiday> map ) {
			var holidayInstance = holiday.GetInstance(year);
			if (!holidayInstance.HasValue) {
				return;
			}
			switch (holidayInstance.Value.DayOfWeek) {
				case DayOfWeek.Monday:
					map.Add(holidayInstance.Value, DayOfRespectForCulturalDiversity);
					break;
				//if holiday falls on tuesday or wednesday, the holiday is observed on the last monday
				case DayOfWeek.Tuesday:
				case DayOfWeek.Wednesday:
					map.Add(holidayInstance.Value.LastDayOfWeek(DayOfWeek.Monday), holiday);
					break;
				//if holiday falls on thu, fri, sat, sun, the holiday is observed on the next monday
				default:
					map.Add(holidayInstance.Value.NextDayOfWeek(DayOfWeek.Monday), holiday);
					break;
			}
		}

		private bool IsNormalHoliday(DateTime day) {
			if (ChristianHolidays.MaundyThursday.IsInstanceOf(day)) {
				return true;
			}
			if (ChristianHolidays.GoodFriday.IsInstanceOf(day)) {
				return true;
			}
			if(AnniversaryOfDeathGeneralJoseSanMartin.IsInstanceOf(day)) {
				return true;
			}
			return false;
		}

		private bool IsTuristicHoliday(DateTime day) {
			return TuristicHolidays.Any(h => h.IsInstanceOf(day));
		}

		private bool IsMoveableHoliday(DateTime day) {
			if(DayOfRespectForCulturalDiversity.IsInstanceOf(day)) {
				return true;
			}
			if (DayOfNationalSovereignity.IsInstanceOf(day)) {
				return true;
			}
			return false;
		}

		//24 March - Day of Remembrance for Truth and Justice
		private static Holiday dayOfRemembrenceForTruthAndJustice;
		public static Holiday DayOfRemembrenceForTruthAndJustice {
			get {
				if (dayOfRemembrenceForTruthAndJustice == null) {
					dayOfRemembrenceForTruthAndJustice = new FixedHoliday("Day of Remembrance for Truth and Justice", 3, 24);
				}
				return dayOfRemembrenceForTruthAndJustice;
			}
		}

		//2 April - Day of The Veterans
		private static Holiday dayOfTheVeterans;
		public static Holiday DayOfTheVeterans {
			get {
				if (dayOfTheVeterans == null) {
					dayOfTheVeterans = new FixedHoliday("Day of The Veterans", 4, 2);
				}
				return dayOfTheVeterans;
			}
		}

		//25 May - Day of the First National Government
		private static Holiday dayOfTheFirstNationalGovernment;
		public static Holiday DayOfTheFirstNationalGovernment {
			get {
				if (dayOfTheFirstNationalGovernment == null) {
					dayOfTheFirstNationalGovernment = new FixedHoliday("Day of the First National Government", 5, 25);
				}
				return dayOfTheFirstNationalGovernment;
			}
		}

		//20 June - National Flag Day 
		private static Holiday nationalFlagDay;
		public static Holiday NationalFlagDay {
			get {
				if (nationalFlagDay == null) {
					nationalFlagDay = new FixedHoliday("National Flag Day", 6, 20);
				}
				return nationalFlagDay;
			}
		}

		//9 July - Independence Day
		private static Holiday independenceDay;
		public static Holiday IndependenceDay {
			get {
				if (independenceDay == null) {
					independenceDay = new FixedHoliday("Independence Day", 7, 9);
				}
				return independenceDay;
			}
		}

		//3rd Monday Of August - Anniversary Of Death of General José San Martin
		private static Holiday anniversaryOfDeathGeneralJoseSanMartin;
		public static Holiday AnniversaryOfDeathGeneralJoseSanMartin {
			get {
				if (anniversaryOfDeathGeneralJoseSanMartin == null) {
					anniversaryOfDeathGeneralJoseSanMartin = new NthDayOfWeekInMonthHoliday("Anniversary Of Death of General José San Martin", 3, DayOfWeek.Monday, 8, CountDirection.FromFirst);
				}
				return anniversaryOfDeathGeneralJoseSanMartin;
			}
		}

		//TODO: second Monday of October???
		//12 October - Day of Respect for Cultural Diversity
		private static Holiday dayOfRespectForCulturalDiversity;
		public static Holiday DayOfRespectForCulturalDiversity {
			get {
				if (dayOfRespectForCulturalDiversity == null) {
					dayOfRespectForCulturalDiversity = new FixedHoliday("Day of Respect for Cultural Diversity", 12, 16);
				}
				return dayOfRespectForCulturalDiversity;
			}
		}

		//TODO: fourth monday of November???
		//26 December - Day of National Sovereignty
		private static Holiday dayOfNationalSovereignity;
		public static Holiday DayOfNationalSovereignity {
			get {
				if (dayOfNationalSovereignity == null) {
					dayOfNationalSovereignity = new FixedHoliday("Day of National Sovereignty", 11, 20);
				}
				return dayOfNationalSovereignity;
			}
		}
	}
}