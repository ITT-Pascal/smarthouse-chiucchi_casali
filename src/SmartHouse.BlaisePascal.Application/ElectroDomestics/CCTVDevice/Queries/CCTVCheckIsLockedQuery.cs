using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries
{
    public class CCTVCheckIsLockedQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckIsLockedQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
                if (c.LockStatus == LockStatus.Locked)
                    return true;
            return false;
        }
    }
}
