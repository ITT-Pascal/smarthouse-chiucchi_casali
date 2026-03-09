using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.DoorDevice.InMemory
{
    public class InMemoryDoorRepository:IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors = new List<Door>
            {
                new Door("Giovannini", 1234),
                new Door("Elena", 4321),
                new Door("Gradara", 5678)
            };
        }

        public void Add(Door door)
        {
            if (door == null)
                throw new ArgumentException("Can't add a null air conditioner");
            _doors.Add(door);
        }

        public void Remove(Guid id)
        {
            var airConditioner = GetById(id);
            if (airConditioner != null)
                _doors.Remove(airConditioner);
        }

        public Door GetById(Guid id) => _doors.FirstOrDefault(door => door.Id == id);

        public List<Door> GetAll() => _doors;

        public void Update(Door door)
        {
            //TODO
        }
    }
}
