using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVSwitchToInfraredVisionModeCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVSwitchToInfraredVisionModeCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.SwitchToInfraredVisionMode();
                _repository.Update(c);
            }
        }
    }
}
