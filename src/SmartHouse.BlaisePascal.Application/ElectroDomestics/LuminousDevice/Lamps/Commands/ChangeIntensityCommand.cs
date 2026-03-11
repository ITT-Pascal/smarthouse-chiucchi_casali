using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class ChangeIntensityCommand
    {
        private readonly ILampRepository _repository;

        public ChangeIntensityCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid lampId, int intensity)
        {
            Lamp lamp = _repository.GetById(lampId);
            if (lamp != null)
            { 
                lamp.SetIntensity(intensity);
                _repository.Update(lamp);
            }
        }
    }
}
