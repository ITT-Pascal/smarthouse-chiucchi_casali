using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared
{
    public class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.Standby => "STANDBY",
                DeviceStatus.Unknown => "UNKNOWN",
                DeviceStatus.Error => "ERROR",
                _ => throw new ArgumentException("Invalid status.")
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "STANDBY" => DeviceStatus.Standby,
                "UNKNOWN" => DeviceStatus.Unknown,
                "ERROR" => DeviceStatus.Error,
                _ => throw new ArgumentException("Invalid status.")
            };
        }
    }
}
