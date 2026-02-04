using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public interface ILuminous: IDevice
    {
        void SetIntensity(int newIntensity);
        void Dimmer(int amount);
        void Brighten(int amount);
    }
}
