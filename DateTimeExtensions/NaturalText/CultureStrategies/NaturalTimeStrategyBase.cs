using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.NaturalText.CultureStrategies {
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

		public virtual string ToNaturalText(DateDiff dateDiff, bool round) {
			if (dateDiff.Years > 0) {
				if (round && dateDiff.Months >= 6) {
					return this.GetYearsText(dateDiff.Years + 1);
				}
				return this.GetYearsText(dateDiff.Years);
			}
			if (dateDiff.Months > 0) {
				if (round && dateDiff.Days >= 15) {
					return this.GetMonthsText(dateDiff.Months + 1);
				}
				return this.GetMonthsText(dateDiff.Months);
			}
			if (dateDiff.Days > 0) {
				if (round && dateDiff.Hours >= 12) {
					return this.GetDaysText(dateDiff.Days + 1);
				}
				return this.GetDaysText(dateDiff.Days);
			}
			if (!round) {
				if (dateDiff.Hours > 0) {
					return this.GetHoursText(dateDiff.Hours);
				}
				if (dateDiff.Minutes > 0) {
					return this.GetMinutesText(dateDiff.Minutes);
				}
				if (dateDiff.Seconds > 0) {
					return this.GetSecondsText(dateDiff.Seconds);
				}
			}
			bool carrier;
			var minutes = SixtyToQuarters(dateDiff.Minutes, out carrier);
			if (dateDiff.Hours > 0 || carrier) {
				if (carrier || minutes >= 30) {
					return this.GetHoursText(dateDiff.Hours + 1);
				}
				return this.GetHoursText(dateDiff.Hours);
			}
			var seconds = this.SixtyToQuarters(dateDiff.Seconds, out carrier);
			if (minutes == 0 && dateDiff.Minutes > 0) {
				if(seconds >= 30 || carrier) {
					return this.GetMinutesText(dateDiff.Minutes + 1);
				}
				return this.GetMinutesText(dateDiff.Minutes);
			}
			if (minutes == 0 && carrier) {
				return this.GetMinutesText(1);
			}
			if (minutes > 0) {
				return this.GetMinutesText(minutes);
			}
			if (seconds > 0) {
				return this.GetSecondsText(seconds);
			}
			return string.Empty;
		}

		public virtual string ToExactNaturalText(DateDiff dateDiff) {
			string text = string.Empty;
			if (dateDiff.Years > 0) {
				text = this.AddSentence(text, this.GetYearsText(dateDiff.Years));
			}
			if (dateDiff.Months > 0) {
				text = this.AddSentence(text, this.GetMonthsText(dateDiff.Months));
			}
			if (dateDiff.Days > 0) {
				text = this.AddSentence(text, this.GetDaysText(dateDiff.Days));
			}
			if (dateDiff.Hours > 0) {
				text = this.AddSentence(text, this.GetHoursText(dateDiff.Hours));
			}
			if (dateDiff.Minutes > 0) {
				text = this.AddSentence(text, this.GetMinutesText(dateDiff.Minutes));
			}
			if (dateDiff.Seconds > 0) {
				text = this.AddSentence(text, this.GetSecondsText(dateDiff.Seconds));
			}
			return text;
		}

		private int SixtyToQuarters(int sixtyValue, out bool carrier) {
			if (sixtyValue < 0 || sixtyValue >= 60) {
				throw new ArgumentException("sixtyValue must be between 0 and 59", "sixtyValue");
			}
			carrier = false;
			if (sixtyValue <= 7) {
				return 0;
			}
			if (sixtyValue <= 22) {
				return 15;
			}
			if (sixtyValue <= 37) {
				return 30;
			}
			if (sixtyValue <= 52) {
				return 45;
			}
			carrier = true;
			return 0;
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
