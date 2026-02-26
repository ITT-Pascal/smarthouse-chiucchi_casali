using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public interface ILuminous: IDevice
    {
        void SetIntensity(Intensity newIntensity);
        void Dimmer(int amount);
        void Brighten(int amount);
    }
}
