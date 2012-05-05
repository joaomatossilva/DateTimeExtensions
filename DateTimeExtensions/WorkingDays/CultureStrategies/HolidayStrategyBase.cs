using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	public abstract class HolidayStrategyBase : IHolidayStrategy {
		protected readonly IList<Holiday> InnerHolidays;

		private readonly IDictionary<int, IDictionary<DateTime, Holiday>> holidaysObservancesCache;

		protected HolidayStrategyBase() {
			holidaysObservancesCache = new Dictionary<int, IDictionary<DateTime, Holiday>>();
			this.InnerHolidays = new List<Holiday>();
		}

		public bool IsHoliDay(DateTime day) {
			this.CheckYearHasMap(day.Year);
			return holidaysObservancesCache[day.Year].Any(m => m.Key.Date == day.Date);
		}

		private void CheckYearHasMap(int year) {
			if (!holidaysObservancesCache.ContainsKey(year)) {
				holidaysObservancesCache.Add(year, this.BuildObservancesMap(year));
			}
		}

		public virtual IDictionary<DateTime, Holiday> BuildObservancesMap(int year) {
			return this.InnerHolidays.Select(h => new { Date = h.GetInstance(year), Holiday = h })
				.Where(h => h.Date.HasValue)
				.GroupBy(h => h.Date).Select(g => new { Date = g.Key, g.First().Holiday })
				.ToDictionary(k => k.Date.Value, v => v.Holiday);
		} 

		public virtual IEnumerable<Holiday> Holidays {
			get {
				return InnerHolidays.AsEnumerable();
			}
		}

		public virtual IEnumerable<Holiday> GetHolidaysOfYear(int year) {
			this.CheckYearHasMap(year);
			return holidaysObservancesCache[year].Select(m => m.Value);
		}
	}
}
