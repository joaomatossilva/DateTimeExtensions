using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.Export {
	public interface IExportHolidaysFormat {
		void Export(WorkingDayCultureInfo dateTimeCultureInfo, int year, TextWriter writer);
	}
}
