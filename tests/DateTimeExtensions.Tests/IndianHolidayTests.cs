using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class IndianHolidayTests
    {
        private static CalendarService _calendarService;

        // This method initializes the Google Calendar API client.
        [OneTimeSetUp]
        public void Init()
        {
            var credential = GoogleCredential.FromFile("path_to_your_credentials.json")
                .CreateScoped(CalendarService.Scope.CalendarReadonly);

            _calendarService = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "IndianHolidayTests"
            });
        }

        // Helper method to fetch holidays from Google Calendar for a specific year
        private async Task<Events> GetIndianHolidays(int year)
        {
            var calendarId = "en.indian#holiday@group.v.calendar.google.com";
            var request = _calendarService.Events.List(calendarId);
            request.TimeMin = new DateTime(year, 1, 1);
            request.TimeMax = new DateTime(year, 12, 31);
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return await request.ExecuteAsync();
        }

        [Test]
        public async Task IndependenceDayTest()
        {
            var holidays = await GetIndianHolidays(2015);
            var independenceDay = holidays.Items.FirstOrDefault(e => e.Summary == "Independence Day");

            Assert.IsNotNull(independenceDay);
            Assert.AreEqual(new DateTime(2015, 8, 15), independenceDay.Start.DateTime.Value.Date);
        }

        [Test]
        public async Task CanGetIndianHolidaysListIn2017()
        {
            var holidays = await GetIndianHolidays(2017);
            Assert.IsNotNull(holidays);
            Assert.IsTrue(holidays.Items.Count > 0);

            // Example: Assert that there are at least 5 holidays in the calendar for 2017
            Assert.AreEqual(5, holidays.Items.Count); // Update this number based on actual data
        }
    }
}
