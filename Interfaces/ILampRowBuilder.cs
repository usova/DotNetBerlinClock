using BerlinClock.Classes;

namespace BerlinClock.Interfaces
{
    public interface ILampRowBuilder
    {
        LampRow CreateHourRow();

        LampRow CreateTopMinuteRow();

        LampRow CreateBottomMinuteRow();

        LampRow CreateRowOfSecond();
    }
}