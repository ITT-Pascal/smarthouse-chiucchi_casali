using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVSetFOVCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVSetFOVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int fov)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.SetFOV(fov);
                _repository.Update(c);
            }
        }
    }
}
