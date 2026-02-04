namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public interface ISwitchable
    {
        void Toggle();
        void SwitchOff();
        void SwitchOn();
        void CheckIsOff();
        void CheckIsOn();
    }
}
