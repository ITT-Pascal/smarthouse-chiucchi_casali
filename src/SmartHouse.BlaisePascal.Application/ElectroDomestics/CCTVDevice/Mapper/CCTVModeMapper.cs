using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Mapper
{
    public class CCTVModeMapper
    {
        public static string ToDto(CCTVMode mode)
        {
            return mode switch
            {
                CCTVMode.Normal => "NORMAL",
                CCTVMode.NightVision => "NIGHTVISION",
                CCTVMode.InfraredVision => "INFRAREDVISION",
                _ => throw new ArgumentException("Invalid CCTV mode.")
            };
        }

        public static CCTVMode ToDomain(string mode)
        {
            return mode switch
            {
                "NORMAL" => CCTVMode.Normal,
                "NIGHTVISION" => CCTVMode.NightVision,
                "INFRAREDVISION" => CCTVMode.InfraredVision,
                _ => throw new ArgumentException("Invalid CCTV mode.")
            };
        }
    }
}
