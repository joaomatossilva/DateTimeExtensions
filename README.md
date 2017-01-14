DateTime Extensions
===================
[http://www.kspace.pt/DateTimeExtensions/](http://www.kspace.pt/DateTimeExtensions/)

[![NuGet Version](http://img.shields.io/nuget/v/DateTimeExtensions.svg?style=flat)](https://www.nuget.org/packages/DateTimeExtensions/) 
[![MyGet Pre Release](https://img.shields.io/myget/datetimeextensions/vpre/DateTimeExtensions.svg)](https://www.myget.org/feed/datetimeextensions/package/nuget/DateTimeExtensions)
[![AppVeyor](https://img.shields.io/appveyor/ci/kappy/datetimeextensions.svg)](https://ci.appveyor.com/project/kappy/datetimeextensions)
[![GitHub contributors](https://img.shields.io/github/contributors/kappy/datetimeextensions.svg)](https://github.com/kappy/DateTimeExtensions)


This project is a merge of several common DateTime operations in the form of 
extensions to System.DateTime, including natural date difference text (precise and human rounded),
holidays and working days calculations on several culture locales.

Feedback will be much appreciated.
You can check out a sample (WIP) project online on [http://datetimeextensions.azurewebsites.net/](http://datetimeextensions.azurewebsites.net/)

## Major Features

The following major features are currently implemented:

+  Add or subtract Working days using locale holidays
+  Export Holidays to calendar format
+  Dates Difference in Natural Time (localized)
+  Time of day
+  General "goto" dates


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



## How to Contribute

Feel free to fork the project, work on your fork and send me the pull requests.
You can also create issues with the features or changes that you think important.

Also, this repository is built with autocrlf = true.

### Holidays Names

When adding holidays resources names, plase prefix the culture specific holidays with the
country name to avoid name colisison.
Example: Portugal_FreedomDay


## Version History
v4.0
- Added support for .net Core using netstandard 1.1
- breaking change: Locating custom strategies is now not supported by default to look outside own DateTimeExtensions assembly.
One must override the location strategy on WorkingDayCultureInfo to specify the list of assemblies where to look.

v3.10
- Added translation of german Holidays and a new GetWorkingDays method (thanks @schulz3000)

v3.9
- Added Vietnam Holidays (thanks @cuongtranba)

v3.8
- Added Chinese Holidays
- breaking change: NewYear is now a GlobalHoliday and not a Christian Holiday

v3.7.2
- Fixed ar-SA not able to generate holidays on some years
- Restoring pt-PT holidays from 2016 and on
- Fixed en-ZA and es-AR not generating holidays in 2016 

v3.7.1
- Fixed #42 - Getting key already added error when using en-CA culture?
- Fixed #41 - Fixed bugs with Australian public holiday calculation (thanks @TonyZhu2015)

v3.7
- Added kr-KR Holidays and Natural text locales (thanks @jaeseonc)

v3.6
- Removed St.Patricks day on en-GB (thanks @ConspiringWithTheDamned)
- Added en-IE Ireland locale

v3.5
- Reformated solution to BSD/Allman bracer style
- Reformated solution to use spaces instead of tabs
- Added kingsday on nl-NL locale (thanks @rickbeerendonk)

v3.4
- Added possibility to localize holidays names.

v3.3
- Added Round, Ceiling, Floor features (thanks @jbasinger)

v3.2.1
- fixed ar-SA non working days of the week (now friday and saturday, thanks @falsair)

v3.1.2
- Fixed the Portuguese abolished holidays

v3.1.1
- Fixed a bug that was causing the abolished holidays to still be listed as holidays

v3.1
- Added en-NZ working days culture (Thanks @snoopydo)
- Re-removed the 4 holidays that are abolished by the PT government

v3.0.1
- Safe Locales implementation discovery

v3.0
- Culture specific strategies are now decorated with a specific attribute to allow a better and dynamic discovery.
- The Locator classes and method are now obsolete.
- DateTimeCultureInfo have been split into specific contexts. This will improve the single responsibility of the classes.
- Added Time feature
- BreakingChanges:
	- DateTimeCultureInfo is split in WorkingDayCultureInfo and NaturealTextCultureInfo
	- A lot of classes were moved and namespaced properly

v2.2.5
- Added nl-NL and nl-BE Natural Text Cultures (Thanks @frankgeerlings)
- bugfix:
	- Multiple Holidays on the same day caused an error building the holiday map (Thanks @frankgeerlings)

v2.2.4
- bugfix:
	- Holidays on weekends weren't considered as holidays
v2.2.3
- fixed bugs:
	- fixed Laborday on Canada (en-CA and fr-CA)
	- fixed some mobile holidays on Argentina (es-AR)
	- fix a bug on Australian (en-AU) holidays strategy when moving Easter holidays to the next Monday that was already an holiday

v2.2.2
- Added new extension IsHoliday. This extension should be similar to IsWorkingDay but in reverse and disregarding the day of the week.
- Internal Refactoring: Holidays strategies were refactored to allow holidays with multiple observances.

v2.2.1
- Added a few more cultures: en-AU, fr-CA (en-CA), ar-SA, en-ZA, es-AR, es-MX, it-IT

v2.2
- Added support for defining holidays on a different calendar
	- Added Jewish holidays definitions as a proof of concept

v2.1.1
- Bugfix: header and date format corrected

v2.1
- Added Export Holidays feature

v2.0.5
- Minor internal change in adding a HolidayStrategy Superclass
- DateTimeCultureInfo has now access to all holidays not regarding to the year

v2.0.4
- Natural Text is now more human based on reporting months and days

v2.0.3
- bugfixes:
	fi-FI Holidays enumeration is throwing a Argument Out Of Range Exception
	da-DK holiday Strategy is missnamed
	is-IS SeamensDay is returning Commerce Day

v2.0.2
- Added Nordic holidays cultures
- Added new type of Holiday: NthDayOfWeekAfterDayHoliday
- bugfixes: Pentecost holiday was not calculated correctly

v2.0.1
- bugfixes: NthDayOfWeekInMonth Calculations were corrected

v2.0
- Added Natural Time conversions features
- breaking chances:
	- WorkingDayCulture info was renamed to DateTimeCultureInfo since its purpose has now multiple contexts.

v1.2.1
- Reverted the holidays abolishment on pt-PT culture since 2012 introduced on v1.2 cause it's still being discussed in Parliament

v1.2
- Changed pt-PT culture to reflect the holidays abolishment since 2012
- Added the year dependent holiday (holidays that were created since, removed since, or only verified on certain years)
- breaking changes:
	- Holiday.GetInstance(int year) now returns DateTime? instead of DateTime
	- IHolidayStrategy.GetHolidaysOfYear(int year) was created to replace the property Holidays to be year independent
	- IHolidayStrategy.Holidays now return only the holidays of the current year

v1.1
- Added more cultures
- api refactoring

v1.0.1
- Added more cultures
- Added other general extension methods

v1.0
- Initial Version. The only supported Culture is pt-PT
