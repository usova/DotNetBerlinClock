using System;
using System.Text;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    public class BerlinClock
    {
        public LampRow HourTopRow { get; }
        public LampRow HourBottomRow { get; }
        public LampRow MinutTopRow { get; }
        public LampRow MinutBottomRow { get; }
        public LampRow SecondsRow { get; }

        public BerlinClock(ILampRowBuilder builder, TimeSpan time)
        {
            HourTopRow = builder.CreateHourRow();
            HourBottomRow = builder.CreateHourRow();
            MinutTopRow = builder.CreateTopMinuteRow();
            MinutBottomRow = builder.CreateBottomMinuteRow();
            SecondsRow = builder.CreateRowOfSecond();

            InitClock(time);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(SecondsRow.ToString())
                .AppendLine(HourTopRow.ToString())
                .AppendLine(HourBottomRow.ToString())
                .AppendLine(MinutTopRow.ToString())
                .Append(MinutBottomRow.ToString());

            return builder.ToString();
        }

        private void InitClock(TimeSpan time)
        {
            HourTopRow.TurnOn(GetTopRowHours(time));
            HourBottomRow.TurnOn(GetBottomRowHours(time));
            MinutTopRow.TurnOn(GetTopRowMinutes(time));
            MinutBottomRow.TurnOn(GetBottomRowMinutes(time));
            SecondsRow.TurnOn(GetSeconds(time));
        }

        private int GetTopRowHours(TimeSpan time) => (int)time.TotalHours / 5;

        private int GetBottomRowHours(TimeSpan time) => (int)time.TotalHours % 5;

        private int GetTopRowMinutes(TimeSpan time) => time.Minutes / 5;

        private int GetBottomRowMinutes(TimeSpan time) => time.Minutes % 5;

        private int GetSeconds(TimeSpan time) => time.Seconds % 2 == 0 ? 1 : 0;
    }
}