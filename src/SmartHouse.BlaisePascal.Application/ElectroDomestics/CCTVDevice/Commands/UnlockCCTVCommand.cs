using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class UnlockCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public UnlockCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int pin)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.Unlock(pin);
                _repository.Update(c);
            }
        }
    }
}
