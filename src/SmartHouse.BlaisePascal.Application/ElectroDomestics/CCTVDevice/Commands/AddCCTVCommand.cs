using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public AddCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name, int pin)
        {
            _repository.Add(new CCTV(name, pin));
        }
    }
}
