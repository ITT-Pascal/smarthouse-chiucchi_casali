using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries
{
    public class CCTVGetAllQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVGetAllQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public List<CCTVDto> Execute()
        {
            List<CCTVDto> cs = new List<CCTVDto>();
            foreach (CCTV c in _repository.GetAll())
                if (c != null)
                    cs.Add(CCTVMapper.ToDto(c));
            return cs;
        }
    }
}
