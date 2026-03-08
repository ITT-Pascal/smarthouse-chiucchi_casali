using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVSwitchToNightVisionModeCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVSwitchToNightVisionModeCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.SwitchToNightVisionMode();
                _repository.Update(c);
            }
        }
    }
}
