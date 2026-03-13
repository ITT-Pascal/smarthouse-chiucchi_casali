using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class BrightenLampCommand
    {
        private readonly ILampRepository _repository;

        public BrightenLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int amount)
        {
            Lamp lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.Brighten(amount);
                _repository.Update(lamp);
            }
        }
    }
}
