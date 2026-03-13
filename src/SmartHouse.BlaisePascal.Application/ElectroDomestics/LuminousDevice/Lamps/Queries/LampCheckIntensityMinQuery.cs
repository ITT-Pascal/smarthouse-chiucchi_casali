using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Queries
{
    public class LampCheckIntensityMinQuery
    {
        private readonly ILampRepository _repository;

        public LampCheckIntensityMinQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            Lamp l = _repository.GetById(id);
            if (l != null)
                if (l.Intensity == l.MinIntensity)
                    return true;
            return false;
        }
    }
}
