using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class EcoLamp
    {
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }

        private const int MaxBrightness = 70;
        private const int MinBrightness = 0;
        public EcoLamp()
        {
            Brightness = MinBrightness;
            IsOn = false;
        }

        public EcoLamp(int brightness)
        {
            Brightness = brightness;
            IsOn = true;
            
        }

        public void TurnOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Brightness = MinBrightness;
        }
        
        public void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = MaxBrightness;
            
        }

        public void ChangeBrightness(int newBrightness)
        {
            if (newBrightness >= MinBrightness && newBrightness <= MaxBrightness)
            {
                if (IsOn)
                {
                    Brightness = newBrightness;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100", nameof(Brightness));
            }
        }

        public void AdjustBrightnessByAmbientLight(int ambientBrightness)
        {
            if(ambientBrightness>= MinBrightness && ambientBrightness<= MaxBrightness)
            {
                if (IsOn)
                    Brightness = Math.Max(MinBrightness, Math.Min(MaxBrightness, MaxBrightness - ambientBrightness));
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
            if(IsOn)
            {
                int hour = DateTime.Now.Hour;
                
                if(hour>=22 || hour < 6)
                {
                    UltraEcoMode();
                }

            }

        }


        public void UltraEcoMode()
        {
            if (IsOn)
            {
                Brightness = (int)(Brightness * 0.8);
            }
        }
    }
}
