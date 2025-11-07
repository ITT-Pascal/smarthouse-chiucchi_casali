using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public abstract class AbstractLamp
    {
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }

        public abstract void TurnOff();

        public abstract void TurnOn();

        public abstract void ChangeBrightness(int newBrightness);
    }
}
