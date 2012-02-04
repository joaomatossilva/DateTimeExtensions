using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public abstract class NaturalTimeStrategyBase : INaturalTimeStrategy {

		protected abstract string YearText { get; }
		protected abstract string MonthText { get; }
		protected abstract string DayText { get; }
		protected abstract string HourText { get; }
		protected abstract string MinuteText { get; }
		protected abstract string SecondText { get; }
		protected virtual string SentenceJoinerFormat {
			get {
				return "{0}, {1}";
			}
		}

		public string ToNaturalText(DateDiff dateDiff, bool round) {
			return BuildNaturalText(dateDiff, true, round);
		}

		public string ToExactNaturalText(DateDiff dateDiff) {
			return this.BuildNaturalText(dateDiff, false, false);
		}

		protected virtual string BuildNaturalText(DateDiff dateDiff, bool stopOnFirsValue, bool round) {
			string text = string.Empty;
			if (dateDiff.Years > 0) {
				text = this.AddSentence(text, this.GetYearsText(dateDiff.Years));
				if (stopOnFirsValue) {
					return text;
				}
			}
			if (dateDiff.Months > 0) {
				text = this.AddSentence(text, this.GetMonthsText(dateDiff.Months));
				if (stopOnFirsValue) {
					return text;
				}
			}
			if (dateDiff.Days > 0) {
				text = this.AddSentence(text, this.GetDaysText(dateDiff.Days));
				if (stopOnFirsValue) {
					return text;
				}
			}
			if (dateDiff.Hours > 0) {
				text = this.AddSentence(text, this.GetHoursText(dateDiff.Hours));
				if (stopOnFirsValue) {
					return text;
				}
			}
			if (dateDiff.Minutes > 0) {
				text = this.AddSentence(text, this.GetMinutesText(dateDiff.Minutes));
				if (stopOnFirsValue) {
					return text;
				}
			}
			if (dateDiff.Seconds > 0) {
				text = this.AddSentence(text, this.GetSecondsText(dateDiff.Seconds));
			}
			return text;
		}

		private string AddSentence(string text, string sentence) {
			if (string.IsNullOrEmpty(text)) {
				return sentence;
			}
			return string.Format(SentenceJoinerFormat, text, sentence);
		}

		protected virtual string GetYearsText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? YearText : this.Pluralize(YearText));
		}

		protected virtual string GetMonthsText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? MonthText : this.Pluralize(MonthText));
		}

		protected virtual string GetDaysText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? DayText : this.Pluralize(DayText));
		}

		protected virtual string GetHoursText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? HourText : this.Pluralize(HourText));
		}

		protected virtual string GetMinutesText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? MinuteText : this.Pluralize(MinuteText));
		}

		protected virtual string GetSecondsText(int value) {
			return string.Format("{0} {1}", value, value == 1 ? SecondText : this.Pluralize(SecondText));
		}


		protected virtual string Pluralize(string text) {
			return text + "s";
		}
	}
}
