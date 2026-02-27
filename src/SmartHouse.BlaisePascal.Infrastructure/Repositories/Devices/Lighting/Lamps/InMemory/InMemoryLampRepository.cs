using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.Lighting.Lamps.InMemory
{
    public class InMemoryLampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp> 
            {
                new Lamp(new DeviceName("a"), new DeviceImage(""))
            }
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }
    }
}
