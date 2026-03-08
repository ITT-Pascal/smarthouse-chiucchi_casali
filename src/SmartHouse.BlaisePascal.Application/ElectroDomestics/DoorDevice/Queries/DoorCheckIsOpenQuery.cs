using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries
{
    public class DoorCheckIsOpenQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsOpenQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                if (door.DoorStatus == DoorStatus.Open)
                    return true;
            }
            return false;
        }
    }
}
