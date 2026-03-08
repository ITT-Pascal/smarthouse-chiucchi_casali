using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries
{
    public class CCTVCheckIsStandardFOVQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckIsStandardFOVQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
                if (c.FOV == c.StandardFOV)
                    return true;
            return false;
        }
    }
}
