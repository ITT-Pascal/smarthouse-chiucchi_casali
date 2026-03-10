using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSwitchOnCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSwitchOnCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            var airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SwitchOn();
                _repository.Update(airConditioner);
            }
        }
    }
}
