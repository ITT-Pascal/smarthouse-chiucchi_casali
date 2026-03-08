using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands
{
    public class RemoveCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public RemoveCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            CCTV c = _repository.GetById(id);
            if(c != null)
            {
                _repository.Remove(id);
                _repository.Update(c);
            }
        }
    }
}
