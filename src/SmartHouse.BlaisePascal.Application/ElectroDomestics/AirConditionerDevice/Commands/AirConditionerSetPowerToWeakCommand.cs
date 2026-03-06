using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSetPowerToWeakCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSetPowerToWeakCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SetPowerToWeak();
                _repository.Update(airConditioner);
            }
        }
    }
}
