using SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Dto;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Queries
{
public class GetAllThermostatsQuery
    {
        private readonly IThermostatRepository _repository;

        public GetAllThermostatsQuery(IThermostatRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ThermostatDto> Execute()
        {
            var thermostats = _repository.GetAll();
            
            return thermostats.Select(t => new ThermostatDto
            {
                Id = t.Id,
                Name = t.Name._name, 
                Status = t.Status.ToString(),
                Mode = t.Mode.ToString(),
                WorkingTemperature = t.WorkingTemperature._temperature, 
                LastModificationUtc = t.LastModification_UTC
            });
        }
    }
}
