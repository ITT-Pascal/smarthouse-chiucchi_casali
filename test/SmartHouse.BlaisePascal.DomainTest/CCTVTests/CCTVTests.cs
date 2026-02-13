using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void Constructor_WhenCreated_CameraIsOffButModeIsSetToNormal()
        {
            CCTV camera = new CCTV("n");
            Assert.Equal(DeviceStatus.Off, camera.Status);
            Assert.Equal(CCTVMode.Normal, camera.Mode);
        }

        [Fact]
        public void SetFOVToStandard_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetFOVToStandard());
        }

        [Fact]
        public void SetFOVToFocus_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetFOVToFocus());
        }

        [Fact]
        public void SetFOVToWideAngle_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetFOVToWideAngle());
        }

        [Fact]
        public void SetFOV_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetFOV(FOV.Create(40)));
        }

        [Fact]
        public void IncreaseFOV_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.IncreaseFOV());
        }

        [Fact]
        public void DecreaseFOV_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.DecreaseFOV());
        }

        [Fact]
        public void SwitchToInfraredVisionMode_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SwitchToInfraredVisionMode());
        }

        [Fact]
        public void SwitchToNightVisionMode_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SwitchToNightVisionMode());
        }

        [Fact]
        public void SwitchToNormalMode_WhenCCTVIsAlreadyOnThatMode_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            Assert.Throws<ArgumentException>(() => camera.SwitchToNormalMode());
        }

        [Fact]
        public void SetMode_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetMode(CCTVMode.NightVision));
        }

        [Fact]
        public void SetNightVisionWhenNight_WhenCCTVIsOff_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            Assert.Throws<ArgumentException>(() => camera.SetNightVisionWhenNight());
        }

        [Fact]
        public void SetFOVToStandard_WhenFOVIsAlreadyOnThatFOV_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            Assert.Throws<ArgumentException>(() => camera.SetFOVToStandard());
        }

        [Fact]
        public void SetFOVToFocus_WhenFOVIsAlreadyOnThatFOV_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetFOVToFocus();
            Assert.Throws<ArgumentException>(() => camera.SetFOVToFocus());
        }

        [Fact]
        public void SetFOVToWideAngle_WhenFOVIsAlreadyOnThatFOV_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetFOVToWideAngle();
            Assert.Throws<ArgumentException>(() => camera.SetFOVToWideAngle());
        }

        [Fact]
        public void SetFOV_WhenFOVIsAlreadyOnThatFOV_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetFOVToWideAngle();
            Assert.Throws<ArgumentException>(() => camera.SetFOV(FOV.Create(120)));
        }

        [Fact]
        public void IncreaseFOV_NormalIncrease_IncreasesFOV()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.IncreaseFOV();
            Assert.Equal(61, camera.FOV._fov);
        }

        [Fact]
        public void DecreaseFOV_NormalIncrease_IncreasesFOV()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.DecreaseFOV();
            Assert.Equal(59, camera.FOV._fov);
        }

        //[Fact]
        //public void SetFOV_WhenNewFOVIsOutOfRange_ThrowArgumentException()
        //{
        //    CCTV camera = new CCTV("n");
        //    camera.SwitchOn();
        //    Assert.Throws<ArgumentException>(() => camera.SetFOV(FOV.Create(121)));
        //}

        [Fact]
        public void SetFOVToStandard_NormalSwitch_SetsFOVToStandard()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetFOVToFocus();
            camera.SetFOVToStandard();
            Assert.Equal(60, camera.FOV._fov);
        }

        [Fact]
        public void SetFOV_NormalSwitch_SetsFOVToStandard()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetFOV(FOV.Create(80));
            Assert.Equal(80, camera.FOV._fov);
        }

        [Fact]
        public void SetMode_WhenNewModeIsAlreadyOnThatMode_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            Assert.Throws<ArgumentException>(() => camera.SetMode(CCTVMode.Normal));
        }

        [Fact]
        public void SetMode_NormalSet_SetsModeWithNewMode()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetMode(CCTVMode.NightVision);
            Assert.Equal(CCTVMode.NightVision, camera.Mode);
        }

        [Fact]
        public void SetNightVisionWhenNight_WhenModeIsAlreadyAtNightVision_ThrowArgumentException()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SwitchToNightVisionMode();
            Assert.Throws<ArgumentException>(() => camera.SetNightVisionWhenNight());
        }

        [Fact]
        public void SetNightVisionWhenNight_NormalSet()
        {
            CCTV camera = new CCTV("n");
            camera.SwitchOn();
            camera.SetNightVisionWhenNight();
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6)
                Assert.Equal(CCTVMode.NightVision, camera.Mode);
            else
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
            CCTV camera = new CCTV("Salvatore");

            Assert.Throws<ArgumentException>(() => camera.SwitchToNormalMode());
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndItIsAlreadySetToNightVision_CanSetDefaultVision()
        {
            CCTV camera = new CCTV("Salvatore");

            camera.SwitchOn();
            camera.SwitchToNightVisionMode();
            camera.SwitchToNormalMode();

            Assert.Equal(CCTVMode.Normal, camera.Mode);

        }

        [Fact]
        public void When_WantToSetNightVisionButItHasAlreadyBeenSet_CannotSetNightVision()
        {
            CCTV camera = new CCTV("Salvatore");

            camera.SwitchOn();
            camera.SwitchToNightVisionMode();

            Assert.Throws<ArgumentException>(() => camera.SwitchToNightVisionMode());
        }

        [Fact]
        public void When_WantToSetNightVisionAndItIsAlreadySetToDefaultVision_CanSetNightVision()
        {
            CCTV camera = new CCTV("Salvatore");

            camera.SwitchOn();
            camera.SwitchToNightVisionMode();

            Assert.Equal(CCTVMode.NightVision, camera.Mode);

        }

        [Fact]
        public void When_WantToSetThermalVisionButItHasAlreadyBeenSet_CannotSetThermalVision()
        {
            CCTV camera = new CCTV("Salvatore");

            camera.SwitchOn();
            camera.SwitchToInfraredVisionMode();

            Assert.Throws<ArgumentException>(() => camera.SwitchToInfraredVisionMode());
        }

        [Fact]
        public void When_WantToSetThermalVisionAndItIsAlreadySetToDefaultVision_CanSetThermalVision()
        {
            CCTV camera = new CCTV("Salvatore");

            camera.SwitchOn();
            camera.SwitchToInfraredVisionMode();

            Assert.Equal(CCTVMode.InfraredVision, camera.Mode);

        }
    }
}
//[Fact]
//public void When_TheNameOfCCTVIsEmpty_TheNameIsNotValid()
//{
//    Assert.Throws<ArgumentException>(() => new CCTV(string.Empty));
//}