using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class DoorSwitchOnCommand
    {
        private readonly IDoorRepository _repository;

        public DoorSwitchOnCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                door.SwitchOn();
                _repository.Update(door);
            }
        }
    }
}
