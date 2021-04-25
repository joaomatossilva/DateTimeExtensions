#region License

// 
// Copyright (c) 2011-2012, Onur Özten <onur301@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using DateTimeExtensions.Common;
using System.Globalization;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("tr-TR")]
    public class TurkishHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar IndianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public TurkishHolidayStrategy()
        {
            this.InnerHolidays.Add(YeniYil);
            this.InnerHolidays.Add(CocukBayrami);
            this.InnerHolidays.Add(IsciBayrami);
            this.InnerHolidays.Add(GenclikVeSporBayrami);
            this.InnerHolidays.Add(DemokrasiBayrami);
            this.InnerHolidays.Add(ZaferBayrami);

            this.InnerHolidays.Add(RamazanBayrami1);
            this.InnerHolidays.Add(RamazanBayrami2);
            this.InnerHolidays.Add(RamazanBayrami3);

            this.InnerHolidays.Add(KurbanBayrami1);
            this.InnerHolidays.Add(KurbanBayrami2);
            this.InnerHolidays.Add(KurbanBayrami3);
            this.InnerHolidays.Add(KurbanBayrami4);
        }

        private static Holiday yeniYil;
        public static Holiday YeniYil
        {
            get
            {
                if (yeniYil == null)
                {
                    yeniYil = new FixedHoliday("Yeni Yıl", 1, 1);
                }
                return yeniYil;
            }
        }

        private static Holiday cocukBayrami;
        public static Holiday CocukBayrami
        {
            get
            {
                if (cocukBayrami == null)
                {
                    cocukBayrami = new FixedHoliday("23 Nisan Ulusal Egemenlik ve Çocuk Bayramı", 4, 23);
                }
                return cocukBayrami;
            }
        }

        private static Holiday isciBayrami;
        public static Holiday IsciBayrami
        {
            get
            {
                if (isciBayrami == null)
                {
                    isciBayrami = new FixedHoliday("1 Mayıs Emek ve Dayanışma Günü", 5, 1);
                }
                return isciBayrami;
            }
        }


        private static Holiday genclikVeSporBayrami;
        public static Holiday GenclikVeSporBayrami
        {
            get
            {
                if (genclikVeSporBayrami == null)
                {
                    genclikVeSporBayrami = new FixedHoliday("19 Mayıs Atatürk'ü Anma Gençlik ve Spor Bayramı", 5, 19);
                }
                return genclikVeSporBayrami;
            }
        }

        private static Holiday demokrasiBayrami;
        public static Holiday DemokrasiBayrami
        {
            get
            {
                if (demokrasiBayrami == null)
                {
                    demokrasiBayrami = new FixedHoliday("15 Temmuz Demokrasi ve Özgürlükler Günü", 7, 15);
                }
                return demokrasiBayrami;
            }
        }


        private static Holiday zaferBayrami;
        public static Holiday ZaferBayrami
        {
            get
            {
                if (zaferBayrami == null)
                {
                    zaferBayrami = new FixedHoliday("30 Ağustos Zafer Bayramı", 8, 30);
                }
                return zaferBayrami;
            }
        }


        private static Holiday ramazanbayrami1;
        public static Holiday RamazanBayrami1
        {
            get
            {
                if (ramazanbayrami1 == null)
                {
                    ramazanbayrami1 = new FixedHoliday("Ramazan Bayramı 1. Günü", 10, 1, new UmAlQuraCalendar());
                }
                return ramazanbayrami1;
            }
        }

        private static Holiday ramazanbayrami2;
        public static Holiday RamazanBayrami2
        {
            get
            {
                if (ramazanbayrami2 == null)
                {
                    ramazanbayrami2 = new FixedHoliday("Ramazan Bayramı 2. Günü", 10, 2, new UmAlQuraCalendar());
                }
                return ramazanbayrami2;
            }
        }

        private static Holiday ramazanbayrami3;
        public static Holiday RamazanBayrami3
        {
            get
            {
                if (ramazanbayrami3 == null)
                {
                    ramazanbayrami3 = new FixedHoliday("Ramazan Bayramı 3. Günü", 10, 3, new UmAlQuraCalendar());
                }
                return ramazanbayrami3;
            }
        }

        private static Holiday kurbanbayrami1;
        public static Holiday KurbanBayrami1
        {
            get
            {
                if (kurbanbayrami1 == null)
                {
                    kurbanbayrami1 = new FixedHoliday("Kurban Bayramı 1. Günü", 12, 10, new UmAlQuraCalendar());
                }
                return kurbanbayrami1;
            }
        }

        private static Holiday kurbanbayrami2;
        public static Holiday KurbanBayrami2
        {
            get
            {
                if (kurbanbayrami2 == null)
                {
                    kurbanbayrami2 = new FixedHoliday("Kurban Bayramı 2. Günü", 12, 11, new UmAlQuraCalendar());
                }
                return kurbanbayrami2;
            }
        }

        private static Holiday kurbanbayrami3;
        public static Holiday KurbanBayrami3
        {
            get
            {
                if (kurbanbayrami3 == null)
                {
                    kurbanbayrami3 = new FixedHoliday("Kurban Bayramı 3. Günü", 12, 12, new UmAlQuraCalendar());
                }
                return kurbanbayrami3;
            }
        }

        private static Holiday kurbanbayrami4;
        public static Holiday KurbanBayrami4
        {
            get
            {
                if (kurbanbayrami4 == null)
                {
                    kurbanbayrami4 = new FixedHoliday("Kurban Bayramı 4. Günü", 12, 13, new UmAlQuraCalendar());
                }
                return kurbanbayrami4;
            }
        }





    }
}