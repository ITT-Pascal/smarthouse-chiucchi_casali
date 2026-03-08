using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.DomainTest.DoorTests
{
    public class DoorTests
    {
        [Fact]
        public void Constructor_WhenDoorIsCreated_IsClosedAndUnlocked()
        {
            Door newDoor = new Door("n", 1234);
            Assert.Equal(LockStatus.Unlocked, newDoor.LockStatus);
            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosed_StatusSwitchedToOpen()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.Open();
            Assert.Equal(DoorStatus.Open, newDoor.DoorStatus);
        }

        [Fact]
        public void OpenDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.Open();
            Assert.Throws<ArgumentException>(() => newDoor.Open());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsLocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            Assert.Throws<ArgumentException>(() => newDoor.Open());
        }

        [Fact]
        public void CloseDoor_WhenDoorIsOpen_StatusSwitchedToClosed()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.Open();
            newDoor.Close();
            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
        }

        [Fact]
        public void CloseDoor_WhenDoorIsClosed_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            Assert.Throws<ArgumentException>(() => newDoor.Close());
        }

        [Fact]
        public void LockDoor_WhenDoorIsClosedAndUnlocked_LocksDoor()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            Assert.Equal(LockStatus.Locked, newDoor.LockStatus);
        }

        [Fact]
        public void LockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Open();
            Assert.Throws<ArgumentException>(() => newDoor.Lock(1234));
        }

        [Fact]
        public void LockDoor_WhenDoorIsOff_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            Assert.Throws<ArgumentException>(() => newDoor.Lock(1234));
        }

        [Fact]
        public void LockDoor_WhenDoorIsAlreadyLocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            Assert.Throws<ArgumentException>(() => newDoor.Lock(1234));
        }

        [Fact]
        public void LockDoor_WhenEntryIdIsNotEqual_ThrowArgumentExceptionAndThePoliceIsCalled()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            Assert.Throws<ArgumentException>(() => newDoor.Lock(7777));
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsClosedAndLocked_UnlocksDoor()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            newDoor.Unlock(1234);
            Assert.Equal(LockStatus.Unlocked, newDoor.LockStatus);
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsOff_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            Assert.Throws<ArgumentException>(() => newDoor.Unlock(1234));
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsOpen_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Open();
            Assert.Throws<ArgumentException>(() => newDoor.Unlock(1234));
        }

        [Fact]
        public void UnlockDoor_WhenDoorIsAlreadyUnlocked_ThrowArgumentException()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            newDoor.Unlock(1234);
            Assert.Throws<ArgumentException>(() => newDoor.Unlock(1234));
        }

        [Fact]
        public void UnlockDoor_WhenEntryIdIsNotEqual_ThrowArgumentExceptionAndThePoliceIsCalled()
        {
            Door newDoor = new Door("n", 1234);
            newDoor.SwitchOn();
            newDoor.Lock(1234);
            Assert.Throws<ArgumentException>(() => newDoor.Unlock(7777));
        }
    }
}
