using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class AddLampCommand
    {
        private readonly ILampRepository _repository;

        public AddLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name)
        {
            var l = new Lamp(name);
            
            _repository.Add(l);
        }
    }
}