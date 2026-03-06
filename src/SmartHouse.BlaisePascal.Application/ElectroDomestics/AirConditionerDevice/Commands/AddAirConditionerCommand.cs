using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands
{
    public class AddAirConditionerCommand
    {
        private IAirConditionerRepository _repository;

        public AddAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name)
        {

        }
    }
}
