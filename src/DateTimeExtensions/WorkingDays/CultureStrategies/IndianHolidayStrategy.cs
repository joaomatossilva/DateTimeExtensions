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
            this.InnerObservances.AddHoliday(NewYear);
            this.InnerObservances.AddHoliday(MayDay);
            this.InnerObservances.AddHoliday(Christmas);

            // --- National Days ---
            this.InnerObservances.AddHoliday(RepublicDay);
            this.InnerObservances.AddHoliday(IndependenceDay);
            this.InnerObservances.AddHoliday(GandhiJayanti);

            // --- Major Religious and Regional Festivals ---
            this.InnerObservances.AddHoliday(MakarSankranti);
            this.InnerObservances.AddHoliday(Pongal);
            this.InnerObservances.AddHoliday(MahaShivaratri);
            this.InnerObservances.AddHoliday(Holi);
            this.InnerObservances.AddHoliday(GoodFriday);
            this.InnerObservances.AddHoliday(MahavirJayanti);
            this.InnerObservances.AddHoliday(EidUlFitr);
            this.InnerObservances.AddHoliday(EidUlAdha);
            this.InnerObservances.AddHoliday(RakshaBandhan);
            this.InnerObservances.AddHoliday(Janmashtami);
            this.InnerObservances.AddHoliday(GaneshChaturthi);
            this.InnerObservances.AddHoliday(Onam);
            this.InnerObservances.AddHoliday(Vishu);
            this.InnerObservances.AddHoliday(Baisakhi);
            this.InnerObservances.AddHoliday(Ugadi);
            this.InnerObservances.AddHoliday(EidMiladUnNabi);
            this.InnerObservances.AddHoliday(NavratriStart);
            this.InnerObservances.AddHoliday(Dussehra);
            this.InnerObservances.AddHoliday(KarwaChauth);
            this.InnerObservances.AddHoliday(Diwali);
            this.InnerObservances.AddHoliday(GovardhanPuja);
            this.InnerObservances.AddHoliday(BhaiDooj);
            this.InnerObservances.AddHoliday(ChhathPuja);
            this.InnerObservances.AddHoliday(GuruNanakJayanti);
            this.InnerObservances.AddHoliday(Lohri);
        }

        // --- Global Holidays ---        
        private static NamedDay newYear;
        public static NamedDay NewYear => newYear ?? (newYear = new NamedDay("New Year", new FixedDayResolver(1, 1, IndianCalendar)));

        private static NamedDay mayDay;
        public static NamedDay MayDay => mayDay ?? (mayDay = new NamedDay("May Day", new FixedDayResolver(5, 1, IndianCalendar)));

        private static NamedDay christmas;
        public static NamedDay Christmas => christmas ?? (christmas = new NamedDay("Christmas", new FixedDayResolver(12, 25, IndianCalendar)));

        // --- National Days ---        
        private static NamedDay republicDay;
        public static NamedDay RepublicDay => republicDay ?? (republicDay = new NamedDay("Republic Day", new FixedDayResolver(1, 26, IndianCalendar)));

        private static NamedDay independenceDay;
        public static NamedDay IndependenceDay => independenceDay ?? (independenceDay = new NamedDay("Independence Day", new FixedDayResolver(8, 15, IndianCalendar)));

        private static NamedDay gandhiJayanti;
        public static NamedDay GandhiJayanti => gandhiJayanti ?? (gandhiJayanti = new NamedDay("Gandhi Jayanti", new FixedDayResolver(10, 2, IndianCalendar)));

        // --- Religious & Regional ---        
        private static NamedDay makarSankranti;
        public static NamedDay MakarSankranti => makarSankranti ?? (makarSankranti = new NamedDay("Makar Sankranti", new FixedDayResolver(1, 14, IndianCalendar)));

        private static NamedDay pongal;
        public static NamedDay Pongal => pongal ?? (pongal = new NamedDay("Pongal", new FixedDayResolver(1, 15, IndianCalendar)));

        private static NamedDay mahaShivaratri;
        public static NamedDay MahaShivaratri => mahaShivaratri ?? (mahaShivaratri = new NamedDay("Maha Shivaratri", new FixedDayResolver(3, 8, IndianCalendar)));

        private static NamedDay holi;
        public static NamedDay Holi => holi ?? (holi = new NamedDay("Holi", new FixedDayResolver(3, 25, IndianCalendar)));

        private static NamedDay goodFriday;
        public static NamedDay GoodFriday => goodFriday ?? (goodFriday = new NamedDay("Good Friday", new FixedDayResolver(3, 29, IndianCalendar)));        
        
        private static NamedDay mahavirJayanti;
        public static NamedDay MahavirJayanti => mahavirJayanti ?? (mahavirJayanti = new NamedDay("Mahavir Jayanti", new FixedDayResolver(4, 21, IndianCalendar)));

        private static NamedDay eidUlFitr;
        public static NamedDay EidUlFitr => eidUlFitr ?? (eidUlFitr = new NamedDay("Eid-ul-Fitr", new FixedDayResolver(4, 10, IndianCalendar)));

        private static NamedDay eidUlAdha;
        public static NamedDay EidUlAdha => eidUlAdha ?? (eidUlAdha = new NamedDay("Eid-ul-Adha", new FixedDayResolver(6, 17, IndianCalendar)));

        private static NamedDay rakshaBandhan;
        public static NamedDay RakshaBandhan => rakshaBandhan ?? (rakshaBandhan = new NamedDay("Raksha Bandhan", new FixedDayResolver(8, 19, IndianCalendar)));

        private static NamedDay janmashtami;
        public static NamedDay Janmashtami => janmashtami ?? (janmashtami = new NamedDay("Janmashtami", new FixedDayResolver(8, 26, IndianCalendar)));        
        
        private static NamedDay ganeshChaturthi;
        public static NamedDay GaneshChaturthi => ganeshChaturthi ?? (ganeshChaturthi = new NamedDay("Ganesh Chaturthi", new FixedDayResolver(9, 7, IndianCalendar)));

        private static NamedDay onam;
        public static NamedDay Onam => onam ?? (onam = new NamedDay("Onam", new FixedDayResolver(8, 30, IndianCalendar)));

        private static NamedDay vishu;
        public static NamedDay Vishu => vishu ?? (vishu = new NamedDay("Vishu", new FixedDayResolver(4, 14, IndianCalendar)));

        private static NamedDay baisakhi;
        public static NamedDay Baisakhi => baisakhi ?? (baisakhi = new NamedDay("Baisakhi", new FixedDayResolver(4, 13, IndianCalendar)));

        private static NamedDay ugadi;
        public static NamedDay Ugadi => ugadi ?? (ugadi = new NamedDay("Ugadi", new FixedDayResolver(4, 9, IndianCalendar)));

        private static NamedDay eidMiladUnNabi;
        public static NamedDay EidMiladUnNabi => eidMiladUnNabi ?? (eidMiladUnNabi = new NamedDay("Eid Milad-un-Nabi", new FixedDayResolver(9, 27, IndianCalendar)));

        private static NamedDay navratriStart;
        public static NamedDay NavratriStart => navratriStart ?? (navratriStart = new NamedDay("Navratri Start", new FixedDayResolver(10, 3, IndianCalendar)));

        private static NamedDay dussehra;
        public static NamedDay Dussehra => dussehra ?? (dussehra = new NamedDay("Dussehra", new FixedDayResolver(10, 12, IndianCalendar)));

        private static NamedDay karwaChauth;
        public static NamedDay KarwaChauth => karwaChauth ?? (karwaChauth = new NamedDay("Karwa Chauth", new FixedDayResolver(10, 19, IndianCalendar)));

        private static NamedDay diwali;
        public static NamedDay Diwali => diwali ?? (diwali = new NamedDay("Diwali", new FixedDayResolver(11, 1, IndianCalendar)));

        private static NamedDay govardhanPuja;
        public static NamedDay GovardhanPuja => govardhanPuja ?? (govardhanPuja = new NamedDay("Govardhan Puja", new FixedDayResolver(11, 2, IndianCalendar)));

        private static NamedDay bhaiDooj;
        public static NamedDay BhaiDooj => bhaiDooj ?? (bhaiDooj = new NamedDay("Bhai Dooj", new FixedDayResolver(11, 3, IndianCalendar)));

        private static NamedDay chhathPuja;
        public static NamedDay ChhathPuja => chhathPuja ?? (chhathPuja = new NamedDay("Chhath Puja", new FixedDayResolver(11, 8, IndianCalendar)));

        private static NamedDay guruNanakJayanti;
        public static NamedDay GuruNanakJayanti => guruNanakJayanti ?? (guruNanakJayanti = new NamedDay("Guru Nanak Jayanti", new FixedDayResolver(11, 15, IndianCalendar)));

        private static NamedDay lohri;
        public static NamedDay Lohri => lohri ?? (lohri = new NamedDay("Lohri", new FixedDayResolver(1, 13, IndianCalendar)));
    }
}
