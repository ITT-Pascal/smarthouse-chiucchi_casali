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
            Lamp1 = lamp1 ?? throw new ArgumentNullException(nameof(lamp1));
            Lamp2 = lamp2 ?? throw new ArgumentNullException(nameof(lamp2));
        }

        public void ToggleOneLamp(Guid id)
        {
            if(Lamp1.Id == id)
                Lamp1.Toggle();
            else if(Lamp2.Id == id)
                Lamp2.Toggle();
        }

        //public void TurnOnOneLamp(Guid id)
        //{
        //    if (Lamp1.Id == id)
        //    {
        //        Lamp1.ToggleOnOff();
        //    }
        //    else if(Lamp2.Id == id)
        //    {
        //        Lamp2.ToggleOnOff();
        //    }
        //}

        public void TurnOffBothLamps()
        {
            if (Lamp2.Status == DeviceStatus.On)
                Lamp1.Toggle();
            if (Lamp2.Status == DeviceStatus.On)
                Lamp2.Toggle();
        }

        public void TurnOnBothLamps()
        {
            if (Lamp2.Status == DeviceStatus.Off)
                Lamp1.Toggle();
            if (Lamp2.Status == DeviceStatus.Off)
                Lamp2.Toggle();
        }

        public void SetOneLampIntensity(Guid id, int brightness)
        {
            if(Lamp1.Id == id)
                Lamp1.SetIntensity(brightness);
            else if(Lamp2.Id == id)
                Lamp2.SetIntensity(brightness);
        }

        public void SetBothLampsIntensity(int firstBrightness, int secondBrightness)
        {
            Lamp1.SetIntensity(firstBrightness);
            Lamp2.SetIntensity(secondBrightness);
        }

        public void DimmerOneLamp(Guid id, int amount)
        {
            if (Lamp1.Id == id)
                Lamp1.Dimmer(amount);
            else if (Lamp2.Id == id)
                Lamp2.Dimmer(amount);
        }

        public void DimmerBothLamps(int amount1, int amount2)
        {
            Lamp1.Dimmer(amount1);
            Lamp2.Dimmer(amount2);
        }

        public void BrightenOneLamp(Guid id, int amount)
        {
            if (Lamp1.Id == id)
                Lamp1.Brighten(amount);
            else if (Lamp2.Id == id)
                Lamp2.Brighten(amount);
        }

        public void BrightenBothLamps(int amount1, int amount2)
        {
            Lamp1.Brighten(amount1);
            Lamp2.Brighten(amount2);
        }
    }
}