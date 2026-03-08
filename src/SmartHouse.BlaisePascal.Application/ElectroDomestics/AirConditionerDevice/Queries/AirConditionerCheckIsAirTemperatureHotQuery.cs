using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerCheckIsAirTemperatureHotQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckIsAirTemperatureHotQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            AirConditioner ac = _repository.GetById(id);
            if (ac != null)
            {
                if (ac.AirTemperature == ac.HotAirTemperature)
                    return true;
            }
            return false;
        }
    }
}
