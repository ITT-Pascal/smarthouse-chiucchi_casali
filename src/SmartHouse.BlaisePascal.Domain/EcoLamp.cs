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
        private const int MaxBrightness = 70;
        private const int MinBrightness = 0;
        public EcoLamp()
        {
            Brightness = MinBrightness;
            IsOn = false;
            Id = Guid.NewGuid();
        }

        public EcoLamp(int brightness)
        {
            Brightness = brightness;
            IsOn = true;
            Id = Guid.NewGuid();
        }

        public override void ToggleOnOff()
        {
            IsOn = !IsOn;
        }

        public override void TurnOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Brightness = MinBrightness;
        }
        
        public override void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = MaxBrightness;
            
        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 70", nameof(Brightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if(newBrightness == MinBrightness)
            {
                TurnOff();
            } else
            {
                Brightness = newBrightness;
            } 
        }

        public void AdjustBrightnessByAmbientLight(int ambientBrightness)
        {
            if (ambientBrightness < MinBrightness || ambientBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Ambient brightness must be between MinBrightness and MaxBrightness", nameof(ambientBrightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            Brightness = Math.Max(MinBrightness, Math.Min(MaxBrightness, MaxBrightness - ambientBrightness));

            if(Brightness == MinBrightness)
            {
                TurnOff();
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
        }


        public void IsNight()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(IsOn));

            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte
            {
                UltraEcoMode();
            }
        }


        public void UltraEcoMode()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot reduce brightness when lamp is off", nameof(IsOn));

            Brightness = (int)(Brightness * 0.8); //Diminuisce del 20% la luminosità attuale
        }
    }
}
