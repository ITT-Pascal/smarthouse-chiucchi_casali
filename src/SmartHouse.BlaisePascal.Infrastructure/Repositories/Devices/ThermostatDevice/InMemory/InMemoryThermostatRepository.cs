using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.ThermostatDevice.InMemory
{
    public class InMemoryThermostatRepository:IThermostatRepository
    {
        private readonly List<Thermostat> _thermostats;

        public InMemoryThermostatRepository()
        {
            _thermostats = new List<Thermostat>
            {
                new Thermostat("Assennato"),
                new Thermostat("Piraccini"),
                new Thermostat("Zanarini")
            };
        }

        public void Add(Thermostat thermostat)
        {
            if (thermostat == null)
                throw new ArgumentException("Cannot add a null thermostat.");
            _thermostats.Add(thermostat);
        }

        public void Remove(Guid id)
        {
            var thermostat = GetById(id);
            if (thermostat != null)
                _thermostats.Remove(thermostat);
        }

        public Thermostat GetById(Guid id) => _thermostats.FirstOrDefault(thermostat => thermostat.Id == id);

        public List<Thermostat> GetAll() => _thermostats;

        public void Update(Thermostat thermostat)
        {
            //TODO
        }
    }
}
