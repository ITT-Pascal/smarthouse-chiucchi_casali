using SmartHouse.BlaisePascal.Domain;
using System;

namespace SmartHouse.BlaisePascal.DomainTest
{
    public class LampTest
    {
        [Fact]
        public void LampIsOn_WhenLampIsCreated_LampStatusMustBeOff()
        {
            Lamp newLamp = new Lamp();
            Assert.False(newLamp.IsOn);
        }
        [Fact]
        public void LampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            Lamp newLamp = new Lamp();
            newLamp.TurnOn();
            Assert.True(newLamp.IsOn);
        }
        [Fact]
        public void LampTurnOn_WhenLampIsOn_ShouldThrowArgumentException()
        {
            Lamp newLamp = new Lamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentException>(() => newLamp.TurnOn());
        }
        [Fact]
        public void LampTurnOff_WhenLampIsOff_ShouldThrowArgumentException()
        {
            Lamp newLamp = new Lamp();
            Assert.Throws<ArgumentException>(() => newLamp.TurnOff());
        }
        [Fact]
        public void LampTurnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            Lamp newLamp = new Lamp();
            newLamp.TurnOn();
            newLamp.TurnOff();
            Assert.False(newLamp.IsOn);
        }
    }
}
