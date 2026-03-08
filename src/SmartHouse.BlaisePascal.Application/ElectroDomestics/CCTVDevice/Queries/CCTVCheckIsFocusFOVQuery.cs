using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries
{
    public class CCTVCheckIsFocusFOVQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckIsFocusFOVQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
                if (c.FOV == c.FocusFOV)
                    return true;
            return false;
        }
    }
}
