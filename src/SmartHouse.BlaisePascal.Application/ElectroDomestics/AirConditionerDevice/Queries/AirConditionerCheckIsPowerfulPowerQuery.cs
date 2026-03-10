using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerCheckIsPowerfulPowerQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckIsPowerfulPowerQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            AirConditioner ac = _repository.GetById(id);
            if (ac != null)
            {
                if (ac.Power == AirConditionerPower.Powerful)
                    return true;
            }
            return false;
        }
    }
}
