using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public abstract class AbstractLamp:AbstractDevice, ILuminous
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

            CheckIsOff();

            if (newIntensity == MinIntensity)
                SwitchOff();
            else
                Intensity = newIntensity;

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Dimmer(int amount)
        {
            CheckIsOff();

            Intensity = Math.Max(MinIntensity, Intensity - amount);

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Brighten(int amount)
        {
            CheckIsOff();

            Intensity = Math.Min(MaxIntensity, Intensity + amount);

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}