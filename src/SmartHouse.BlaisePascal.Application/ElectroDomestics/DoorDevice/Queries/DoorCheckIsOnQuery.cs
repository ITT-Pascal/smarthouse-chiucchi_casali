using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries
{
    public class DoorCheckIsOnQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsOnQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            Door door = _repository.GetById(id);
            if (door != null)
            {
                if (door.Status == DeviceStatus.On)
                    return true;
            }
            return false;
        }
    }
}
