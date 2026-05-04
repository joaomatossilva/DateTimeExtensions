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
using System.Reflection;
using System.Resources;

namespace DateTimeExtensions.WorkingDays
{
    /// <summary>
    /// Representation of a named day instance
    /// </summary>
    public class NamedDay
    {
        /// <summary>
        /// Constructs a new instance of the NamedDay class
        /// </summary>
        /// <param name="name">name or resource key of the day</param>
        /// <param name="resolver">The day resolver to resolve the day in a given year</param>
        public NamedDay(string name, IDayResolver resolver)
        {
            this.name = name;
            this.resolver = resolver;
        }

        private readonly string name;

        private readonly IDayResolver resolver;

        public string Name => ResourceManager.GetString(name) ?? name;

        public IDayResolver Resolver => resolver;

        public DateTime? GetInstance(int year) => resolver.GetInstance(year);

        public bool IsInstanceOf(DateTime date) => resolver.IsInstanceOf(date);


        private static ResourceManager resourceManager =
            new("DateTimeExtensions.WorkingDays.HolidayNames", typeof (NamedDay).GetTypeInfo().Assembly);

        public static ResourceManager ResourceManager
        {
            get => resourceManager;
            set => resourceManager = value ?? throw new ArgumentNullException("value");
        }
    }
}