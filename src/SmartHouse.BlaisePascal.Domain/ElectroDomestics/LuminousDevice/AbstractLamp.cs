using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Interfaces;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public abstract class AbstractLamp:AbstractDevice, ILuminous
    {
        //Properties defined in the daughter classes
        public abstract Intensity MinIntensity { get; }
        public abstract Intensity MaxIntensity { get; }
        public abstract Intensity DefaultIntensity { get; }
        public Intensity Intensity { get; protected set; }

        //Constructor
        protected AbstractLamp(string name):base(name) { Intensity = Intensity.Create(0, MinIntensity._intensity, MaxIntensity._intensity); }


        //Methods
        //Override from AbstractDevice
        public override void SwitchOff() { base.SwitchOff(); Intensity = MinIntensity; }

        public override void SwitchOn() { base.SwitchOn(); Intensity = DefaultIntensity; }

        //Virtual methods
        public virtual void SetIntensity(int newIntensity)
        {
            if (newIntensity < MinIntensity || newIntensity > MaxIntensity) //Chiedi a pulga se bisogna fare il controllo anche se ho fatto clamp in Intensity
                throw new ArgumentOutOfRangeException("Brightness must be between min and max value", nameof(Intensity));

            CheckIsOff();

            if (MinIntensity == newIntensity)
                SwitchOff();
            else
                Intensity = Intensity.Create(newIntensity, MinIntensity._intensity, MaxIntensity._intensity);

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Dimmer(int amount)
        {
            CheckIsOff();

            Intensity = Intensity.Create(Intensity - amount, MinIntensity._intensity, MaxIntensity._intensity);

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Brighten(int amount)
        {
            CheckIsOff();

            Intensity = Intensity.Create(Intensity + amount, MinIntensity._intensity, MaxIntensity._intensity);

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}