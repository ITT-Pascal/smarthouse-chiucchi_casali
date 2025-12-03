using SmartHouse.BlaisePascal.Domain.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public class EcoLamp : AbstractLamp
    {
        //Constants
        private const int StandardMin = 0;
        private const int StandardDeFault = 30;
        private const int StandardMax = 70;

        //Abstract properties ovveride
        public override int MinIntensity => StandardMin;
        public override int MaxIntensity => StandardMax;
        public override int DefaultIntensity => StandardDeFault;

        //Properties AutoOff
        private DateTime? autoOffAtUtc;
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        //Constructor
        public EcoLamp(string name) : base(name) { }



        //Methods
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

        public void SwitchOn(int autoOffMinutes) //SwitchOn with AutoOff (decide timer length)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));

            base.SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }

        public override void SetIntensity(int value) //Resets AutoOff if needed
        {
            base.SetIntensity(value);
            ResetAutoOffIfNeeded();
        }

        public override void Dimmer(int amount) //Resets AutoOff if needed
        {
            base.Dimmer(amount);
            ResetAutoOffIfNeeded();
        }

        public override void Brighten(int amount) //Resets AutoOff if needed
        {
            base.Brighten(amount);
            ResetAutoOffIfNeeded();
        }

        public override void SwitchOff() //Nulls the AutoOff timer
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }

        public void CheckAutoOff() //Controls if AutoOff time is up (if true switches off)
        {
            if (Status == DeviceStatus.On && autoOffAtUtc.HasValue && DateTime.UtcNow >= autoOffAtUtc.Value)
                SwitchOff();
        }

        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }


        //Special eco methods
        public void AdjustIntensityByAmbientLight(int ambientBrightness) //Cambia brightness in base alla luminosità dell'ambiente in modo inversamente proporzionale
        {
            if (ambientBrightness < MinIntensity || ambientBrightness > MaxIntensity)
                throw new ArgumentOutOfRangeException("Ambient brightness must be between MinBrightness and MaxBrightness", nameof(ambientBrightness));

            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(Status));

            Intensity = Math.Max(MinIntensity, Math.Min(MaxIntensity, MaxIntensity - ambientBrightness));

            ResetAutoOffIfNeeded();

            if (Intensity == MinIntensity)
                SwitchOff();

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IsNight()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(Status));

            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte
                UltraEcoMode();
        }

        public void UltraEcoMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(Status));

            Intensity = (int)(Intensity * 0.8); //Diminuisce del 20% la luminosità attuale

            ResetAutoOffIfNeeded();

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
