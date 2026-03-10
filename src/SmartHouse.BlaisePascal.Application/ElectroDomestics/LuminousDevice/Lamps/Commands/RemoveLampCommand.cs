using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class RemoveLampCommand
    {
        private readonly ILampRepository _repository;

        public RemoveLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
