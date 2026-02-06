using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

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
        public virtual void SetIntensity(Intensity newIntensity)
        {
            if (newIntensity < MinIntensity || newIntensity > MaxIntensity) //Chiedi a pulga se bisogna fare il cntrollo anche se ho fatto clamp in Intensity
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

            Intensity = Intensity.Create(Intensity._intensity - amount, MinIntensity._intensity, MaxIntensity._intensity);

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Brighten(int amount)
        {
            CheckIsOff();

            Intensity = Intensity.Create(Intensity._intensity + amount, MinIntensity._intensity, MaxIntensity._intensity);

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}