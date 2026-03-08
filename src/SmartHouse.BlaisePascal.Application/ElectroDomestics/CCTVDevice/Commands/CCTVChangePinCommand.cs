using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVChangePinCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVChangePinCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int currentPin, int newPin)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.ChangePin(currentPin, newPin);
                _repository.Update(c);
            }
        }
    }
}
