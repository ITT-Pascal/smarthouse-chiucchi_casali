using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AirConditionerSetPowerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSetPowerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, AirConditionerPower power)
        {
            AirConditioner airConditioner = _repository.GetById(id);
            if (airConditioner != null)
            {
                airConditioner.SetPower(power);
                _repository.Update(airConditioner);
            }
        }
    }
}
