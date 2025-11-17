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

        public void ToggleOneLamp(Guid id)
        {
            if(Lamp1.Id == id)
                Lamp1.ToggleOnOff();
            else if(Lamp2.Id == id)
                Lamp2.ToggleOnOff();
        }
        /*public void TurnOnOneLamp(Guid id)
        {
            if (Lamp1.Id == id)
            {
                Lamp1.ToggleOnOff();
            }
            else if(Lamp2.Id == id)
            {
                Lamp2.ToggleOnOff();
            }
        }*/

        public void TurnOffBothLamps()
        {
            if (Lamp1.IsOn)
                Lamp1.ToggleOnOff();
            if (Lamp2.IsOn)
                Lamp2.ToggleOnOff();
        }

        public void TurnOnBothLamps()
        {
            if (!Lamp1.IsOn)
                Lamp1.ToggleOnOff();
            if (!Lamp2.IsOn)
                Lamp2.ToggleOnOff();
        }

        public void ChangeOneLampBrightness(Guid id, int brightness)
        {
            if(Lamp1.Id == id)
                Lamp1.SetBrightness(brightness);
            else if(Lamp2.Id == id)
                Lamp2.SetBrightness(brightness);
        }

        public void ChangeBothLampsBrightness(int firstBrightness, int secondBrightness)
        {
            Lamp1.SetBrightness(firstBrightness);
            Lamp2.SetBrightness(secondBrightness);
        }
    }
}