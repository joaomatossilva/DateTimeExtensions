#region License

// 
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using DateTimeExtensions.Common;
using DateTimeExtensions.NaturalText.CultureStrategies;

namespace DateTimeExtensions.NaturalText
{
    public class NaturalTextCultureInfo : INaturalTextCultureInfo
    {
        private string name;
        private INaturalTimeStrategy naturalTimeStrategy;

        public NaturalTextCultureInfo() : this(CultureInfo.CurrentCulture.Name)
        {
        }

        public NaturalTextCultureInfo(string name)
        {
            this.name = name;
            this.LocateNaturalTimeStrategy = DefaultLocateNaturalTimeStrategy;
        }

        public string Name
        {
            get { return name; }
        }

        public string ToNaturalText(DateDiff span, bool round)
        {
            return naturalTimeStrategy.ToNaturalText(span, round);
        }

        public string ToExactNaturalText(DateDiff span)
        {
            return naturalTimeStrategy.ToExactNaturalText(span);
        }

        private Func<string, INaturalTimeStrategy> locateNaturalTimeStrategy;

        public Func<string, INaturalTimeStrategy> LocateNaturalTimeStrategy
        {
            get { return locateNaturalTimeStrategy; }
            set
            {
                if (value != null)
                {
                    locateNaturalTimeStrategy = value;
                    naturalTimeStrategy = locateNaturalTimeStrategy(name);
                }
                else
                {
                    throw new ArgumentNullException("value");
                }
            }
        }

        public static readonly Func<string, INaturalTimeStrategy> DefaultLocateNaturalTimeStrategy =
            name =>
                LocaleImplementationLocator.FindImplementationOf<INaturalTimeStrategy>(name, null) ??
                new DefaultNaturalTimeStrategy();
    }
}