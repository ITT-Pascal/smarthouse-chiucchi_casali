using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditioner.Commands
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
