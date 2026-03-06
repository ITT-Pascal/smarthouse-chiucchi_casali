using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerGetAllQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerGetAllQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public List<AirConditionerDto> Execute()
        {
            List<AirConditionerDto> acs = new List<AirConditionerDto>();
            foreach (AirConditioner ac in _repository.GetAll())
                if (ac != null)
                    acs.Add(AirConditionerMapper.ToDto(ac));
            return acs;
        }
    }
}
