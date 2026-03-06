using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class RemoveAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public RemoveAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airConditioner = _repository.GetById(id);
            if(airConditioner != null)
            {
                _repository.Remove(id);
                _repository.Update(airConditioner);
            }
        }
    }
}
