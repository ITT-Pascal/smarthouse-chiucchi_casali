using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries
{
    public class DoorCheckIsLockedQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsLockedQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                if (door.LockStatus == LockStatus.Locked)
                    return true;
            }
            return false;
        }
    }
}
