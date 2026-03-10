using SmartHouse.BlaisePascal.Domain.ElectroDomestics.ThermostatDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.ThermostatDevice.Commands
{
    public class SwitchOnThermostatCommand
    {
        private readonly IThermostatRepository _repository;

        public SwitchOnThermostatCommand(IThermostatRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            var thermostat = _repository.GetById(id);
            if (thermostat != null)
            {
                thermostat.SwitchOn();
                _repository.Update(thermostat);
            }
        }
    }
}
