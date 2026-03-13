using SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Mappers;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Queries
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _repository;

        public GetAllLampsQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public List<LampDto> Execute()
        {
            List<LampDto> lamps = new List<LampDto>();
            foreach (Lamp lamp in _repository.GetAll())
                if (lamp != null)
                    lamps.Add(LampMapper.ToDto(lamp));
            return lamps;
        }
    }
}
