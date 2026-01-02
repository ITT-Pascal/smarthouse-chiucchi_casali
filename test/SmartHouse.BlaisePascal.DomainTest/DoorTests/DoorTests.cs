using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Door;

namespace SmartHouse.BlaisePascal.DomainTest.DoorTests
{
    public class DoorTests
    {
        [Fact]
        public void Constructor_WhenDoorIsCreated_IsClosedAndUnlocked()
        {
            Door newDoor = new Door("n");
            Assert.Equal(ClosedStatus.Unlocked, newDoor.ClosedDoorStatus);
            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosed_StatusSwitchedToOpen()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            Assert.Equal(DoorStatus.Open, newDoor.DoorStatus);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            Assert.Throws<ArgumentException>(() => newDoor.OpenDoor());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsLocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            Assert.Throws<ArgumentException>(() => newDoor.OpenDoor());
        }

        [Fact]
        public void CloseDoor_WhenDoorIsOpen_StatusSwitchedToClosed()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            newDoor.CloseDoor();
            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
        }

        [Fact]
        public void CloseDoor_WhenDoorIsClosed_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            Assert.Throws<ArgumentException>(() => newDoor.CloseDoor());
        }

        [Fact]
        public void LockDoor_WhenDoorIsClosedAndUnlocked_LocksDoor()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            Assert.Equal(ClosedStatus.Locked, newDoor.ClosedDoorStatus);
        }

        [Fact]
        public void LockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.OpenDoor();
            Assert.Throws<ArgumentException>(() => newDoor.LockDoor(newDoor.EntryId));
        }

        [Fact]
        public void LockDoor_WhenDoorIsOff_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            Assert.Throws<ArgumentException>(() => newDoor.LockDoor(newDoor.EntryId));
        }

        [Fact]
        public void LockDoor_WhenDoorIsAlreadyLocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            Assert.Throws<ArgumentException>(() => newDoor.LockDoor(newDoor.EntryId));
        }

        [Fact]
        public void LockDoor_WhenEntryIdIsNotEqual_ThrowArgumentExceptionAndThePoliceIsCalled()
        {
            Door newDoor = new Door("n");
            Guid notId = Guid.NewGuid();
            newDoor.SwitchOn();
            Assert.Throws<Exception>(() => newDoor.LockDoor(notId));
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsClosedAndLocked_UnlocksDoor()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            newDoor.UnlockDoor(newDoor.EntryId);
            Assert.Equal(ClosedStatus.Unlocked, newDoor.ClosedDoorStatus);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsOff_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor(newDoor.EntryId));
        }



        [Fact]
        public void UnlockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.OpenDoor();
            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor(newDoor.EntryId));
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsAlreadyUnlocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            newDoor.UnlockDoor(newDoor.EntryId);
            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor(newDoor.EntryId));
        }

        [Fact]
        public void UnlockDoor_WhenEntryIdIsNotEqual_ThrowArgumentExceptionAndThePoliceIsCalled()
        {
            Door newDoor = new Door("n");
            Guid notId = Guid.NewGuid();
            newDoor.SwitchOn();
            newDoor.LockDoor(newDoor.EntryId);
            Assert.Throws<Exception>(() => newDoor.UnlockDoor(notId));
        }
    }
}
