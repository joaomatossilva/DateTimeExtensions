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

		public void Export(DateTimeCultureInfo dateTimeCultureInfo, int year, TextWriter writer) {
			writer.WriteLine(HeaderLineFomat, dateTimeCultureInfo.Name);
			foreach (var holiday in dateTimeCultureInfo.GetHolidaysOfYear(year)) {
				var instance = holiday.GetInstance(year);
				if (instance.HasValue) {
					writer.WriteLine(HolidayLineFormat, holiday.Name, instance.Value.ToString(DateFormat));
				}
			}
		}
	}
}
