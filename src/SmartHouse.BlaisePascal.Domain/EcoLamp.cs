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


        //public EcoLamp()
        //{
        //    Id = Guid.NewGuid();
        //    Brightness = MinBrightness;
        //    IsOn = false;
        //}

        //public EcoLamp(int brightness)
        //{
        //    Id = Guid.NewGuid();
        //    Brightness = brightness;
        //    IsOn = true;
        //}

        ////public EcoLamp(int brightness, string name)
        ////{
        ////    Id = Guid.NewGuid();
        ////    Brightness = brightness;
        ////    IsOn = false;
        ////    Name = name;
        ////}

        public EcoLamp(string name) : base(name) { }

        public void ToggleOnOff() => IsOn = !IsOn;

        public void SwitchOff()
        {
            base.SwitchOff();
            //if (!IsOn)
            //    throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            //IsOn = false;
            //Brightness = MinBrightness;
        }
        
        public void SwitchOn()
        {
            base.SwitchOn();
            //if (IsOn)
            //    throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            //IsOn = true;
            //Brightness = MaxBrightness;
            
        }

        public void SetBrightness(int newBrightness)
        {
            base.SetBrightness(newBrightness);
            //if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
            //    throw new ArgumentOutOfRangeException("Brightness must be between 0 and 70", nameof(Brightness));

            //if (!IsOn)
            //    throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            //if(newBrightness == MinBrightness)
            //    SwitchOff();
            //else
            //    Brightness = newBrightness;
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

        public void SetName(string name)
        {
            base.SetName(name);
        }
    }
}
