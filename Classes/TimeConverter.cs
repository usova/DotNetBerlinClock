using System;
using System.Text.RegularExpressions;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private const string TimeRegExp = @"(?<hour>(2[0-4]|[0-1]\d)):(?<min>[0-5]\d):(?<sec>[0-5]\d)";

        public string ConvertTime(string aTime)
        {
            if (!IsValid(aTime))
                throw new Exception("Time format is not valid");

            var time = Parse(aTime);

            var clock = new BerlinClock(new LampRowBuilder(), time);

            return clock.ToString();
        }

        private bool IsValid(string time)
        {
            var expectedStringLength = 8;
            var regex = new Regex(TimeRegExp);

            return !string.IsNullOrWhiteSpace(time)
                   && time.Length == expectedStringLength
                   && regex.IsMatch(time);
        }

        private TimeSpan Parse(string time)
        {
            var secondsKey = "sec";
            var minutesKey = "min";
            var hoursKey = "hour";

            var regex = new Regex(TimeRegExp);
            var match = regex.Matches(time)[0];

            return new TimeSpan(GetParsedValue(match, hoursKey),
                GetParsedValue(match, minutesKey), 
                GetParsedValue(match, secondsKey));
        }

        private int GetParsedValue(Match match, string key)
        {
            return int.Parse(match.Groups[key].Value);
        }
    }
}
