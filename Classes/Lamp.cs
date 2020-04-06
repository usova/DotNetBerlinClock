using BerlinClock.Enums;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    public class Lamp : ILamp
    {
        public Colors LampColor { get; }

        public override string ToString() => IsOn ? LampColor.ToString()[0].ToString() : "O";

        public bool IsOn { get; set; }

        public Lamp(Colors color) => LampColor = color;

        public void TurnOn() => IsOn = true;

        public void TurnOff() => IsOn = false;
    }
}