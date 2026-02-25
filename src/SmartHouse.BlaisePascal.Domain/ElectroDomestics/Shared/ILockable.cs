namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public interface ILockable
    {
        bool IsLocked { get; }
        void ChangePin(int currentPin, int newPin);
    }
}
