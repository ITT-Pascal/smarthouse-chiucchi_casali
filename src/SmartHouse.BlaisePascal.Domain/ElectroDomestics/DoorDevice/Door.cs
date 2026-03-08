using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice
{
    public sealed class Door : AbstractDevice, ILockable
    {
        public Pin Pin { get; private set; }
        public DoorStatus DoorStatus { get; private set; }
        public LockStatus LockStatus { get; private set; }

        public Door(string name, int pin) : base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Pin = Pin.Create(pin);
        }

        public Door(Guid id, string name, DeviceStatus status, int pin, DoorStatus doorStatus, LockStatus lockStatus, DateTime creationTime, DateTime lastModification):base(name)
        {
            Id = id;
            Status = status;
            Pin = Pin.Create(pin);
            DoorStatus = doorStatus;
            LockStatus = lockStatus;
            CreationTime_UTC = creationTime;
            LastModification_UTC = lastModification;
        }

        public void Close()
        {
            CheckDoorStatus(DoorStatus.Closed);
            DoorStatus = DoorStatus.Closed;

            LastModification_UTC = DateTime.Now;
        }

        public void Open()
        {
            CheckDoorStatus(DoorStatus.Open);
            CheckLockStatus(LockStatus.Locked);
            DoorStatus = DoorStatus.Open;

            LastModification_UTC = DateTime.Now;
        }

        public void Lock(int pin)
        {
            CheckIsOff();
            CheckDoorStatus(DoorStatus.Open);
            CheckLockStatus(LockStatus.Locked);
            CheckPin(pin);
            LockStatus = LockStatus.Locked;

            LastModification_UTC = DateTime.Now;
        }

        public void Unlock(int pin)
        {
            CheckIsOff();
            CheckDoorStatus(DoorStatus.Open);
            CheckLockStatus(LockStatus.Unlocked);
            CheckPin(pin);
            LockStatus = LockStatus.Unlocked;

            LastModification_UTC = DateTime.Now;
        }

        public void ChangePin(int currentPin, int newPin)
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckPin(currentPin);
            if (Pin == newPin)
                throw new ArgumentException("The new pin is equal to the current one.", nameof(Pin));

            Pin = Pin.Create(newPin);

            LastModification_UTC = DateTime.UtcNow;
        }

        private void CheckDoorStatus(DoorStatus status)
        {
            if (this.DoorStatus == status)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(DoorStatus));
        }

        public void CheckLockStatus(LockStatus status)
        {
            if (this.LockStatus == status)
                throw new ArgumentException("CCTV is locked.", nameof(LockStatus));
        }

        public void CheckPin(int pin)
        {
            if (this.Pin != pin)
                throw new ArgumentException("Wrong pin, police has been advised.", nameof(Pin));
        }
    }
}
