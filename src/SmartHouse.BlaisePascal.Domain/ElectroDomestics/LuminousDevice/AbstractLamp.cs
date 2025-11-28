using SmartHouse.BlaisePascal.Domain.ElectroDomestics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public abstract class AbstractLamp:AbstractDevice
    {
        //Properties ereditate

        //Properties defined in the daughter classes
        public abstract int MinIntensity { get; }
        public abstract int MaxIntensity { get; }
        public abstract int DefaultIntensity { get; }
        public int Intensity { get; set; }

        //Constructor
        protected AbstractLamp(string name):base(name)
        {
            Intensity = MinIntensity;
        }


        //Methods

        //Override from AbstractDevice
        public override void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(Status));
            
            Status = DeviceStatus.Off;
            Intensity = MinIntensity;

            LastModification_UTC = DateTime.UtcNow;
        }
        
        //Override from AbstractDevice
        public override void SwitchOn()
        {
            if (Status == DeviceStatus.On)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(Status));
            
            Status = DeviceStatus.On;
            Intensity = DefaultIntensity;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetIntensity(int newIntensity)
        {
            if (newIntensity < MinIntensity || newIntensity > MaxIntensity)
                throw new ArgumentOutOfRangeException("Brightness must be between min and max value", nameof(Intensity));

            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(Status));

            if (newIntensity == MinIntensity)
                SwitchOff();
            else
                Intensity = newIntensity;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot dimmer lamp because it's off.");

            int newValue = Math.Max(MinIntensity, Intensity - amount);

            if (newValue == Intensity)
                throw new InvalidOperationException("Intensity cannot be dimmered more.");

            Intensity = newValue;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot brighten lamp because it's off.");

            int newValue = Math.Min(MaxIntensity, Intensity + amount);
            
            Intensity = newValue;

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}


//public virtual void ToggleOnOff()
//{
//    IsOn = !IsOn;
//}