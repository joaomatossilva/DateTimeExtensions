using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {

	[Flags]
	public enum ChristianHoliday {
		Christmas = 1,
		NewYear = 2,
		Easter = 4,
		EasterMonday = 8,
		GoodFriday = 16,
		Carnival = 32,
		CorpusChristi = 64,
		Assumption = 128,
		AllSaints = 256,
		ImaculateConception = 512,
		Pentecost = 1024,
		Ascension = 2048
	}

	public class ChristianHolidayStrategy : IHolidayStrategy {
		private ChristianHoliday holidaysToConsider;
		private IDictionary<int, DateTime> easterPerYear;
		private IList<DayInYear> fixedHiolidays;

		public ChristianHolidayStrategy(ChristianHoliday holidaysToConsider) {
			this.holidaysToConsider = holidaysToConsider;
			easterPerYear = new Dictionary<int, DateTime>();
			fixedHiolidays = new List<DayInYear>();
			if(IsHolidayConsidered(ChristianHoliday.NewYear))
				fixedHiolidays.Add(new DayInYear { Day = 1, Month = 1 });	//New Year
			if (IsHolidayConsidered(ChristianHoliday.Assumption))
				fixedHiolidays.Add(new DayInYear { Day = 15, Month = 8 });	//Assumption
			if (IsHolidayConsidered(ChristianHoliday.AllSaints))
				fixedHiolidays.Add(new DayInYear { Day = 1, Month = 11 });	//All Saints
			if (IsHolidayConsidered(ChristianHoliday.ImaculateConception))
				fixedHiolidays.Add(new DayInYear { Day = 8, Month = 12 });	//Immaculate Conception
			if (IsHolidayConsidered(ChristianHoliday.Christmas))
				fixedHiolidays.Add(new DayInYear { Day = 25, Month = 12 });	//Christmas
		}

		protected DateTime GetEaster(int year){
			if(easterPerYear.ContainsKey(year)) {
				return easterPerYear[year];
			}
			var easterDay = CalculateEasterDate(year);
			easterPerYear.Add(year, easterDay);
			return easterDay;
		}
	
		public bool IsHoliDay(DateTime day)
		{
			if (fixedHiolidays.Where( h=> h.Day == day.Day && h.Month == day.Month ).SingleOrDefault() != null) {
				return true;
			}
			var easterDay = GetEaster(day.Year);
			if (day.Date == easterDay && IsHolidayConsidered(ChristianHoliday.Easter)) {
				return true;
			}
			if (day.Date == easterDay.AddDays(-47) && IsHolidayConsidered(ChristianHoliday.Carnival)) { // Carnival
				return true;
			}
			if (day.Date == easterDay.AddDays(-2) && IsHolidayConsidered(ChristianHoliday.GoodFriday)) { // Good Friday
				return true;
			}
			if (day.Date == easterDay.AddDays(1) && IsHolidayConsidered(ChristianHoliday.EasterMonday)) { // Easter Monday
				return true;
			}
			if (day.Date == easterDay.AddDays(60) && IsHolidayConsidered(ChristianHoliday.CorpusChristi)) { // Corpus Christi
				return true;
			}
			if (day.Date == easterDay.AddDays(50) && IsHolidayConsidered(ChristianHoliday.Pentecost)) { // Pentecost
				return true;
			}
			if (day.Date == easterDay.AddDays(39) && IsHolidayConsidered(ChristianHoliday.Ascension)) { // Ascension
				return true;
			}
			return false;
		}

		private bool IsHolidayConsidered(ChristianHoliday holiday) {
			 return (holidaysToConsider & holiday) == holiday;
		}

		//Algoritm downloaded from http://tiagoe.blogspot.com/2007/10/easter-calculation-in-c.html
		private static DateTime CalculateEasterDate(int year) {
			int temp;
			int a, b, c, d, e, f, g, h, i, k, l, m, p, q;

			DateTime result;

			if (year >= 1583) {
				//Gregorian Calendar Easter 

				Math.DivRem(year, 19, out a);
				b = Math.DivRem(year, 100, out c);
				d = Math.DivRem(b, 4, out e);
				f = Math.DivRem(b + 8, 25, out temp);
				g = Math.DivRem(b - f + 1, 3, out temp);
				Math.DivRem(19 * a + b - d - g + 15, 30, out h);
				i = Math.DivRem(c, 4, out k);
				Math.DivRem(32 + 2 * e + 2 * i - h - k, 7, out l);
				m = Math.DivRem(a + 11 * h + 22 * l, 451, out temp);
				p = Math.DivRem(h + l - 7 * m + 114, 31, out q);

				result = new DateTime(year, p, q + 1);
			} else {
				//Julian Calendar 

				Math.DivRem(year, 4, out a);
				Math.DivRem(year, 7, out b);
				Math.DivRem(year, 19, out c);
				Math.DivRem(19 * c + 15, 30, out d);
				Math.DivRem(2 * a + 4 * b - d + 34, 7, out e);
				f = Math.DivRem(d + e + 114, 31, out g);

				result = new DateTime(year, f, g + 1);
			}

			return result;
		}		
	}
}
