using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class LockCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public LockCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int pin)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.Lock(pin);
                _repository.Update(c);
            }
        }
    }
}
