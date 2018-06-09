[![DateTimeExtensions](https://github.com/joaomatossilva/DateTimeExtensions/raw/master/assets/datetimeextensions-200-logo.png)](https://github.com/joaomatossilva/DateTimeExtensions) 

DateTime Extensions
===================
[http://www.kspace.pt/DateTimeExtensions/](http://www.kspace.pt/DateTimeExtensions/)

[![NuGet Version](http://img.shields.io/nuget/v/DateTimeExtensions.svg?style=flat)](https://www.nuget.org/packages/DateTimeExtensions/) 
[![MyGet Pre Release](https://img.shields.io/myget/datetimeextensions/vpre/DateTimeExtensions.svg)](https://www.myget.org/feed/datetimeextensions/package/nuget/DateTimeExtensions)
[![AppVeyor](https://img.shields.io/appveyor/ci/kappy/datetimeextensions.svg)](https://ci.appveyor.com/project/kappy/datetimeextensions)
[![GitHub contributors](https://img.shields.io/github/contributors/joaomatossilva/datetimeextensions.svg)](https://github.com/joaomatossilva/DateTimeExtensions)


This project is a merge of several common DateTime operations in the form of 
extensions to System.DateTime, including natural date difference text (precise and human rounded),
holidays and working days calculations on several culture locales.

Feedback will be much appreciated.
You can check out a sample (WIP) project online on [http://datetimeextensions.azurewebsites.net/](http://datetimeextensions.azurewebsites.net/)

## Major Features

The following major features are currently implemented:

+  Add or subtract Working days using locale holidays
+  Support for Regional holidays (limited locales)
+  Export Holidays to calendar format
+  Dates Difference in Natural Time (localized)
+  Time of day
+  General "goto" dates
+ Supports SourceLink for debugging


### Working Days Calculations

These extensions for System.DateTime adds methods to make calculations based on working days.
A working day is defined in `IWorkingDayCultureInfo` in two ways:

    IsWorkingDay(DayOfWeek dayOfWeek)
    IsWorkingDay(DateTime date)

The first defines which day of the week is a working day (by default, working days are all 
week days except weekends). The last does the same as the first, but it's also able to check 
for any holiday. By default, no holidays are defined, unless there is a `IWorkingDayCultureInfo` 
implemented for the current thread `CultureInfo`.

Avaiable CultureInfo implementations:

| Culture | Culture |
| ------- | ------- |
| pt-PT	| da-DK |
| pt-BR	| fi-FI |
| en-US	| is-IS |
| en-GB	| nb-NO |
| fr-FR	| nl-NL |
| de-DE	| sv-SE |
| es-ES	| es-AR |
| es-MX	| en-AU |
| en-ZA	| fr-CA (en-CA)|
| ar-SA	| it-IT |
| en-NZ | en-GD (gd-GD, not really sure about this locale) 
| en-IE | sl-SL |
| kr-KR | zh-CN |
| pl-PL | vi-VN |


If your culture is not listed here you can contribute it!!!

Fork me, implement it and send me the pull request, or just create an issue on the project github site. 


### Export Holidays to calendar format


This feature allows you to export the holidays from a `DateTimeCultureInfo` (see above)
and export it to Microsoft Office Outlook.
The `IExportHolidaysFormat` interface exposes one simple method for it:

    void Export(DateTimeCultureInfo dateTimeCultureInfo, int year, TextWriter writer)

Example:

    var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
    exporter.Export(new WorkingDayCultureInfo("pt-PT"), 2012, textwriter);


### Dates Diff in Natural Time

These extensions can compare two dates in natural language based on the current locale on 
current thread `CultureInfo`.
There are 2 API points for them:

    fromDate.ToNaturalText(toTime, bool round = true)
    fromDate.ToExactNaturalText(toTime)

The first will return the most valuable time component with value > 0. The round flag will 
try to round the most significant time component based on the next least significant. 
Also, the round flag will round minutes and seconds to quarters after the first one.

Avaiable CultureInfo implementations:

| Culture |
| ------- |
| pt-PT |
| pt-BR |
| en-US |
| en-GB |
| fr-FR |
| de-DE |
| es-ES |
| nl-NL |
| nl-BE |
| kr-KR |
| pl-PL |

### Time of Day

These extensions allow easy parsing of time expressions and add the ability to check if a DateTime instance is after,
before or inside a period.

    bool IsBetween(this DateTime dateTime, Time startTime, Time endTime)
    bool IsBefore(this DateTime dateTime, Time time)
    bool IsAfter(this DateTime dateTime, Time time)


### Other Extensions:


    fromDate.FirstDayOfTheMonth()
    fromDate.LastDayOfTheMonth()
    fromDate.LastDayOfWeek(DayOfWeek)
    fromDate.NextDayOfWeek(DayOfWeek)
    fromDate.LastDayOfWeekOfTheMonth(DayOfWeek)
    fromDate.FirstDayOfWeekOfTheMonth(DayOfWeek)
    fromDate.GetDiff(DateTime toDate)


### SourceLink

This library supports SourceLink. Just make sure you have a compatible Visual Studio version and 
the Just My Code is disabled on Debugging options


## How to Contribute

Feel free to fork the project, work on your fork and send me the pull requests.
You can also create issues with the features or changes that you think important.

Also, this repository is built with autocrlf = true.

### Holidays Names

When adding holidays resources names, plase prefix the culture specific holidays with the
country name to avoid name colisison.
Example: Portugal_FreedomDay

### Changelog
[Changelog](CHANGELOG.md) 

### License
[License](LICENSE.md) 

### Special Thanks

+ @manuelbarbosa for making me this awesome logo
+ @matkoch for helping me build the build script using [Nuke](http://www.nuke.build/) and also building a video using this project
+ Jetbrains for allowing me an open source license of their pretty cool suit [![Jetbrains](https://github.com/joaomatossilva/DateTimeExtensions/raw/master/assets/jetbrains/jetbrains-variant-4-200.png)](https://www.jetbrains.com)