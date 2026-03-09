using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.Lighting.Lamps.InMemory
{
    public class InMemoryLampRepository:ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp("Gianluca"),
                new Lamp("Mariani"),
                new Lamp("Ascanio")
            };
        }

        public void Add(Lamp lamp)
        {
            if (lamp == null)
                throw new ArgumentException("Cannot add a null lamp.");
            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);
            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public Lamp GetById(Guid id) => _lamps.FirstOrDefault(lamp => lamp.Id == id);

        public List<Lamp> GetAll() => _lamps;

        public void Update(Lamp lamp)
        {
            //TODO
        }
    }
}
