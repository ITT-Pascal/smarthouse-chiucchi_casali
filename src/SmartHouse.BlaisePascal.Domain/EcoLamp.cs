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
        new private const int MaxBrightness = 70;

        public EcoLamp(string name) : base(name) { }

        public override void ToggleOnOff() => IsOn = !IsOn;

        public override void SwitchOff()
        {
            base.SwitchOff();
        }
        
        public override void SwitchOn()
        {
            base.SwitchOn();
        }

        public override void SetBrightness(int newBrightness)
        {
            base.SetBrightness(newBrightness);
        }

        public void AdjustBrightnessByAmbientLight(int ambientBrightness) //cambia brightness in base alla luminosità dell'ambiente in modo inversamente proporzionale.
        {
            if (ambientBrightness < MinBrightness || ambientBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Ambient brightness must be between MinBrightness and MaxBrightness", nameof(ambientBrightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            Brightness = Math.Max(MinBrightness, Math.Min(MaxBrightness, MaxBrightness - ambientBrightness));

            if(Brightness == MinBrightness)
                SwitchOff();

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
        }


        public void IsNight()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(IsOn));

            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte
                UltraEcoMode();
        }


        public void UltraEcoMode()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(IsOn));

            Brightness = (int)(Brightness * 0.8); //Diminuisce del 20% la luminosità attuale
        }

        public override void SetName(string name)
        {
            base.SetName(name);
        }
    }
}
