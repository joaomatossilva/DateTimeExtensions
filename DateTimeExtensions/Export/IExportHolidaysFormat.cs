using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DateTimeExtensions.Strategies;

namespace DateTimeExtensions.Export {
	public interface IExportHolidaysFormat {
		void Export(IHolidayStrategy holidayStrategy, int year, TextWriter writer);
		void Export(string name, IHolidayStrategy holidayStrategy, int year, TextWriter writer);
		void Export(DateTimeCultureInfo dateTimeCultureInfo, int year, TextWriter writer);
	}
}
