using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSwitchOffCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSwitchOffCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, AirConditionerPower power)
        {
            var airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SwitchOff();
                _repository.Update(airConditioner);
            }
        }
    }
}
