using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class SwitchOnLampCommand
    {
        private readonly ILampRepository _lampRepository;
        public SwitchOnLampCommand(ILampRepository repository)
        {
            _lampRepository = repository;
        }

        public void Execute(Guid LampId)
        {
            Lamp lamp = _lampRepository.GetById(LampId);
            if(lamp != null)
            {
                lamp.SwitchOn();
                _lampRepository.Update(lamp);
            }
        }
    }
}
