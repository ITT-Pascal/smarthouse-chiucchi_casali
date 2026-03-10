using SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Dto;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Queries
{
    public class GetThermostatByIdQuery
    {
        private readonly IThermostatRepository _repository;

        public GetThermostatByIdQuery(IThermostatRepository repository)
        {
            _repository = repository;
        }

        public ThermostatDto Execute(Guid id)
        {
            var thermostat = _repository.GetById(id);
            if (thermostat == null) return null;

            return new ThermostatDto
            {
                Id = thermostat.Id,
                Name = thermostat.Name,
                Status = thermostat.Status.ToString(),
                Mode = thermostat.Mode.ToString(),
                WorkingTemperature = thermostat.WorkingTemperature.Celsius,
                LastModificationUtc = thermostat.LastModification_UTC
            };
        }
    }
}
