using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DateTimeExtensions.Strategies;

namespace DateTimeExtensions.Export {
	public class OfficeHolidaysExportHolidaysFormat: IExportHolidaysFormat {

		private const string HolidayLineFormat = "{0}, {1}";
		private const string HeaderLineFomat = "{0} ###";
		private const string DateFormat = "yyyy/MM/dd";

		public void Export(string name, IHolidayStrategy holidayStrategy, int year, TextWriter writer) {
			writer.WriteLine(HeaderLineFomat, name);
			foreach (var holiday in holidayStrategy.GetHolidaysOfYear(year)) {
				var instance = holiday.GetInstance(year);
				if(instance.HasValue) {
					writer.WriteLine(HolidayLineFormat, holiday.Name, instance.Value.ToString(DateFormat));
				}
			}
		}

		public void Export(IHolidayStrategy holidayStrategy, int year, TextWriter writer) {
			Export(holidayStrategy.GetType().Name, holidayStrategy, year, writer);
		}

		public void Export(DateTimeCultureInfo dateTimeCultureInfo, int year, TextWriter writer) {
			var strategy = dateTimeCultureInfo.LocateHolidayStrategy(dateTimeCultureInfo.Name);
			Export(dateTimeCultureInfo.Name, strategy, year, writer);
		}
	}
}
