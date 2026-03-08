using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class DoorChangePinCommand
    {
        private readonly IDoorRepository _repository;

        public DoorChangePinCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int currentPin, int newPin)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                door.ChangePin(currentPin, newPin);
                _repository.Update(door);
            }
        }
    }
}
