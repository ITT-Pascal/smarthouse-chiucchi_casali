using SmartHouse.BlaisePascal.Domain.Door;

namespace SmartHouse.BlaisePascal.DomainTest.DoorTests
{
    public class DoorTests
    {
        [Fact]
        public void Constructor_WhenDoorIsCreated_IsClosedAndUnlocked()
        {
            Door newDoor = new Door("n");
            Assert.Equal(ClosedStatus.Unlocked, newDoor.ClosedDoorStatus);
            Assert.Equal(DoorStatus.Closed, newDoor.Status);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosed_StatusSwitchedToOpen()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            Assert.Equal(DoorStatus.Open, newDoor.Status);
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
            newDoor.LockDoor();
            Assert.Throws<ArgumentException>(() => newDoor.OpenDoor());
        }

        [Fact]
        public void CloseDoor_WhenDoorIsOpen_StatusSwitchedToClosed()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            newDoor.CloseDoor();
            Assert.Equal(DoorStatus.Closed, newDoor.Status);
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
            newDoor.LockDoor();
            Assert.Equal(ClosedStatus.Locked, newDoor.ClosedDoorStatus);
        }

        [Fact]
        public void LockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            Assert.Throws<ArgumentException>(() => newDoor.LockDoor());
        }

        [Fact]
        public void LockDoor_WhenDoorIsAlreadyLocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.LockDoor();
            Assert.Throws<ArgumentException>(() => newDoor.LockDoor());
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsClosedAndLocked_UnlocksDoor()
        {
            Door newDoor = new Door("n");
            newDoor.LockDoor();
            newDoor.UnlockDoor();
            Assert.Equal(ClosedStatus.Unlocked, newDoor.ClosedDoorStatus);
        }

        [Fact]
        public void UnockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            newDoor.OpenDoor();
            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor());
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsAlreadyUnlocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n");
            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor());
        }
    }
}
