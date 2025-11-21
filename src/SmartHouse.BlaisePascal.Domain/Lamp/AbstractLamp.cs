using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public abstract class AbstractLamp
    {
        //Properties
        public Guid Id { get; protected set; }
        public string Name { get; protected set; } = string.Empty;

        public bool IsOn { get; protected set; }
        public int Intensity { get; protected set; }
        
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime_UTC { get; protected set; }
        public DateTime LastModification_UTC { get; protected set; }

        //Properties defined in the daughter classes
        public abstract int MinIntensity { get; }
        public abstract int MaxIntensity { get; }
        public abstract int DefaultIntensity { get; }

        //Constructor
        protected AbstractLamp(string name)
        {
            IsOn = false;
            Id = Guid.NewGuid();
            Name = name;
            Intensity = MinIntensity;
            Status = DeviceStatus.Off;
            CreationTime_UTC = DateTime.UtcNow;
            LastModification_UTC = DateTime.UtcNow;
        }

        //Methods
        
        public virtual void ToggleOnOff()
        {
            IsOn = !IsOn;
        }
        
        public virtual void SwitchOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Intensity = MinIntensity;
        }
        
        public virtual void SwitchOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Intensity = MaxIntensity;
        }
        
        public virtual void SetIntensity(int newIntensity)
        {
            if (newIntensity < MinIntensity || newIntensity > MaxIntensity)
                throw new ArgumentOutOfRangeException("Brightness must be between min and max value", nameof(Intensity));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if (newIntensity == MinIntensity)
                SwitchOff();
            else
                Intensity = newIntensity;
        }

        public virtual void SetName(string name)
        {
            if (name != null)
                Name = name;
        }

        //TODO Later...
        public void Toggle()
        {
            if (Status == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();

            LastModification_UTC = DateTime.UtcNow;
        }

        // TODO Later...
        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Impossibile regolare l'intensità: la lampada è spenta.");
            
            int newValue = Math.Max(0, Intensity - amount);
            if (newValue == Intensity)
                throw new InvalidOperationException("L'intensità non può essere ulteriormente diminuita.");

            Intensity = newValue;
            LastModification_UTC = DateTime.UtcNow;
        }

        
    }
}
