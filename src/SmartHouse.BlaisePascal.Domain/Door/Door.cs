namespace SmartHouse.BlaisePascal.Domain.Door
{
    public class Door
    {
        //Properties
        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public DoorStatus Status { get; private set; }
        public ClosedStatus ClosedDoorStatus { get; private set; }

        public DateTime CreationTime_UTC { get; protected set; }
        public DateTime LastModification_UTC { get; protected set; }

        public Door(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
            ClosedDoorStatus = ClosedStatus.Unlocked;

            CreationTime_UTC = DateTime.UtcNow;
            LastModification_UTC = DateTime.UtcNow;
        }

        public Door(string name, Guid id)
        {
            Name = name;
            Id = id;
            Status = DoorStatus.Closed;
            ClosedDoorStatus = ClosedStatus.Unlocked;

            CreationTime_UTC = DateTime.UtcNow;
            LastModification_UTC = DateTime.UtcNow;
        }

        public void CloseDoor()
        {
            if (Status == DoorStatus.Closed)
                throw new ArgumentException("Cannot close a door that is already closed.", nameof(Status));
            Status = DoorStatus.Closed;

            LastModification_UTC = DateTime.Now;
        }

        public void OpenDoor()
        {
            if (Status == DoorStatus.Open)
                throw new ArgumentException("Cannot open a door that is already open.", nameof(Status));
            if (ClosedDoorStatus == ClosedStatus.Locked)
                throw new ArgumentException("Cannot open a door that is locked.", nameof(ClosedDoorStatus));
            Status = DoorStatus.Open;

            LastModification_UTC = DateTime.Now;
        }

        public void LockDoor()
        {
            if (Status == DoorStatus.Open)
                throw new ArgumentException("Cannot lock and open door.", nameof(Status));
            if(ClosedDoorStatus == ClosedStatus.Locked)
                throw new ArgumentException("Cannot lock a door that is already locked.", nameof(ClosedDoorStatus));
            ClosedDoorStatus = ClosedStatus.Locked;
        }

        public void UnlockDoor()
        {
            if (Status == DoorStatus.Open)
                throw new ArgumentException("Cannot lock and open door.", nameof(Status));
            if (ClosedDoorStatus == ClosedStatus.Unlocked)
                throw new ArgumentException("Cannot unlock a door that is already unlocked.", nameof(ClosedDoorStatus));
            ClosedDoorStatus = ClosedStatus.Unlocked;
        }
    }
}
