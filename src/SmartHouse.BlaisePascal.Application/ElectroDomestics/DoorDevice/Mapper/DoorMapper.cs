using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Mapper
{
    public class DoorMapper
    {
        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name._name,
                Status = DeviceStatusMapper.ToDto(door.Status),
                Pin = door.Pin._pin,
                DoorStatus = DoorStatusMapper.ToDto(door.DoorStatus),
                LockStatus = LockStatusMapper.ToDto(door.LockStatus),
                CreationTime_UTC = door.CreationTime_UTC,
                LastModification_UTC = door.LastModification_UTC
            };
        }

        public static Door ToDomain(DoorDto door)
        {
            return new Door(
                door.Id,
                door.Name,
                DeviceStatusMapper.ToDomain(door.Status),
                door.Pin,
                DoorStatusMapper.ToDomain(door.DoorStatus),
                LockStatusMapper.ToDomain(door.LockStatus),
                door.CreationTime_UTC,
                door.LastModification_UTC
                );
        }
    }
}
