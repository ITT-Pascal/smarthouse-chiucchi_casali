using SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Mappers
{
    public class LampMapper
    {


        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name._name,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                Intensity = lamp.Intensity._intensity,
                CreatedAtUtc = lamp.CreationTime_UTC,
                LastModifiedAtUtc = lamp.LastModification_UTC,
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.Intensity,
                dto.CreatedAtUtc,
                dto.LastModifiedAtUtc
                );
        }
    }
}
