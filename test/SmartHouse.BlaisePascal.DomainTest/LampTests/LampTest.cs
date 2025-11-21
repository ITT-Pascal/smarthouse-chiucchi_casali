using SmartHouse.BlaisePascal.Domain;
using System;

namespace SmartHouse.BlaisePascal.DomainTest
{
    public class LampTest
    {
        //Constructor Test
        [Fact]
        public void LampIsOn_WhenLampIsCreated_LampStatusMustBeOff()
        {
            Lamp newLamp = new Lamp("n");
            Assert.False(newLamp.IsOn);
        }
        //ToggleOnOff Tests
        [Fact]
        public void LampToggleOnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            //ARRANGE
            Lamp newLamp = new Lamp("n");
            //ACT
            newLamp.ToggleOnOff();
            //ASSERT
            Assert.True(newLamp.IsOn);
        }
        [Fact]
        public void LampToggleOnOff_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.ToggleOnOff();
            Assert.False(newLamp.IsOn);
        }
        //TurnOn Tests
        [Fact]
        public void LampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            Assert.True(newLamp.IsOn);
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
            Assert.False(newLamp.IsOn);
        }
        //ChangeBrightness Tests
        [Fact]
        public void LampChangeBrightness_WhenBrightnessIsOutOfRangeMaxBrightness_ThrowNewArgumentOutOfRangeException()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(101));
        }
        [Fact]
        public void LampChangeBrightness_WhenBrightnessIsOutOfRangeNegative_ThrowNewArgumentOutOfRangeException()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(-1));
        }
        [Fact]
        public void LampChangeBrightness_WhenLampIsOff_ThrowArgumentException()
        {
            Lamp newLamp = new Lamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SetIntensity(40));
        }
        [Fact]
        public void LampChangeBrightness_WhenLampIsOn_SetNewBrightness()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(50);
            Assert.Equal(50, newLamp.Intensity);
        }
        [Fact]
        public void LampChangeBrightness_WhenNewBrightnessIs0_SetBrightnessAs0AndTurnOffLamp()
        {
            Lamp newLamp = new Lamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(0);
            Assert.Equal(0, newLamp.Intensity);
            Assert.False(newLamp.IsOn);
        }
    }
}
