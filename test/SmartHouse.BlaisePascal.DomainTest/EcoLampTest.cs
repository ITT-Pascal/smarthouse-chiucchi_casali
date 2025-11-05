using SmartHouse.BlaisePascal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.DomainTest
{
    public class EcoLampTest
    {
        //Constructor Test
        [Fact]
        public void EcoLampIsOn_WhenLampIsCreated_LampStatusMustBeOff()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.False(newLamp.IsOn);
        }
        //TurnOn Tests
        [Fact]
        public void EcoLampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.True(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampTurnOn_WhenLampIsOn_ShouldThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentException>(() => newLamp.TurnOn());
        }
        //TurnOff Tests
        [Fact]
        public void EcoLampTurnOff_WhenLampIsOff_ShouldThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.Throws<ArgumentException>(() => newLamp.TurnOff());
        }
        [Fact]
        public void EcoLampTurnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.TurnOff();
            Assert.False(newLamp.IsOn);
        }
        //ChangeBrightness Tests
        [Fact]
        public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeMaxBrightness_ThrowNewArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(71));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeNegative_ThrowNewArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(-1));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.Throws<ArgumentException>(() => newLamp.ChangeBrightness(30));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenNewBrightnessIs0_SetBrightnessAs0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.ChangeBrightness(0);
            Assert.Equal(0, newLamp.Brightness);
            Assert.False(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOn_SetNewBrightness()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.ChangeBrightness(50);
            Assert.Equal(50, newLamp.Brightness);
        }
        //AdjustBrightness Tests
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeNegative_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustBrightnessByAmbientLight(-1));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeMaxBrightness_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustBrightnessByAmbientLight(71));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.Throws<ArgumentException>(() => newLamp.AdjustBrightnessByAmbientLight(30));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs70_SetBrightnessAt0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.AdjustBrightnessByAmbientLight(70);
            Assert.Equal(0, newLamp.Brightness);
            Assert.False(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs60_SetBrightnessAt10()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.AdjustBrightnessByAmbientLight(60);
            Assert.Equal(10, newLamp.Brightness);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs0_SetBrightnessAt70()
        {
            EcoLamp newLamp = new EcoLamp();
            newLamp.TurnOn();
            newLamp.AdjustBrightnessByAmbientLight(0);
            Assert.Equal(70, newLamp.Brightness);
        }
        //IsNight Tests
        [Fact]
        public void EcoLampIsNight_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.Throws<ArgumentException>(() => newLamp.IsNight());
        }
        //UltraEcoMode Tests
        [Fact]
        public void EcoUltraEcoMode_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp();
            Assert.Throws<ArgumentException>(() => newLamp.UltraEcoMode());
        }
    }
}
