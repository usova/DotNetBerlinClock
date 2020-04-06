using BerlinClock.Enums;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    public class LampRowBuilder : ILampRowBuilder
    {
        public LampRow CreateHourRow()
        {
            return new LampRow(new Lamp[]
            {
                GetRedLamp(),
                GetRedLamp(),
                GetRedLamp(),
                GetRedLamp()
            });
        }

        public LampRow CreateTopMinuteRow()
        {
            return new LampRow(new Lamp[]
            {
                GetYellowLamp(),
                GetYellowLamp(),
                GetRedLamp(),
                GetYellowLamp(),
                GetYellowLamp(),
                GetRedLamp(),
                GetYellowLamp(),
                GetYellowLamp(),
                GetRedLamp(),
                GetYellowLamp(),
                GetYellowLamp()
            });
        }

        public LampRow CreateBottomMinuteRow()
        {
            return new LampRow(new Lamp[]
            {
                GetYellowLamp(),
                GetYellowLamp(),
                GetYellowLamp(),
                GetYellowLamp()
            });
        }

        public LampRow CreateRowOfSecond()
        {
            return new LampRow(new Lamp[]
            {
                GetYellowLamp(), 
            });
        }
        
        private static Lamp GetRedLamp() => new Lamp(Colors.Red);

        private static Lamp GetYellowLamp() => new Lamp(Colors.Yellow);
    }
}