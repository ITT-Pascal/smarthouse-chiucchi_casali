using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class SwitchOffLampCommand
    {
        private readonly ILampRepository _lampRepository;
        public SwitchOffLampCommand(ILampRepository repository)
        {
            _lampRepository = repository;
        }

        public void Execute(Guid LampId)
        {
            Lamp lamp = _lampRepository.GetById(LampId);
            if (lamp != null)
            {
                lamp.SwitchOff();
                _lampRepository.Update(lamp);
            }
        }
    }
}
