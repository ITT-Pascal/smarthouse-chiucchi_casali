using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVSetModeCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVSetModeCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, CCTVMode newMode)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.SetMode(newMode);
                _repository.Update(c);
            }
        }
    }
}
