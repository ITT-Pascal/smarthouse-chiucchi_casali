using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class CCTVIncreaseFOVCommand
    {
        private readonly ICCTVRepository _repository;

        public CCTVIncreaseFOVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if (c != null)
            {
                c.IncreaseFOV();
                _repository.Update(c);
            }
        }
    }
}
