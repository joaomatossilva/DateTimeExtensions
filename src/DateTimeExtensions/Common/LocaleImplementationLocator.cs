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
using System.Linq;
using System.Reflection;

namespace DateTimeExtensions.Common
{
    public static class LocaleImplementationLocator
    {
        public static T FindImplementationOf<T>(string locale, string region, params Assembly[] assemblies)
        {
            var type = typeof(T).GetTypeInfo();
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = new [] { type.Assembly };
            }
            var types = assemblies.SelectMany(a => a.GetAssemblyTypes())
                .Where(x => MatchTypePredicate(x.GetTypeInfo()));

            bool MatchTypePredicate(TypeInfo proposedType)
            {
                if (!type.IsAssignableFrom(proposedType)) {
                    //if the type does not implement the type of our generic, don't even look further
                    return false;
                }

                var localeAttribute = proposedType.GetCustomAttributes(typeof(LocaleAttribute), false).FirstOrDefault() as LocaleAttribute;
                if(localeAttribute == null)
                {
                    //if we don't have a locale attribure, don't look further also
                    return false;
                }

                if(localeAttribute.Locale == null || !localeAttribute.Locale.Equals(locale, StringComparison.OrdinalIgnoreCase))
                {
                    //if the locale is not the same, this is not the implementation we're looking for
                    return false;
                }

                if(string.IsNullOrEmpty(region) && string.IsNullOrEmpty(localeAttribute.Region))
                {
                    //if there is no region and this type does not have a region set, we've found our candidate
                    return true;
                }
                else if(!string.IsNullOrEmpty(region) && region.Equals(localeAttribute.Region, StringComparison.OrdinalIgnoreCase))
                {
                    //we found our locale and region
                    return true;
                }
                return false;
            }

            var implementationType = types.FirstOrDefault();
            if (implementationType == null)
            {
                return default(T);
            }

            var instance = (T) Activator.CreateInstance(implementationType);
            if (instance == null)
            {
                //throw new StrategyNotFoundException(string.Format("Could not create a new instance of type '{0}'.", typeName));
                return default(T);
            }
            return instance;
        }
    }
}