using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.AirConditionerDevice
{
    public class InMemoryAirConditionerRepository : IAirConditionerRepository
    {
        private readonly List<AirConditioner> _airConditioners;

        public InMemoryAirConditionerRepository()
        {
            _airConditioners = new List<AirConditioner>
            {
                new AirConditioner("Pulga"),
                new AirConditioner("Tappi"),
                new AirConditioner("Biondi")
            };
        }

        public void Add(AirConditioner airConditioner)
        {
            if (airConditioner == null)
                throw new ArgumentException("Can't add a null air conditioner");
            _airConditioners.Add(airConditioner);
        }

        public void Remove(Guid id)
        {
            var airConditioner = GetById(id);
            if (airConditioner != null)
                _airConditioners.Remove(airConditioner);
        }

        public AirConditioner GetById(Guid id) => _airConditioners.FirstOrDefault(ac => ac.Id == id);  

        public List<AirConditioner> GetAll() => _airConditioners;

        public void Update(AirConditioner airConditioner)
        {
            //TODO
        }
    }
}
