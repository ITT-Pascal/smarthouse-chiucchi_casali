using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _repository;

        public AddDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name, int pin)
        {
            _repository.Add(new Door(name, pin));
        }
    }
}
