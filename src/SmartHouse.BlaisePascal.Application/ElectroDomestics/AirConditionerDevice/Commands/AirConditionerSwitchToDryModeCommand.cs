using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSwitchToDryModeCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSwitchToDryModeCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SwitchToDryMode();
                _repository.Update(airConditioner);
            }
        }
    }
}
