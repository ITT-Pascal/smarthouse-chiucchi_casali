using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces
{
    public interface ISwitchable
    {
        DeviceStatus Status { get; }
        void Toggle();
        void SwitchOff();
        void SwitchOn();
        void CheckIsOff();
        void CheckIsOn();
    }
}
