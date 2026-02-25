namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
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
