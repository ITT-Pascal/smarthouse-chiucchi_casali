using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces
{
    public interface ILockable
    {
        Pin Pin { get; }
        LockStatus LockStatus { get; }
        void ChangePin(int currentPin, int newPin);
        void Lock(Pin pin);
        void Unlock(Pin pin);
        void CheckLocked();
        void CheckUnlocked();
    }
}
