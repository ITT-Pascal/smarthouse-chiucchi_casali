using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.LampTests
{
    public class LampTest
    {
        //Constructor Test
        [Fact]
        public void LampIsOn_WhenLampIsCreated_LampStatusMustBeOff()
        {
            Lamp newLamp = new Lamp("n");
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //ToggleOnOff Tests
        [Fact]
        public void LampToggleOnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            //ARRANGE
            Lamp newLamp = new Lamp("n");
            //ACT
            newLamp.Toggle();
            //ASSERT
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
        [Fact]
        public void LampToggleOnOff_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.Toggle();
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //TurnOn Tests
        [Fact]
        public void LampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
        [Fact]
        public void LampTurnOn_WhenLampIsOn_ShouldThrowArgumentException()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentException>(() => newLamp.SwitchOn());
        }
        //TurnOff Tests
        [Fact]
        public void LampTurnOff_WhenLampIsOff_ShouldThrowArgumentException()
        {
            Lamp newLamp = new Lamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SwitchOff());
        }
        [Fact]
        public void LampTurnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
        //ChangeBrightness Tests
        //[Fact]
        //public void LampChangeBrightness_WhenBrightnessIsOutOfRangeMaxBrightness_ThrowNewArgumentOutOfRangeException()
        //{
        //    Lamp newLamp = new Lamp("n");
        //    newLamp.SwitchOn();
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(Intensity.Create(101,0,100)));
        //}
        //[Fact]
        //public void LampChangeBrightness_WhenBrightnessIsOutOfRangeNegative_ThrowNewArgumentOutOfRangeException()
        //{
        //    Lamp newLamp = new Lamp("n");
        //    newLamp.SwitchOn();
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(Intensity.Create(-1, 0, 100)));
        //}
        [Fact]
        public void LampChangeBrightness_WhenLampIsOff_ThrowArgumentException()
        {
            Lamp newLamp = new Lamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SetIntensity(Intensity.Create(40, 0, 100)));
        }
        [Fact]
        public void LampChangeBrightness_WhenLampIsOn_SetNewBrightness()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(Intensity.Create(50, 0, 100));
            Assert.Equal(50, newLamp.Intensity._intensity);
        }
        [Fact]
        public void LampChangeBrightness_WhenNewBrightnessIs0_SetBrightnessAs0AndTurnOffLamp()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(Intensity.Create(0, 0, 100));
            Assert.Equal(0, newLamp.Intensity._intensity);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
    }
}
