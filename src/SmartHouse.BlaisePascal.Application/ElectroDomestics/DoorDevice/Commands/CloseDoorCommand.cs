using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands
{
    public class CloseDoorCommand
    {
        private readonly IDoorRepository _repository;

        public CloseDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if(door != null)
            {
                door.Close();
                _repository.Update(door);
            }
        }
    }
}
