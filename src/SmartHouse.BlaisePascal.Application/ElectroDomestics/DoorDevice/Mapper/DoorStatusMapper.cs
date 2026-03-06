using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Mapper
{
    public class DoorStatusMapper
    {
        public static string ToDto(DoorStatus doorStatus)
        {
            return doorStatus switch
            {
                DoorStatus.Closed => "CLOSED",
                DoorStatus.Open => "OPEN",
                _ => throw new ArgumentException("Invalid door status.")
            };
        }

        public static DoorStatus ToDomain(string doorStatus)
        {
            return doorStatus switch
            {
                "CLOSED" => DoorStatus.Closed,
                "OPEN" => DoorStatus.Open,
                _ => throw new ArgumentException("Invalid door status.")
            };
        }
    }
}
