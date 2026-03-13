using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class DimmerLampCommand
    {
        private readonly ILampRepository _repository;

        public DimmerLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int amount)
        {
            Lamp lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.Dimmer(amount);
                _repository.Update(lamp);
            }
        }
    }
}
