using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Interfaces
{
    public interface ILuminous: IDevice
    {
        Intensity Intensity { get; }
        void SetIntensity(Intensity newIntensity);
        void Dimmer(int amount);
        void Brighten(int amount);
    }
}
