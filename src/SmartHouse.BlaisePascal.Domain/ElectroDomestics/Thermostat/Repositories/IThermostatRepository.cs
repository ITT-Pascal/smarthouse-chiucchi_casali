namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat.Repositories
{
    public interface IThermostatRepository
    {
        void Add(Thermostat thermostat);
        void Update(Thermostat thermostat);
        void Remove(Guid id);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
