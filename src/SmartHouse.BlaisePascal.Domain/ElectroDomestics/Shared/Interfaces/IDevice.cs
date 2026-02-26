using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces
{
    public interface IDevice:ISwitchable
    {
        Guid Id { get; }
        Name Name { get; }
        void SetName(string name);
    }
}