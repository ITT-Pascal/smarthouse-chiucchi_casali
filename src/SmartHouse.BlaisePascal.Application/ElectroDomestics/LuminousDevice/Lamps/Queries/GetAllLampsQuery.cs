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

        public IEnumerable<Lamp> Execute()
        {

            return _repository.GetAll();
        }
    }
}
