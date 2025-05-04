﻿using DateTimeExtensions.Common;
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

        // --- Global Holidays ---
        private static Holiday newYear;
        public static Holiday NewYear => newYear ??= new FixedHoliday("New Year", 1, 1, IndianCalendar);

        private static Holiday mayDay;
        public static Holiday MayDay => mayDay ??= new FixedHoliday("May Day", 5, 1, IndianCalendar);

        private static Holiday christmas;
        public static Holiday Christmas => christmas ??= new FixedHoliday("Christmas", 12, 25, IndianCalendar);

        // --- National Days ---
        private static Holiday republicDay;
        public static Holiday RepublicDay => republicDay ??= new FixedHoliday("Republic Day", 1, 26, IndianCalendar);

        private static Holiday independenceDay;
        public static Holiday IndependenceDay => independenceDay ??= new FixedHoliday("Independence Day", 8, 15, IndianCalendar);

        private static Holiday gandhiJayanti;
        public static Holiday GandhiJayanti => gandhiJayanti ??= new FixedHoliday("Gandhi Jayanti", 10, 2, IndianCalendar);

        // --- Religious & Regional ---
        private static Holiday makarSankranti;
        public static Holiday MakarSankranti => makarSankranti ??= new FixedHoliday("Makar Sankranti", 1, 14, IndianCalendar);

        private static Holiday pongal;
        public static Holiday Pongal => pongal ??= new FixedHoliday("Pongal", 1, 15, IndianCalendar);

        private static Holiday mahaShivaratri;
        public static Holiday MahaShivaratri => mahaShivaratri ??= new FixedHoliday("Maha Shivaratri", 3, 8, IndianCalendar);

        private static Holiday holi;
        public static Holiday Holi => holi ??= new FixedHoliday("Holi", 3, 25, IndianCalendar);

        private static Holiday goodFriday;
        public static Holiday GoodFriday => goodFriday ??= new FixedHoliday("Good Friday", 3, 29, IndianCalendar);

        private static Holiday mahavirJayanti;
        public static Holiday MahavirJayanti => mahavirJayanti ??= new FixedHoliday("Mahavir Jayanti", 4, 21, IndianCalendar);

        private static Holiday eidUlFitr;
        public static Holiday EidUlFitr => eidUlFitr ??= new FixedHoliday("Eid-ul-Fitr", 4, 10, IndianCalendar);

        private static Holiday eidUlAdha;
        public static Holiday EidUlAdha => eidUlAdha ??= new FixedHoliday("Eid-ul-Adha", 6, 17, IndianCalendar);

        private static Holiday rakshaBandhan;
        public static Holiday RakshaBandhan => rakshaBandhan ??= new FixedHoliday("Raksha Bandhan", 8, 19, IndianCalendar);

        private static Holiday janmashtami;
        public static Holiday Janmashtami => janmashtami ??= new FixedHoliday("Janmashtami", 8, 26, IndianCalendar);

        private static Holiday ganeshChaturthi;
        public static Holiday GaneshChaturthi => ganeshChaturthi ??= new FixedHoliday("Ganesh Chaturthi", 9, 7, IndianCalendar);

        private static Holiday onam;
        public static Holiday Onam => onam ??= new FixedHoliday("Onam", 8, 30, IndianCalendar);

        private static Holiday vishu;
        public static Holiday Vishu => vishu ??= new FixedHoliday("Vishu", 4, 14, IndianCalendar);

        private static Holiday baisakhi;
        public static Holiday Baisakhi => baisakhi ??= new FixedHoliday("Baisakhi", 4, 13, IndianCalendar);

        private static Holiday ugadi;
        public static Holiday Ugadi => ugadi ??= new FixedHoliday("Ugadi", 4, 9, IndianCalendar);

        private static Holiday eidMiladUnNabi;
        public static Holiday EidMiladUnNabi => eidMiladUnNabi ??= new FixedHoliday("Eid Milad-un-Nabi", 9, 27, IndianCalendar);

        private static Holiday navratriStart;
        public static Holiday NavratriStart => navratriStart ??= new FixedHoliday("Navratri Start", 10, 3, IndianCalendar);

        private static Holiday dussehra;
        public static Holiday Dussehra => dussehra ??= new FixedHoliday("Dussehra", 10, 12, IndianCalendar);

        private static Holiday karwaChauth;
        public static Holiday KarwaChauth => karwaChauth ??= new FixedHoliday("Karwa Chauth", 10, 19, IndianCalendar);

        private static Holiday diwali;
        public static Holiday Diwali => diwali ??= new FixedHoliday("Diwali", 11, 1, IndianCalendar);

        private static Holiday govardhanPuja;
        public static Holiday GovardhanPuja => govardhanPuja ??= new FixedHoliday("Govardhan Puja", 11, 2, IndianCalendar);

        private static Holiday bhaiDooj;
        public static Holiday BhaiDooj => bhaiDooj ??= new FixedHoliday("Bhai Dooj", 11, 3, IndianCalendar);

        private static Holiday chhathPuja;
        public static Holiday ChhathPuja => chhathPuja ??= new FixedHoliday("Chhath Puja", 11, 8, IndianCalendar);

        private static Holiday guruNanakJayanti;
        public static Holiday GuruNanakJayanti => guruNanakJayanti ??= new FixedHoliday("Guru Nanak Jayanti", 11, 15, IndianCalendar);

        private static Holiday lohri;
        public static Holiday Lohri => lohri ??= new FixedHoliday("Lohri", 1, 13, IndianCalendar);
    }
}
