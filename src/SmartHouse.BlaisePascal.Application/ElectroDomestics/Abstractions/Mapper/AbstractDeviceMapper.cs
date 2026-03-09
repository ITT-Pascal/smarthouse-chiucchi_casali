using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.Abstractions.Mapper
{
    public class AbstractDeviceMapper
    {
        public static object ToObject(AbstractDevice abstractDevice)
        {
            return abstractDevice;
        }

        public static AbstractDevice ToAbstractDevice(object newObject)
        {
            return (AbstractDevice)newObject;
        }
    }
}
