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

		public override bool IsHoliDay(DateTime day) {
			if (IsNormalHoliday(day)) {
				return true;
			}
			if (day.DayOfWeek == DayOfWeek.Monday) {
				if (base.IsHoliDay(day)) {
					return true;
				}
				//check if any moveable holiday is due on next couple days or last 4 days
				for (int i = -4; i <= 2; i++) {
					if (i == 0) {
						//don't count it's own day
						continue;	
					}
					var possibleMoveableHoliday = day.AddDays(i);
					if (IsMoveableHoliday(possibleMoveableHoliday)) {
						return true;
					}
				}

				//check if next Tuesday is a turistic Holiday
				if (IsTuristicHoliday(day.NextDayOfWeek(DayOfWeek.Tuesday))) {
					return true;
				}
			}
			if (day.DayOfWeek == DayOfWeek.Friday) {
				//check if last Thursday is a turistic Holiday
				if (IsTuristicHoliday(day.LastDayOfWeek(DayOfWeek.Thursday))) {
					return true;
				}
			}
			return false;
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