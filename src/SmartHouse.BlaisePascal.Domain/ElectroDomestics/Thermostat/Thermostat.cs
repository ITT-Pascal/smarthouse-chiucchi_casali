using SmartHouse.BlaisePascal.Domain.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat
{
    public class Thermostat:AbstractDevice
    {
        
        //Properties
        public int Temperature { get; private set; }
        public Values Mode { get; private set; }
        
        //Costanti: di temperatura minima e massima. Si accende se:  17 <= x <= 30
        private const int MinAmbientTemperature = 17;
        private const int MaxAmbientTemperature = 30;

        //Temperatura ambientale
        public int AmbientTemperature { get; private set; }

        //Temperatura di lavoro attuale
        public int ActualWorkingTemperature { get; private set; }


        
        //Costruttore
        public Thermostat(string name) : base(name) { }

        //Setta la temperatura a cui si vuole arrivare con il termostato
        public void SetOperatingTemperature(int newTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (newTemperature >= MinAmbientTemperature && newTemperature <= MaxAmbientTemperature)
                    Temperature = newTemperature;
            }
            ActualWorkingTemperature = newTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        

        //Legge la temperatura ambientale
        public void ReadAmbientTemperature(int ambientTemperature)
        {
            AmbientTemperature = ambientTemperature;
            
            LastModification_UTC = DateTime.UtcNow;
        }

        //Selezione della modalità di lavoro del termostato
        public void SetManualMode()
        {
            
        }

        public void SetAutoMode()
        {
            
        }


    }
}



//  -manual mode
//  -auto mode
//  -set temperature for single hour
//	-set mode

//	-toggle termosifoni
//	-water temperature
//	-give temperature

