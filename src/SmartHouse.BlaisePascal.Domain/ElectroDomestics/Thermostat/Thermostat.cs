using Microsoft.VisualBasic;
using SmartHouse.BlaisePascal.Domain.Shared;
using System.Runtime.CompilerServices;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat
{
    public class Thermostat:AbstractDevice
    {
        
        //Costanti: di temperatura minima e massima a cui si accende il termostato:  17 <= x <= 30
        private const int MinReachingTemperature = 17;
        private const int DefaultReachingTemperature = 22;
        private const int MaxReachingTemperature = 29;

        //Temperatura notturna default
        private const int DefaultNightReachingTemperature = 18;

        //Temperatura dell'acqua => Varia in base alla potenza e alla temperatura da raggiungere.
        private int WaterTemperature { get; set; }

        //Properties
        public Values Power { get; private set; }

        //Temperatura ambientale
        public int AmbientTemperature { get; private set; }

        //Temperatura di lavoro attuale
        public int ActualReachingTemperature { get; private set; }


        //Costruttore
        public Thermostat(string name) : base(name) { }

        //Setta la temperatura a cui si vuole arrivare con il termostato
        private void SetOperatingTemperature(int newTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (newTemperature >= MinReachingTemperature && newTemperature <= MaxReachingTemperature)
                    ActualReachingTemperature = newTemperature;
            }
            
            LastModification_UTC = DateTime.UtcNow;
        }

        //Legge la temperatura ambientale
        public void ReadAmbientTemperature(int ambientTemperature)
        {
            if(Status == DeviceStatus.On)
            {
                AmbientTemperature = ambientTemperature;
                LastModification_UTC = DateTime.UtcNow;
            }
        }

        //Selezione della modalità di lavoro del termostato
        public void ManualMode(int newTemperature)
        {

            if(Status == DeviceStatus.On)
                SetOperatingTemperature(newTemperature);
            
            LastModification_UTC = DateTime.UtcNow;
        }
        //TODO AutomaticMode
        public void AutomaticMode()
        {
             if(Status == DeviceStatus.On)
            {
                if()
                if(AmbientTemperature < MinReachingTemperature)
                {
                    Power = Values.One;
                    SetPower();
                }
            }

            LastModification_UTC = DateTime.UtcNow;
        }
        //TODO check
        private int SetPower()
        {
            if (Power == Values.One)
            {
                ActualReachingTemperature = MinReachingTemperature;
                WaterTemperature = 25;
            }
            else if (Power == Values.Two)
            {
                ActualReachingTemperature = MinReachingTemperature + 2;
                WaterTemperature = 30;
            }
            else if (Power == Values.Three)
            {
                ActualReachingTemperature = DefaultReachingTemperature;
                WaterTemperature = 35;
            }
            else if(Power == Values.Four)
            {
                ActualReachingTemperature = DefaultReachingTemperature + 3;
                WaterTemperature = 45;
            }
            else
            {
                ActualReachingTemperature = MaxReachingTemperature;
                WaterTemperature = 65;
            }

            LastModification_UTC = DateTime.UtcNow;

            return ActualReachingTemperature;
        }
        //TODO finish
        public override void IsNight()
        {  
            ActualReachingTemperature = DefaultNightReachingTemperature;
        }
    }
}