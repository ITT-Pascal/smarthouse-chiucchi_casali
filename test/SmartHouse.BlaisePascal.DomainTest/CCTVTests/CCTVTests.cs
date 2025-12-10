using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void Constructor_WhenCreated_CamerIsOffButModeIsSettedToNormal()
        {
            CCTV camera = new CCTV("n");
            Assert.Equal(DeviceStatus.Off, camera.Status);
            Assert.Equal(CCTVMode.Normal, camera.Mode);
        }

        [Fact]
        public void SwitchOn_WhenOff_ModeIsNotChanged()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            Assert.Equal(CCTVMode.Normal, camera.Mode);
            Assert.Equal(DeviceStatus.On, camera.Status);
        }

        [Fact]
        public void SwitchOff_WhenOn_ModeIsNotChanged()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SwitchOff();
            Assert.Equal(CCTVMode.Normal, camera.Mode);
            Assert.Equal(DeviceStatus.Off, camera.Status);
        }

        [Fact]
        public void When_WantToSetDefaultVisionButItHasAlreadyBeenSet_CannotSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            Assert.Throws<ArgumentException>(() => newCCTV.SwitchToNormalMode());
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndItIsAlreadySetToNightVision_CanSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SwitchOn();
            newCCTV.SwitchToNightVisionMode();
            newCCTV.SwitchToNormalMode();

            Assert.Equal(CCTVMode.Normal, newCCTV.Mode);

        }

        [Fact]
        public void When_WantToSetNightVisionButItHasAlreadyBeenSet_CannotSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SwitchOn();
            newCCTV.SwitchToNightVisionMode();

            Assert.Throws<ArgumentException>(() => newCCTV.SwitchToNightVisionMode());
        }

        [Fact]
        public void When_WantToSetNightVisionAndItIsAlreadySetToDefaultVision_CanSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SwitchOn();
            newCCTV.SwitchToNightVisionMode();

            Assert.Equal(CCTVMode.NightVision, newCCTV.Mode);

        }

        [Fact]
        public void When_WantToSetThermalVisionButItHasAlreadyBeenSet_CannotSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SwitchOn();
            newCCTV.SwitchToInfraredVisionMode();

            Assert.Throws<ArgumentException>(() => newCCTV.SwitchToInfraredVisionMode());
        }

        [Fact]
        public void When_WantToSetThermalVisionAndItIsAlreadySetToDefaultVision_CanSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SwitchOn();
            newCCTV.SwitchToInfraredVisionMode();

            Assert.Equal(CCTVMode.InfraredVision, newCCTV.Mode);

        }
    }
}
//[Fact]
//public void When_TheNameOfCCTVIsEmpty_TheNameIsNotValid()
//{
//    Assert.Throws<ArgumentException>(() => new CCTV(string.Empty));
//}