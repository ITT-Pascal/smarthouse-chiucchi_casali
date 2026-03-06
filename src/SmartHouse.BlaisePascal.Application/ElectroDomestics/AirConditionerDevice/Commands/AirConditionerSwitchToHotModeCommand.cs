using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSwitchToHotModeCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSwitchToHotModeCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SwitchToHotMode();
                _repository.Update(airConditioner);
            }
        }
    }
}
