using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Mapper
{
    public class AirConditionerPowerMapper
    {
        public static string ToDto(AirConditionerPower power)
        {
            return power switch
            {
                AirConditionerPower.Powerful => "POWERFUL",
                AirConditionerPower.Normal => "NORMAL",
                AirConditionerPower.Weak => "WEAK",
                _ => throw new ArgumentException("Invalid power.")
            };
        }

        public static AirConditionerPower ToDomain(string power)
        {
            return power switch
            {
                "POWERFUL" => AirConditionerPower.Powerful,
                "NORMAL" => AirConditionerPower.Normal,
                "WEAK" => AirConditionerPower.Weak,
                _ => throw new ArgumentException("Invalid power.")
            };
        }
    }
}
