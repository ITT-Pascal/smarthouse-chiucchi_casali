using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries
{
    public class CCTVGetByIdQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVGetByIdQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public CCTVDto Execute(Guid id)
        {
            return CCTVMapper.ToDto(_repository.GetById(id));
        }
    }
}
