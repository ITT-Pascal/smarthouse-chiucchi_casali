using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Commands
{
    public class DecreaseThermostatTemperatureCommand
    {
        private readonly IThermostatRepository _repository;

        public DecreaseThermostatTemperatureCommand(IThermostatRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            var thermostat = _repository.GetById(id);
            if (thermostat != null)
            {
                thermostat.DecreaseTemperature();
                _repository.Update(thermostat);
            }
        }
    }
}
