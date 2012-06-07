using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays {
	public class YearDependantHoliday : Holiday{

		private readonly Func<int, bool> yearCondition;
		private readonly Holiday baseHoliday;

		public YearDependantHoliday(Func<int, bool> yearCondition, Holiday baseHoliday ) : base(baseHoliday.Name) {
			this.yearCondition = yearCondition;
			this.baseHoliday = baseHoliday;
		}

		public override DateTime? GetInstance(int year) {
			return this.yearCondition(year) ? this.baseHoliday.GetInstance(year) : null;
		}

		public override bool IsInstanceOf(DateTime date) {
			return this.yearCondition(date.Year) && this.baseHoliday.IsInstanceOf(date);
		}
	}
}
