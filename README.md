# DateTimeExtensions

![DateTimeExtensions Logo](https://github.com/joaomatossilva/DateTimeExtensions/raw/master/assets/datetimeextensions-200-logo.png)

[![NuGet Version](http://img.shields.io/nuget/v/DateTimeExtensions.svg?style=flat)](https://www.nuget.org/packages/DateTimeExtensions/) 
[![MyGet Pre Release](https://img.shields.io/myget/datetimeextensions/vpre/DateTimeExtensions.svg)](https://www.myget.org/feed/datetimeextensions/package/nuget/DateTimeExtensions)
[![AppVeyor](https://img.shields.io/appveyor/ci/kappy/datetimeextensions.svg)](https://ci.appveyor.com/project/kappy/datetimeextensions)
[![GitHub contributors](https://img.shields.io/github/contributors/joaomatossilva/datetimeextensions.svg)](https://github.com/joaomatossilva/DateTimeExtensions)

## What is DateTimeExtensions?

DateTimeExtensions is a powerful C# library that extends the functionality of `System.DateTime` and `System.DateTimeOffset`. It provides useful methods for working with dates and times, making your code more expressive and easier to read.

## Key Features

1. **Working Days Calculations**: Easily add or subtract working days, considering regional holidays.
2. **Holiday Support**: Includes holiday definitions for multiple cultures and regions.
3. **Natural Language Date Differences**: Get the difference between dates in human-readable format.
4. **Time of Day Operations**: Simplify time-based comparisons and checks.
5. **Calendar Export**: Export holidays to common calendar formats.
6. **SourceLink Support**: Enables debugging into the source code.

## Installation

Install DateTimeExtensions via NuGet:

```
Install-Package DateTimeExtensions
```

## Quick Start

Here are some examples of what you can do with DateTimeExtensions:

```csharp
using DateTimeExtensions;

// Add 5 working days to a date
DateTime futureDate = DateTime.Now.AddWorkingDays(5);

// Check if a date is a working day
bool isWorkingDay = DateTime.Now.IsWorkingDay();

// Get the difference between dates in natural language
string dateDiff = DateTime.Now.ToNaturalText(DateTime.Now.AddDays(45));

// Check if a time is between two other times
bool isBetween = DateTime.Now.IsBetween(new Time("09:00"), new Time("17:00"));
```

## Supported Cultures

DateTimeExtensions supports working day and holiday calculations for many cultures, including:

- United States (en-US)
- United Kingdom (en-GB)
- France (fr-FR)
- Germany (de-DE)
- Spain (es-ES)
- Brazil (pt-BR)
- Portugal (pt-PT)
- and many more!

Don't see your culture? Contributions are welcome!

## Advanced Features

### Exporting Holidays

You can export holidays to various calendar formats:

```csharp
var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
exporter.Export(new WorkingDayCultureInfo("en-US"), 2024, textWriter);
```

### Custom Working Day Definitions

Implement `IWorkingDayCultureInfo` to define custom working day rules for your specific needs.

## Contributing

We welcome contributions! Here's how you can help:

1. Fork the repository
2. Create a feature branch
3. Implement your feature or bug fix
4. Add or update tests as necessary
5. Submit a pull request

To add new holiday definitions, please prefix culture-specific holidays with the country name (e.g., "USA_IndependenceDay").

## Documentation

For more detailed information, visit our [official documentation](http://www.kspace.pt/DateTimeExtensions/).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.md) file for details.

## Acknowledgements

- Logo design by @manuelbarbosa
- Build script assistance by @matkoch using [Nuke](http://www.nuke.build/)
- Open source license provided by [JetBrains](https://www.jetbrains.com/)

---

DateTimeExtensions: Making date and time operations in C# simpler and more intuitive.
