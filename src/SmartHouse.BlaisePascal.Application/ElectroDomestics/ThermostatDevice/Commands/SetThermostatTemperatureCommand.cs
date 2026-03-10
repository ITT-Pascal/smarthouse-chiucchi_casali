using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Commands
{
    public class SetThermostatTemperatureCommand
    {
        private readonly IThermostatRepository _repository;

        public SetThermostatTemperatureCommand(IThermostatRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int targetTemperature)
        {
            var thermostat = _repository.GetById(id);
            if (thermostat != null)
            {
                thermostat.SetTemperature(targetTemperature);
                _repository.Update(thermostat);
            }
        }
    }
}