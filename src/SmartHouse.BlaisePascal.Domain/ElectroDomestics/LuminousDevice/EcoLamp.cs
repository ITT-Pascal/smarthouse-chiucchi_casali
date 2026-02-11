using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class EcoLamp : AbstractLamp
    {
        //Defining standards
        Intensity StandardMin { get; init; } = Intensity.Create(0, 0, 70);
        Intensity StandardDefault { get; init; } = Intensity.Create(30, 0, 70);
        Intensity StandardMax { get; init; } = Intensity.Create(70, 0, 70);

        //Abstract properties override
        public override Intensity MinIntensity => StandardMin;
        public override Intensity MaxIntensity => StandardMax;
        public override Intensity DefaultIntensity => StandardDefault;

        //Properties AutoOff
        private DateTime? autoOffAtUtc;
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        //Constructor
        public EcoLamp(string name) : base(name) { }


        //AutoOff methods
        public override void SwitchOn() //SwitchOn without AutoOff timer (Normal lamp)
        {
            SwitchOn(enableAutoOff: false);
        }

        public void SwitchOn(bool enableAutoOff) //Decide to add or not AutoOff timer
        {
            base.SwitchOn();
            autoOffAtUtc = enableAutoOff? DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes) : null;
        }

        //public void SwitchOn(int autoOffMinutes) //SwitchOn with AutoOff (decide timer length)
        //{
        //    if (autoOffMinutes < MinAutoOffMinutes)
        //        throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));

        //    base.SwitchOn();
        //    autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        //}

        //public override void SetIntensity(int value) //Resets AutoOff if needed
        //{
        //    base.SetIntensity(value);
        //    ResetAutoOffIfNeeded();
        //}

        //public override void Dimmer(int amount) //Resets AutoOff if needed
        //{
        //    base.Dimmer(amount);
        //    ResetAutoOffIfNeeded();
        //}

        //public override void Brighten(int amount) //Resets AutoOff if needed
        //{
        //    base.Brighten(amount);
        //    ResetAutoOffIfNeeded();
        //}

        //public override void SwitchOff() //Nulls the AutoOff timer
        //{
        //    base.SwitchOff();
        //    autoOffAtUtc = null;
        //}

        //public void CheckAutoOff() //Controls if AutoOff time is up (if true switches off)
        //{
        //    if (Status == DeviceStatus.On && autoOffAtUtc.HasValue && DateTime.UtcNow >= autoOffAtUtc.Value)
        //        SwitchOff();
        //    else
        //        throw new ArgumentException("no", nameof(autoOffAtUtc));
        //}

        //private void ResetAutoOffIfNeeded()
        //{
        //    if (autoOffAtUtc.HasValue)
        //        autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        //}


        //Special eco methods
        public void AdjustIntensityByAmbientLight(int ambientBrightness) //Adjusts brightness by the ambient brightness with inverse proportionality
        {
            if (ambientBrightness < MinIntensity || ambientBrightness > MaxIntensity)
                throw new ArgumentOutOfRangeException("Ambient brightness must be between MinBrightness and MaxBrightness", nameof(ambientBrightness));

            CheckIsOff();

            Intensity = Intensity.Create(Math.Max(MinIntensity._intensity, Math.Min(MaxIntensity._intensity, MaxIntensity._intensity - ambientBrightness)), MinIntensity._intensity, MaxIntensity._intensity);

            //ResetAutoOffIfNeeded();

            if (Intensity == MinIntensity)
                SwitchOff();

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IsNight()
        {
            CheckIsOff();

            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6) //Conventional hours for night
                UltraEcoMode();
        }

        public void UltraEcoMode()
        {
            CheckIsOff();

            Intensity = Intensity.Create(Intensity._intensity * 0.8, MinIntensity._intensity, MaxIntensity._intensity); //Reduces current brightness by 20%

            //ResetAutoOffIfNeeded();

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}

//ALTERNATIVE METHOD
//if (ambientBrightness == MinBrightness)
//{
//    Brightness = MaxBrightness;

//}else if (ambientBrightness <= 25)
//{
//    Brightness = 50;

//}else if (ambientBrightness >= 25 && ambientBrightness <= 50)
//{
//    Brightness = 25;

//}else if(ambientBrightness >=50)
//{
//    Brightness = MinBrightness;
//}
