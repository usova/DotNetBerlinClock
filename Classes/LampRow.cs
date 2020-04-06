using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes
{
    public class LampRow
    {
        private IEnumerable<Lamp> lamps;

        public LampRow(IEnumerable<Lamp> lamps)
        {
            this.lamps = lamps ?? throw new ArgumentNullException(nameof(lamps));
        }

        public void TurnOn(int lamsCount)
        {
            foreach (var lamp in lamps.Take(lamsCount))
            {
               lamp.TurnOn(); 
            }

            foreach (var lamp in lamps.Skip(lamsCount))
            {
                lamp.TurnOff();   
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var lamp in lamps)
            {
                builder.Append(lamp);
            }

            return builder.ToString();
        }
    }
}