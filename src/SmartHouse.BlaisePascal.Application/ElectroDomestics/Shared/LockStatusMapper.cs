using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared
{
    public class LockStatusMapper
    {
        public static string ToDto(LockStatus lockStatus)
        {
            return lockStatus switch
            {
                LockStatus.Unlocked => "UNLOCKED",
                LockStatus.Locked => "LOCKED",
                _ => throw new ArgumentException("Invalid lock status.")
            };
        }

        public static LockStatus ToDomain(string lockStatus)
        {
            return lockStatus switch
            {
                "UNLOCKED" => LockStatus.Unlocked,
                "LOCKED" => LockStatus.Locked,
                _ => throw new ArgumentException("Invalid lock status.")
            };
        }
    }
}
