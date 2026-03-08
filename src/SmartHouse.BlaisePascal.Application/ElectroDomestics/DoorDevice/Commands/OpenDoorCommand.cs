using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _repository;

        public OpenDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                door.Open();
                _repository.Update(door);
            }
        }
    }
}
