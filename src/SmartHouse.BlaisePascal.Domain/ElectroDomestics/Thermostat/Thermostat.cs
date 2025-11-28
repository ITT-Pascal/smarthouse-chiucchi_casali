using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public Thermostat(string name) : base(name) { }

        public void SetOperatingTemperature(int newTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                if (newTemperature > MinAmbientTemperature && newTemperature < MaxAmbientTemperature)
                    Temperature = newTemperature;
            }

            LastModification_UTC = DateTime.UtcNow;
        }



    }





}
}



//  -temperature
//  -manual mode
//  -auto mode
//  -set temperature for single hour
//	-set mode
//	-water temperature
//	-give temperature
//	-screen on		 (lampMatrix)
//	-screen off 	 (lampMatrix)

//	-toggle termosifoni

