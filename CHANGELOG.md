Changelog
===================
v5.2.0
- Added es-CO culture, thanks to @canro91

v5.1
- Added Target netstandard 2.0
- Added SourceLink to enable debugging by 3rd parties

v5.0.3
- Fixed FR culture, thanks to @YDEFAY

v5.0.2
- Added logo, thanks to @manuelbarbosa

v5.0.1
- Fixed an issue on en-US when the NewYear happens on a Saturday, not causin the NewYearEve on Friday to become a holiday (thanks @dalmuti509)

v5.0
- Regions support added
- Added Polish (pl-PL) NaturalTime and Working Days Strategies (thanks @scoutboy420)
- Fixed German pluralize (thanks @isepise)
- This is not really a cahnge but this is the next release after we have a specific file for Changelog and License (thanks @jzeferino)
- breaking change: Since the polish pluralize needs to have the number as context, the method signature changed to be able to support it and other languages that might need it as well

v4.0.2
- Repack to allow github username change

v4.0.1
- Targeting netstandard 1.3 due to System.Globalization.Calendars not supported in 1.1
- Added target Framework 4.5 (to redure the impact of moving to netstandard 1.3 and to support older Nuget clients, ty jbogard by the tip)

v4.0
- Added support for .net Core using netstandard 1.1 
- Because the last bullet, it was dropped support of the v3.5 Framework. Mminimum framework is now 4.5.
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
