using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerCheckIsOnQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckIsOnQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            AirConditioner ac = _repository.GetById(id);
            if (ac != null)
                if (ac.Status == DeviceStatus.On)
                    return true;
            return false;
        }
    }
}
