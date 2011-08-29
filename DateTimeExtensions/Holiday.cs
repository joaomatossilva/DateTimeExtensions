using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public abstract class Holiday {

		public Holiday(string name) {
			this.Name = name;
		}

		public string Name { get; private set; }
		public abstract DateTime GetInstance(int year);
		public abstract bool IsInstanceOf(DateTime date);
	}
}
