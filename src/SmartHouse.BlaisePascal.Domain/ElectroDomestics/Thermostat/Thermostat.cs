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
    public class Thermostat:DeviceProperties
    {
        //Properties ereditate
        public override Guid Id { get; protected set; }
        public override string Name { get; protected set; } = string.Empty;
        public override DeviceStatus Status { get; protected set; }

        public override DateTime CreationTime_UTC { get; protected set; }
        public override DateTime LastModification_UTC { get; protected set; }
        
        //Properties
        public int Temperature { get; private set; }
        public Values Mode { get; private set; }

        private const int MinTemperature = 18;

        private const int MaxTemperature = 30;

        public Thermostat(string name) : base(name) { }

        public void SetTemperature(int newTemperature)
        {
            if(Status == DeviceStatus.On)
            {
                if(Temperature > MinTemperature && Temperature < MaxTemperature )
                    Temperature = newTemperature;
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

