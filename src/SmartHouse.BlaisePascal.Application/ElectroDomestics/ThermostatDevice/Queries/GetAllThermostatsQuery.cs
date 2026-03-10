using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Name = t.Name.Value, 
                Status = t.Status.ToString(),
                Mode = t.Mode.ToString(),
                WorkingTemperature = t.WorkingTemperature.Celsius, 
                LastModificationUtc = t.LastModification_UTC
            });
        }
    }
}
