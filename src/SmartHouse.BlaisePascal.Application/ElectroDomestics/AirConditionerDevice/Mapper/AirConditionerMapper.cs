using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;
namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Mapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner airConditioner)
        {
            return new AirConditionerDto
            {
                Id = airConditioner.Id,
                Name = airConditioner.Name._name,
                Status = DeviceStatusMapper.ToDto(airConditioner.Status),
                Mode = AirConditionerModeMapper.ToDto(airConditioner.Mode),
                Power = AirConditionerPowerMapper.ToDto(airConditioner.Power),
                AirTemperature = airConditioner.AirTemperature._temperature,
                CreationTime_UTC = airConditioner.CreationTime_UTC,
                LastModification_UTC = airConditioner.LastModification_UTC
            };
        }

        public static AirConditioner ToDomain(AirConditionerDto dto)
        {
            return new AirConditioner
            (
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                AirConditionerModeMapper.ToDomain(dto.Mode),
                AirConditionerPowerMapper.ToDomain(dto.Power),
                dto.AirTemperature,
                dto.CreationTime_UTC,
                dto.LastModification_UTC
            );
        }
    }
}
