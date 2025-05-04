using DateTimeExtensions.Common;
using System.Globalization;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-IN")]
    public class IndianHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar IndianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public IndianHolidayStrategy()
        {
            // --- Global Holidays ---
            this.InnerHolidays.Add(NewYear);
            this.InnerHolidays.Add(MayDay);
            this.InnerHolidays.Add(Christmas);

            // --- National Days ---
            this.InnerHolidays.Add(RepublicDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(GandhiJayanti);

            // --- Major Religious and Regional Festivals ---
            this.InnerHolidays.Add(MakarSankranti);
            this.InnerHolidays.Add(Pongal);
            this.InnerHolidays.Add(MahaShivaratri);
            this.InnerHolidays.Add(Holi);
            this.InnerHolidays.Add(GoodFriday);
            this.InnerHolidays.Add(MahavirJayanti);
            this.InnerHolidays.Add(EidUlFitr);
            this.InnerHolidays.Add(EidUlAdha);
            this.InnerHolidays.Add(RakshaBandhan);
            this.InnerHolidays.Add(Janmashtami);
            this.InnerHolidays.Add(GaneshChaturthi);
            this.InnerHolidays.Add(Onam);
            this.InnerHolidays.Add(Vishu);
            this.InnerHolidays.Add(Baisakhi);
            this.InnerHolidays.Add(Ugadi);
            this.InnerHolidays.Add(EidMiladUnNabi);
            this.InnerHolidays.Add(NavratriStart);
            this.InnerHolidays.Add(Dussehra);
            this.InnerHolidays.Add(KarwaChauth);
            this.InnerHolidays.Add(Diwali);
            this.InnerHolidays.Add(GovardhanPuja);
            this.InnerHolidays.Add(BhaiDooj);
            this.InnerHolidays.Add(ChhathPuja);
            this.InnerHolidays.Add(GuruNanakJayanti);
            this.InnerHolidays.Add(Lohri);
        }

        // --- Static Holiday Definitions ---

        private static Holiday NewYear => new FixedHoliday("New Year", 1, 1, IndianCalendar);
        private static Holiday MayDay => new FixedHoliday("May Day", 5, 1, IndianCalendar);
        private static Holiday Christmas => new FixedHoliday("Christmas", 12, 25, IndianCalendar);

        private static Holiday RepublicDay => new FixedHoliday("Republic Day", 1, 26, IndianCalendar);
        private static Holiday IndependenceDay => new FixedHoliday("Independence Day", 8, 15, IndianCalendar);
        private static Holiday GandhiJayanti => new FixedHoliday("Gandhi Jayanti", 10, 2, IndianCalendar);

        private static Holiday MakarSankranti => new FixedHoliday("Makar Sankranti", 1, 14, IndianCalendar);
        private static Holiday Pongal => new FixedHoliday("Pongal", 1, 15, IndianCalendar);
        private static Holiday MahaShivaratri => new FixedHoliday("Maha Shivaratri", 3, 8, IndianCalendar);
        private static Holiday Holi => new FixedHoliday("Holi", 3, 25, IndianCalendar);
        private static Holiday GoodFriday => new FixedHoliday("Good Friday", 3, 29, IndianCalendar); // approx
        private static Holiday MahavirJayanti => new FixedHoliday("Mahavir Jayanti", 4, 21, IndianCalendar);
        private static Holiday EidUlFitr => new FixedHoliday("Eid-ul-Fitr", 4, 10, IndianCalendar); // approx
        private static Holiday EidUlAdha => new FixedHoliday("Eid-ul-Adha", 6, 17, IndianCalendar); // approx
        private static Holiday RakshaBandhan => new FixedHoliday("Raksha Bandhan", 8, 19, IndianCalendar);
        private static Holiday Janmashtami => new FixedHoliday("Janmashtami", 8, 26, IndianCalendar);
        private static Holiday GaneshChaturthi => new FixedHoliday("Ganesh Chaturthi", 9, 7, IndianCalendar);
        private static Holiday Onam => new FixedHoliday("Onam", 8, 30, IndianCalendar);
        private static Holiday Vishu => new FixedHoliday("Vishu", 4, 14, IndianCalendar);
        private static Holiday Baisakhi => new FixedHoliday("Baisakhi", 4, 13, IndianCalendar);
        private static Holiday Ugadi => new FixedHoliday("Ugadi", 4, 9, IndianCalendar);
        private static Holiday EidMiladUnNabi => new FixedHoliday("Eid Milad-un-Nabi", 9, 27, IndianCalendar); // approx
        private static Holiday NavratriStart => new FixedHoliday("Navratri Start", 10, 3, IndianCalendar);
        private static Holiday Dussehra => new FixedHoliday("Dussehra", 10, 12, IndianCalendar);
        private static Holiday KarwaChauth => new FixedHoliday("Karwa Chauth", 10, 19, IndianCalendar);
        private static Holiday Diwali => new FixedHoliday("Diwali", 11, 1, IndianCalendar);
        private static Holiday GovardhanPuja => new FixedHoliday("Govardhan Puja", 11, 2, IndianCalendar);
        private static Holiday BhaiDooj => new FixedHoliday("Bhai Dooj", 11, 3, IndianCalendar);
        private static Holiday ChhathPuja => new FixedHoliday("Chhath Puja", 11, 8, IndianCalendar);
        private static Holiday GuruNanakJayanti => new FixedHoliday("Guru Nanak Jayanti", 11, 15, IndianCalendar);
        private static Holiday Lohri => new FixedHoliday("Lohri", 1, 13, IndianCalendar);
    }
}
