namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public interface IDevice:ISwitchable
    {
        void SetName(string name);
    }
}
