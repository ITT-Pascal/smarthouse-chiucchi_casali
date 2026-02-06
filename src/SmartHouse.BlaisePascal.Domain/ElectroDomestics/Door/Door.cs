using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Door
{
    public sealed class Door: AbstractDevice
    {
        public DoorStatus DoorStatus { get; private set; } //rimuovere EntryId come GuidId e sostituirlo con un PIN
        public ClosedStatus ClosedDoorStatus { get; private set; }
        public Guid EntryId { get; private set; } //Guid id that works as passkey to lock or unlock door

        public Door(string name) : base(name) { DoorStatus = DoorStatus.Closed; ClosedDoorStatus = ClosedStatus.Unlocked; EntryId = Guid.NewGuid(); }

        public void CloseDoor()
        {
            CheckStatus(DoorStatus.Closed);
            DoorStatus = DoorStatus.Closed;

            LastModification_UTC = DateTime.Now;
        }

        public void OpenDoor()
        {
            CheckStatus(DoorStatus.Open);
            CheckClosedStatus(ClosedStatus.Locked);
            DoorStatus = DoorStatus.Open;

            LastModification_UTC = DateTime.Now;
        }

        public void LockDoor(Guid entryId)
        {
            CheckIsOff();
            CheckStatus(DoorStatus.Open);
            CheckClosedStatus(ClosedStatus.Locked);
            if (entryId != EntryId)
                throw new Exception("Access denied. Police has been alerted.");
            ClosedDoorStatus = ClosedStatus.Locked;

            LastModification_UTC = DateTime.Now;
        }

        public void UnlockDoor(Guid entryId)
        {
            CheckIsOff();
            CheckStatus(DoorStatus.Open);
            CheckClosedStatus(ClosedStatus.Unlocked);
            if (entryId != EntryId)
                throw new Exception("Access denied. Police has been alerted.");
            ClosedDoorStatus = ClosedStatus.Unlocked;

            LastModification_UTC = DateTime.Now;
        }

        private void CheckStatus(DoorStatus status)
        {
            if (this.DoorStatus == status)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(DoorStatus));
        }

        private void CheckClosedStatus(ClosedStatus closedStatus)
        {
            if (this.ClosedDoorStatus == closedStatus)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(ClosedDoorStatus));
        }
    }
}
