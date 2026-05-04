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
            this.InnerObservances.Add(YeniYil);
            this.InnerObservances.Add(CocukBayrami);
            this.InnerObservances.Add(IsciBayrami);
            this.InnerObservances.Add(GenclikVeSporBayrami);
            this.InnerObservances.Add(DemokrasiBayrami);
            this.InnerObservances.Add(ZaferBayrami);

            this.InnerObservances.Add(RamazanBayrami1);
            this.InnerObservances.Add(RamazanBayrami2);
            this.InnerObservances.Add(RamazanBayrami3);

            this.InnerObservances.Add(KurbanBayrami1);
            this.InnerObservances.Add(KurbanBayrami2);
            this.InnerObservances.Add(KurbanBayrami3);
            this.InnerObservances.Add(KurbanBayrami4);
        }

        private static NamedDay yeniYil;
        public static NamedDay YeniYil
        {
            get
            {
                if (yeniYil == null)
                {
                    yeniYil = new NamedDay("Yeni Yıl", new FixedDayResolver(1, 1));
                }
                return yeniYil;
            }
        }

        private static NamedDay cocukBayrami;
        public static NamedDay CocukBayrami
        {
            get
            {
                if (cocukBayrami == null)
                {
                    cocukBayrami = new NamedDay("23 Nisan Ulusal Egemenlik ve Çocuk Bayramı", new FixedDayResolver(4, 23));
                }
                return cocukBayrami;
            }
        }

        private static NamedDay isciBayrami;
        public static NamedDay IsciBayrami
        {
            get
            {
                if (isciBayrami == null)
                {
                    isciBayrami = new NamedDay("1 Mayıs Emek ve Dayanışma Günü", new FixedDayResolver(5, 1));
                }
                return isciBayrami;
            }
        }


        private static NamedDay genclikVeSporBayrami;
        public static NamedDay GenclikVeSporBayrami
        {
            get
            {
                if (genclikVeSporBayrami == null)
                {
                    genclikVeSporBayrami = new NamedDay("19 Mayıs Atatürk'ü Anma Gençlik ve Spor Bayramı", new FixedDayResolver(5, 19));
                }
                return genclikVeSporBayrami;
            }
        }

        private static NamedDay demokrasiBayrami;
        public static NamedDay DemokrasiBayrami
        {
            get
            {
                if (demokrasiBayrami == null)
                {
                    demokrasiBayrami = new NamedDay("15 Temmuz Demokrasi ve Özgürlükler Günü", new FixedDayResolver(7, 15));
                }
                return demokrasiBayrami;
            }
        }


        private static NamedDay zaferBayrami;
        public static NamedDay ZaferBayrami
        {
            get
            {
                if (zaferBayrami == null)
                {
                    zaferBayrami = new NamedDay("30 Ağustos Zafer Bayramı", new FixedDayResolver(8, 30));
                }
                return zaferBayrami;
            }
        }


        private static NamedDay ramazanbayrami1;
        public static NamedDay RamazanBayrami1
        {
            get
            {
                if (ramazanbayrami1 == null)
                {
                    ramazanbayrami1 = new NamedDay("Ramazan Bayramı 1. Günü", new FixedDayResolver(10, 1, new UmAlQuraCalendar()));
                }
                return ramazanbayrami1;
            }
        }

        private static NamedDay ramazanbayrami2;
        public static NamedDay RamazanBayrami2
        {
            get
            {
                if (ramazanbayrami2 == null)
                {
                    ramazanbayrami2 = new NamedDay("Ramazan Bayramı 2. Günü", new FixedDayResolver(10, 2, new UmAlQuraCalendar()));
                }
                return ramazanbayrami2;
            }
        }

        private static NamedDay ramazanbayrami3;
        public static NamedDay RamazanBayrami3
        {
            get
            {
                if (ramazanbayrami3 == null)
                {
                    ramazanbayrami3 = new NamedDay("Ramazan Bayramı 3. Günü", new FixedDayResolver(10, 3, new UmAlQuraCalendar()));
                }
                return ramazanbayrami3;
            }
        }

        private static NamedDay kurbanbayrami1;
        public static NamedDay KurbanBayrami1
        {
            get
            {
                if (kurbanbayrami1 == null)
                {
                    kurbanbayrami1 = new NamedDay("Kurban Bayramı 1. Günü", new FixedDayResolver(12, 10, new UmAlQuraCalendar()));
                }
                return kurbanbayrami1;
            }
        }

        private static NamedDay kurbanbayrami2;
        public static NamedDay KurbanBayrami2
        {
            get
            {
                if (kurbanbayrami2 == null)
                {
                    kurbanbayrami2 = new NamedDay("Kurban Bayramı 2. Günü", new FixedDayResolver(12, 11, new UmAlQuraCalendar()));
                }
                return kurbanbayrami2;
            }
        }

        private static NamedDay kurbanbayrami3;
        public static NamedDay KurbanBayrami3
        {
            get
            {
                if (kurbanbayrami3 == null)
                {
                    kurbanbayrami3 = new NamedDay("Kurban Bayramı 3. Günü", new FixedDayResolver(12, 12, new UmAlQuraCalendar()));
                }
                return kurbanbayrami3;
            }
        }

        private static NamedDay kurbanbayrami4;
        public static NamedDay KurbanBayrami4
        {
            get
            {
                if (kurbanbayrami4 == null)
                {
                    kurbanbayrami4 = new NamedDay("Kurban Bayramı 4. Günü", new FixedDayResolver(12, 13, new UmAlQuraCalendar()));
                }
                return kurbanbayrami4;
            }
        }





    }
}