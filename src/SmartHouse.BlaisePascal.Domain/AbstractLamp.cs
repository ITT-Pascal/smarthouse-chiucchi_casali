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
        public const int MinBrightness = 0;


        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime_UTC { get; protected set; }
        public DateTime LastMofification_UTC { get; protected set; }
        public abstract void ToggleOnOff();
        public abstract void SwitchOff();
        public abstract void SwitchOn();
        public abstract void SetBrightness(int newBrightness);
        public abstract void SetName(string name);

        protected AbstractLamp(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brightness = 0;
            Status = DeviceStatus.Off;
            CreationTime_UTC = DateTime.UtcNow;
            LastMofification_UTC = DateTime.UtcNow;
        }

        public void Toggle()
        {
            if (Status == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();

            LastMofification_UTC = DateTime.UtcNow;
        }


        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Impossibile regolare l'intensità: la lampada è spenta.");
            int newValue = Math.Max(0, Brightness - amount);

            if (newValue == Brightness);
            throw new InvalidOperationException("L'intensità non può essere ulteriormente diminuita.");
        }
            
        }
    }
}
