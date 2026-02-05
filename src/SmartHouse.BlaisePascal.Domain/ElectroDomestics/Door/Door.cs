using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Door
{
    public sealed class Door: AbstractDevice
    {
        public DoorStatus DoorStatus { get; private set; } //Fare a Pulga la stessa domanda fatta in Thermostat
        public ClosedStatus ClosedDoorStatus { get; private set; }
        public Guid EntryId { get; private set; } //Guid id that works as passkey to lock or unlock door

        public Door(string name) : base(name) { DoorStatus = DoorStatus.Closed; ClosedDoorStatus = ClosedStatus.Unlocked; EntryId = Guid.NewGuid(); }

        public void CloseDoor()
        {
            if (DoorStatus == DoorStatus.Closed)
                throw new ArgumentException("Cannot close a door that is already closed.", nameof(DoorStatus));
            DoorStatus = DoorStatus.Closed;

            LastModification_UTC = DateTime.Now;
        }

        public void OpenDoor()
        {
            if (DoorStatus == DoorStatus.Open)
                throw new ArgumentException("Cannot open a door that is already open.", nameof(DoorStatus));
            if (ClosedDoorStatus == ClosedStatus.Locked)
                throw new ArgumentException("Cannot open a door that is locked.", nameof(ClosedDoorStatus));
            DoorStatus = DoorStatus.Open;

            LastModification_UTC = DateTime.Now;
        }

        public void LockDoor(Guid entryId)
        {
            CheckIsOff();
            if (DoorStatus == DoorStatus.Open)
                throw new ArgumentException("Cannot lock an open door.", nameof(DoorStatus));
            if(ClosedDoorStatus == ClosedStatus.Locked)
                throw new ArgumentException("Cannot lock a door that is already locked.", nameof(ClosedDoorStatus));
            if (entryId != EntryId)
                throw new Exception("Access denied. Police has been alerted.");
            ClosedDoorStatus = ClosedStatus.Locked;

            LastModification_UTC = DateTime.Now;
        }

        public void UnlockDoor(Guid entryId)
        {
            CheckIsOff();
            if (DoorStatus == DoorStatus.Open)
                throw new ArgumentException("Cannot lock and open door.", nameof(DoorStatus));
            if (ClosedDoorStatus == ClosedStatus.Unlocked)
                throw new ArgumentException("Cannot unlock a door that is already unlocked.", nameof(ClosedDoorStatus));
            if (entryId != EntryId)
                throw new Exception("Access denied. Police has been alerted.");
            ClosedDoorStatus = ClosedStatus.Unlocked;

            LastModification_UTC = DateTime.Now;
        }
    }
}
