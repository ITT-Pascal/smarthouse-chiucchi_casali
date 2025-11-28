using SmartHouse.BlaisePascal.Domain.ElectroDomestics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class EcoLamp: AbstractLamp
    {
        //Constants
        private const int StandardMin = 0;
        private const int StandardDeFault = 30;
        private const int StandardMax = 70;

        //Abstract properties ovveride
        public override int MinIntensity => StandardMin;
        public override int MaxIntensity => StandardMax;
        public override int DefaultIntensity => StandardDeFault;

        //Constructor
        public EcoLamp(string name) : base(name) { }



        //Methods
        public void AdjustIntensityByAmbientLight(int ambientBrightness) //Cambia brightness in base alla luminosità dell'ambiente in modo inversamente proporzionale.
        {
            if (ambientBrightness < MinIntensity || ambientBrightness > MaxIntensity)
                throw new ArgumentOutOfRangeException("Ambient brightness must be between MinBrightness and MaxBrightness", nameof(ambientBrightness));

            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(Status));

            Intensity = Math.Max(MinIntensity, Math.Min(MaxIntensity, MaxIntensity - ambientBrightness));

            if(Intensity == MinIntensity)
                SwitchOff();

            LastModification_UTC = DateTime.UtcNow;
        }


        public override void IsNight()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(Status));

            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte
                UltraEcoMode();
        }

        public override void UltraEcoMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(Status));

            Intensity = (int)(Intensity * 0.8); //Diminuisce del 20% la luminosità attuale (CASTING con int)

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
