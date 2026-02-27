using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        //public string ImageUrl { get; set; }
        
        public string Status { get; set; }
        public int Brightness { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }
    }
}
