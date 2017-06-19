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
                .Where(p => type.IsAssignableFrom(p.GetTypeInfo()) && p.GetTypeInfo().GetCustomAttributes(typeof(LocaleAttribute), false)
                    .Any(a => ((LocaleAttribute) a).Locale.Equals(locale)));

            var implementationType = types.FirstOrDefault();
            if (implementationType == null)
            {
                return default(T);
            }

            string[] parameters = null;
            if(implementationType.GetTypeInfo().DeclaredConstructors.Any(x => x.IsPublic && x.GetParameters().Count() > 0))
            {
                parameters = new []{ region };
            }

            var instance = (T) Activator.CreateInstance(implementationType, parameters);
            if (instance == null)
            {
                //throw new StrategyNotFoundException(string.Format("Could not create a new instance of type '{0}'.", typeName));
                return default(T);
            }
            return instance;
        }
    }
}