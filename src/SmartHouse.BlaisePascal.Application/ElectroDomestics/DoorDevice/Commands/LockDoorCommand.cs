using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class LockDoorCommand
    {
        private readonly IDoorRepository _repository;

        public LockDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int pin)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                door.Lock(pin);
                _repository.Update(door);
            }
        }
    }
}
