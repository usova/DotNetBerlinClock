using BerlinClock.Enums;

namespace BerlinClock.Interfaces
{
    public interface ILamp
    {
        Colors LampColor { get; }
        bool IsOn { get; set; }
    }
}