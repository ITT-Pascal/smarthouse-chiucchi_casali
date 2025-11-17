using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public abstract class AbstractLamp
    {
        //Const
        public const int MinBrightness = 0;
        public const int MaxBrightness = 100;
        //Properties
        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime_UTC { get; protected set; }
        public DateTime LastModification_UTC { get; protected set; }

        //Constructor
        protected AbstractLamp(string name)
        {
            IsOn = false;
            Id = Guid.NewGuid();
            Name = name;
            Brightness = MinBrightness;
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
            Brightness = MinBrightness;
        }
        
        public virtual void SwitchOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = 70;


        }
        
        public virtual void SetBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Brightness must be between min and max value", nameof(Brightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if (newBrightness == MinBrightness)
                SwitchOff();
            else
                Brightness = newBrightness;
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
            int newValue = Math.Max(0, Brightness - amount);

            if (newValue == Brightness)
                throw new InvalidOperationException("L'intensità non può essere ulteriormente diminuita.");
        }
    }
}
