using SmartHouse.BlaisePascal.Domain.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public abstract class AbstractLamp:AbstractDevice
    {
        //Properties defined in the daughter classes
        public abstract int MinIntensity { get; }
        public abstract int MaxIntensity { get; }
        public abstract int DefaultIntensity { get; }
        public int Intensity { get; set; }

        //Constructor
        protected AbstractLamp(string name):base(name) { Intensity = MinIntensity; }


        //Methods
        //Override from AbstractDevice
        public override void SwitchOff() { base.SwitchOff(); Intensity = MinIntensity; }

        public override void SwitchOn() { base.SwitchOn(); Intensity = DefaultIntensity; }

        //Virtual methods
        public virtual void SetIntensity(int newIntensity)
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

        public virtual void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot dimmer lamp because it's off.");

            int newValue = Math.Max(MinIntensity, Intensity - amount);

            if (newValue == Intensity)
                throw new InvalidOperationException("Intensity cannot be dimmered more.");

            Intensity = newValue;

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot brighten lamp because it's off.");

            int newValue = Math.Min(MaxIntensity, Intensity + amount);
            
            Intensity = newValue;

            LastModification_UTC = DateTime.UtcNow;
        }

        //static void ControlIfStatusIsOn()       CONTROLLO FATTO MOLTE VOLTE
        //{
        //    if (Status != DeviceStatus.On)
        //        throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(Status));
        //}
    }
}


//public virtual void ToggleOnOff()
//{
//    IsOn = !IsOn;
//}