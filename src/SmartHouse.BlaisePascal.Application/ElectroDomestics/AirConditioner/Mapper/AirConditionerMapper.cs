using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditioner.Dto;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditioner.Mapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner airConditioner)
        {
            return new AirConditionerDto
            {
                Id= airConditioner.Id,
                Name = airConditioner.Name,
                Status = airConditioner.Status,
                CreationTime_UTC = airConditioner.CreationTime_UTC,
                LastModification_UTC = airConditioner.LastModification_UTC,
            }
        }
    }
}
