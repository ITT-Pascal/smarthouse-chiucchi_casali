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

        //Temperature notturne
        private const int DefaultNightReachingTemperature = 18;
        public int NightTemperature { get; private set; }
        private bool _isNight;

        //Properties
        public Values Power { get; private set; }
        public bool Automatic { get; private set; }

        //Temperatura ambientale
        public int AmbientTemperature { get; private set; }

        //Temperatura di lavoro attuale
        public int ActualReachingTemperature { get; private set; }


        //Costruttore
        public Thermostat(string name) : base(name) { }

        //Legge la temperatura ambientale
        public void ReadAmbientTemperature(int ambientTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                AmbientTemperature = ambientTemperature;

                LastModification_UTC = DateTime.UtcNow;
            }
        }

        //Setta la temperatura a cui si vuole arrivare con il termostato
        private void SetOperatingTemperatures(int newTemperature, int nightTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (newTemperature >= MinReachingTemperature && newTemperature <= MaxReachingTemperature)
                    ActualReachingTemperature = newTemperature;
                
                if (nightTemperature >= MinReachingTemperature && nightTemperature <= MaxReachingTemperature)
                    NightTemperature = nightTemperature;
            }
            
            LastModification_UTC = DateTime.UtcNow;
        }

        //Selezione della modalità di lavoro del termostato => manuale
        public void ManualMode(int newTemperature, Values power, int nightTemperature)
        {

            if(Status == DeviceStatus.On)
                SetOperatingTemperatures(newTemperature, nightTemperature);
            Power = power;

            LastModification_UTC = DateTime.UtcNow;
            
            Automatic = false;
        }
        
        //Selezione della modalità di lavoro del termostato => automatica  
        public void AutomaticMode()
        {
            Automatic = true;
            if (Status == DeviceStatus.On)
            {
                if (_isNight == true)
                {
                    IsNight();
                    return;
                }
                if (AmbientTemperature <= MinReachingTemperature)
                {
                    Power = Values.Four;
                    SetReachingTemperature();
                }
                else if(AmbientTemperature <= DefaultReachingTemperature)
                {
                    Power = Values.Three;
                    SetReachingTemperature();
                }
                else if(AmbientTemperature <= MaxReachingTemperature)
                {
                    Power = Values.Two;
                    SetReachingTemperature();
                }
                else
                {
                    Status = DeviceStatus.Standby;
                }
                LastModification_UTC = DateTime.UtcNow;
            }
        }
        
        private void SetReachingTemperature() //Setta la temperatura in base alla potenza selezionata
        {
            if (Status == DeviceStatus.On)
            {
                if (Power == Values.One)
                {
                    ActualReachingTemperature = MinReachingTemperature;
                }
                else if (Power == Values.Two)
                {
                    ActualReachingTemperature = MinReachingTemperature + 2;
                }
                else if (Power == Values.Three)
                {
                    ActualReachingTemperature = DefaultReachingTemperature;
                }
                else if (Power == Values.Four)
                {
                    ActualReachingTemperature = DefaultReachingTemperature + 3;
                }
                else
                {
                    ActualReachingTemperature = MaxReachingTemperature;
                }   
            }

            if(Automatic == true)
            {
                ActualReachingTemperature = DefaultReachingTemperature;
            }

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IsNight()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6)//Orari convenzionali per la notte
            {
                _isNight = true;

                if (Automatic == true)
                {
                    ActualReachingTemperature = DefaultNightReachingTemperature;
                }
                else
                {
                    ActualReachingTemperature = NightTemperature;
                }
            }
            _isNight = false;
        }
    }
}