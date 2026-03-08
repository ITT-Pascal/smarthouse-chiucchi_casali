using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries
{
    public class DoorGetByIdQuery
    {
        private readonly IDoorRepository _repository;

        public DoorGetByIdQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public DoorDto Execute(Guid id)
        {
            return DoorMapper.ToDto(_repository.GetById(id));
        }
    }
}
