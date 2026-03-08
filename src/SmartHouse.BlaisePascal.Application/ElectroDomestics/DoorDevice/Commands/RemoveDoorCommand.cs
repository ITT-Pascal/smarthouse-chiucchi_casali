using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class RemoveDoorCommand
    {
        private readonly IDoorRepository _repository;

        public RemoveDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if(door != null)
            {
                _repository.Remove(id);
                _repository.Update(door);
            }
        }
    }
}
