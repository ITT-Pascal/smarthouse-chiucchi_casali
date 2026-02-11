using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.LampTests
{
    public class EcoLampTest
    {
        //Constructor Test
        [Fact]
        public void EcoLampIsOn_WhenLampIsCreated_LampStatusMustBeOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //ToggleOnOff Tests
        [Fact]
        public void EcoLampToggleOnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.Toggle();
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
        [Fact]
        public void EcoLampToggleOnOff_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.Toggle();
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //TurnOn Tests
        [Fact]
        public void EcoLampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
        [Fact]
        public void EcoLampTurnOn_WhenLampIsOn_ShouldThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentException>(() => newLamp.SwitchOn());
        }
        //TurnOff Tests
        [Fact]
        public void EcoLampTurnOff_WhenLampIsOff_ShouldThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SwitchOff());
        }
        [Fact]
        public void EcoLampTurnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //ChangeBrightness Tests
        //[Fact]
        //public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeMaxBrightness_ThrowNewArgumentOutOfRangeException()
        //{
        //    EcoLamp newLamp = new EcoLamp("n");
        //    newLamp.SwitchOn();
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(Intensity.Create(71,0,70)));
        //}
        //[Fact]
        //public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeNegative_ThrowNewArgumentOutOfRangeException()
        //{
        //    EcoLamp newLamp = new EcoLamp("n");
        //    newLamp.SwitchOn();
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(Intensity.Create(-1, 0, 70)));
        //}
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SetIntensity(Intensity.Create(30,0,70)));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenNewBrightnessIs0_SetBrightnessAs0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(Intensity.Create(0, 0, 70));
            Assert.Equal(0, newLamp.Intensity._intensity);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOn_SetNewBrightness()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(Intensity.Create(50, 0, 70));
            Assert.Equal(50, newLamp.Intensity._intensity);
        }
        //AdjustBrightness Tests
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeNegative_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustIntensityByAmbientLight(-1));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeMaxBrightness_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustIntensityByAmbientLight(71));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.AdjustIntensityByAmbientLight(30));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs70_SetBrightnessAt0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustIntensityByAmbientLight(70);
            Assert.Equal(0, newLamp.Intensity._intensity);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs60_SetBrightnessAt10()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustIntensityByAmbientLight(60);
            Assert.Equal(10, newLamp.Intensity._intensity);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs0_SetBrightnessAt70()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustIntensityByAmbientLight(0);
            Assert.Equal(70, newLamp.Intensity._intensity);
        }
        //IsNight Tests
        [Fact]
        public void EcoLampIsNight_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.IsNight());
        }
        [Fact]
        public void EcoLampIsNight_WhenIsNight_ReduceBrightnessBy20Percent()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.IsNight();
            if (DateTime.Now.Hour >= 22 || DateTime.Now.Hour <= 6)
                Assert.Equal(24, newLamp.Intensity._intensity);
            else
                Assert.Equal(30, newLamp.Intensity._intensity);
        }
        //UltraEcoMode Tests
        [Fact]
        public void EcoLampUltraEcoMode_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.UltraEcoMode());
        }
        [Fact]
        public void EcoLampUltraEcoMode_WhenEcoLampIsOnAndBrightnessIs70_ReduceBrightnessBy20Percent()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.UltraEcoMode();
            Assert.Equal(24, newLamp.Intensity._intensity);
        }

        [Fact]
        public void Dimmer_ErrorWhenOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.Dimmer(1));
        }

        [Fact]
        public void Brighten_ErrorWhenOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.Brighten(1));
        }



        //AutoOffTests

        //[Fact]
        //public void AutoOff_SwitchOnError()
        //{
        //    EcoLamp newLamp = new EcoLamp("n");
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SwitchOn(-1));
        //}

        //[Fact]
        //public void AutoOff_SwitchOnNormal()
        //{
        //    EcoLamp newLamp = new EcoLamp("n");
        //    newLamp.SwitchOn(8);
        //    Assert.Equal(newLamp.);
        //}

        //[Fact]
        //public void AutoOff_SwitchOnError()
        //{
        //    EcoLamp newLamp = new EcoLamp("n");
        //    Assert.Throws<ArgumentException>(() => newLamp.CheckAutoOff());
        //}
    }
}
