using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Mapper
{
    public class AirConditionerModeMapper
    {
        public static string ToDto(AirConditionerMode mode)
        {
            return mode switch
            {
                AirConditionerMode.Cool => "COOL",
                AirConditionerMode.Dry => "DRY",
                AirConditionerMode.Hot => "HOT",
                _ => throw new ArgumentException("Invalid mode.")
            };
        }

        public static AirConditionerMode ToDomain(string airConditionerMode)
        {
            return airConditionerMode switch
            {
                "COOL" => AirConditionerMode.Cool,
                "DRY" => AirConditionerMode.Dry,
                "HOT" => AirConditionerMode.Hot,
                _ => throw new ArgumentException("Invalid mode.")
            };
        }
    }
}
