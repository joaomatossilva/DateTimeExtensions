using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DateTimeExtensions.Strategies;

namespace DateTimeExtensions.Export {
	public class OfficeHolidaysExportHolidaysFormat: IExportHolidaysFormat {

		private const string HolidayLineFormat = "{0}, {1:yyyy'/'MM'/'dd}";
		private const string HeaderLineFomat = "[{0}] {1}";

		public void Export(DateTimeCultureInfo dateTimeCultureInfo, int year, TextWriter writer) {
			var holidays = dateTimeCultureInfo.GetHolidaysOfYear(year);
			writer.WriteLine(HeaderLineFomat, dateTimeCultureInfo.Name, holidays.Count());
			foreach (var holiday in holidays) {
				var instance = holiday.GetInstance(year);
				if (instance.HasValue) {
					writer.WriteLine(HolidayLineFormat, holiday.Name, instance);
				}
			}
		}
	}
}
