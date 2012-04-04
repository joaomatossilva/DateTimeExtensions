using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Export {
	public static class ExportHolidayFormatLocator {

		private const string EXPORT_FORMAT_NAME = "ExportHolidaysFormat";
		private const string NAMESPACE = "DateTimeExtensions.Export";


		public static IExportHolidaysFormat LocateByType(ExportType type) {
			string strategyName = NAMESPACE + "." + type.ToString() + EXPORT_FORMAT_NAME;
			IExportHolidaysFormat holidayStrategy = CreateObjectInstance<IExportHolidaysFormat>(strategyName);
			return holidayStrategy;
		}

		private static T CreateObjectInstance<T>(string typeName) {
			if (typeName == null) {
				throw new ArgumentNullException("typeName");
			}
			Type type = Type.GetType(typeName);
			if (type == null) {
				throw new ArgumentException(string.Format("Type name '{0}' was not found.", typeName));
			}
			T instance = (T)Activator.CreateInstance(type);
			if (instance == null) {
				throw new ArgumentException(string.Format("Could not create a new instance of type '{0}'.", typeName));
			}
			return instance;
		}

	}
}
