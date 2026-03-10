using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerCheckIsCoolModeQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckIsCoolModeQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            AirConditioner ac = _repository.GetById(id);
            if (ac != null)
            {
                if (ac.Mode == AirConditionerMode.Cool)
                    return true;
            }
            return false;
        }
    }
}
