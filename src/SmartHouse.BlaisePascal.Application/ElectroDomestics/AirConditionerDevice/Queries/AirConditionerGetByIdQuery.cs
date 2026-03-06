using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries
{
    public class AirConditionerGetByIdQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerGetByIdQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public AirConditionerDto Execute(Guid id)
        {
            return AirConditionerMapper.ToDto(_repository.GetById(id));
        }
    }
}
