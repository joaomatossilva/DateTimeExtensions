﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using DateTimeExtensions.NaturalText.CultureStrategies;

namespace DateTimeExtensions.NaturalText {

	public class NaturalTextCultureInfo : INaturalTextCultureInfo {
		private string name;
		private INaturalTimeStrategy naturalTimeStrategy;

		public NaturalTextCultureInfo() : this(CultureInfo.CurrentCulture.Name) { 
		}

		public NaturalTextCultureInfo(string name) {
			this.name = name;
			this.LocateNaturalTimeStrategy = NaturalTextStrategyLocatorByName.LocateNaturalTimeStrategyForName;
		}

		public string Name { 
			get{
				return name;
			} 
		}

		public string ToNaturalText(DateDiff span, bool round) {
			return naturalTimeStrategy.ToNaturalText(span, round);
		}

		public string ToExactNaturalText(DateDiff span) {
			return naturalTimeStrategy.ToExactNaturalText(span);
		}

		private Func<string, INaturalTimeStrategy> locateNaturalTimeStrategy;
		public Func<string, INaturalTimeStrategy> LocateNaturalTimeStrategy {
			get { return locateNaturalTimeStrategy; }
			set {
				if (value != null) {
					locateNaturalTimeStrategy = value;
					naturalTimeStrategy = locateNaturalTimeStrategy(name);
				} else {
					throw new ArgumentNullException("value");
				}
			}
		}
	}
}