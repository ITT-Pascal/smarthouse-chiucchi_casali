using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class TwoLampsDevice
    {
        public AbstractLamp Lamp1 { get; private set; }
        public AbstractLamp Lamp2 { get; private set; }

        public TwoLampsDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        public void TurnOffOneLamp(bool lamp)
        {
            if(lamp == true)
            {
                Lamp1.TurnOff();
            } else
            {
                Lamp2.TurnOff();
            }
        }
        public void TurnOnOneLamp(bool lamp)
        {
            if (lamp == true)
            {
                Lamp1.TurnOn();
            }
            else
            {
                Lamp2.TurnOn();
            }
        }
        public void TurnOffBothLamps()
        {
            Lamp1.TurnOff();
            Lamp2.TurnOff();
        }
        public void TurnOnBothLamps()
        {
            Lamp1.TurnOn();
            Lamp2.TurnOn();
        }
        public void ChangeOneLampBrightness(bool lamp, int brightness)
        {
            if(lamp == false)
            {
                Lamp1.ChangeBrightness(brightness);
            } else
            {
                Lamp2.ChangeBrightness(brightness);
            }
        }
        public void ChangeBothLampsBrightness(int firstBrightness, int secondBrightness)
        {
            Lamp1.ChangeBrightness(firstBrightness);
            Lamp2.ChangeBrightness(secondBrightness);
        }
    }
}
