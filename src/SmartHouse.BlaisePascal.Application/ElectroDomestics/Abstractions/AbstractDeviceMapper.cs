using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.Abstractions
{
    public class AbstractDeviceMapper
    {
        public static Object ToObject(AbstractDevice abstractDevice)
        {
            return (Object)abstractDevice;
        }

        public static AbstractDevice ToAbstractDevice(Object newObject)
        {
            return (AbstractDevice)newObject;
        }
    }
}
