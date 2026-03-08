using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries
{
    public class DoorGetAllQuery
    {
        private readonly IDoorRepository _repository;

        public DoorGetAllQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public List<DoorDto> Execute()
        {
            List<DoorDto> doors = new List<DoorDto>();
            foreach (Door door in _repository.GetAll())
                if (door != null)
                    doors.Add(DoorMapper.ToDto(door));
            return doors;
        }
    }
}
