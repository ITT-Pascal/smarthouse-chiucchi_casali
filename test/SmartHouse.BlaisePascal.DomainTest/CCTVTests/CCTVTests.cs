using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.CCTVTests
{
    public class CCTVTests
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
    }
}
