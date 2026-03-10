using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Dto
{
    public class ThermostatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public double WorkingTemperature { get; set; }
        public DateTime LastModificationUtc { get; set; }
    }
}
