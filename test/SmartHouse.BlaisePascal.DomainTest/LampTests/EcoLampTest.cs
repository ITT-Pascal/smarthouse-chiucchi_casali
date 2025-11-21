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
            EcoLamp newLamp = new EcoLamp("n");
            Assert.False(newLamp.IsOn);
        }
        //ToggleOnOff Tests
        [Fact]
        public void EcoLampToggleOnOff_WhenLampIsOn_LampStatusIsTurnedToOff()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.ToggleOnOff();
            Assert.True(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampToggleOnOff_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.ToggleOnOff();
            Assert.False(newLamp.IsOn);
        }
        //TurnOn Tests
        [Fact]
        public void EcoLampTurnOn_WhenLampIsOff_LampStatusIsTurnedToOn()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.True(newLamp.IsOn);
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
            Assert.False(newLamp.IsOn);
        }
        //ChangeBrightness Tests
        [Fact]
        public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeMaxBrightness_ThrowNewArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(71));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenBrightnessIsOutOfRangeNegative_ThrowNewArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(-1));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.SetIntensity(30));
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenNewBrightnessIs0_SetBrightnessAs0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(0);
            Assert.Equal(0, newLamp.Intensity);
            Assert.False(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampChangeBrightness_WhenLampIsOn_SetNewBrightness()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.SetIntensity(50);
            Assert.Equal(50, newLamp.Intensity);
        }
        //AdjustBrightness Tests
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeNegative_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustBrightnessByAmbientLight(-1));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIsOutOfRangeMaxBrightness_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.AdjustBrightnessByAmbientLight(71));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.AdjustBrightnessByAmbientLight(30));
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs70_SetBrightnessAt0AndTurnOffLamp()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustBrightnessByAmbientLight(70);
            Assert.Equal(0, newLamp.Intensity);
            Assert.False(newLamp.IsOn);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs60_SetBrightnessAt10()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustBrightnessByAmbientLight(60);
            Assert.Equal(10, newLamp.Intensity);
        }
        [Fact]
        public void EcoLampAdjustBrightnessByAmbientLight_WhenAmbientBrightnessIs0_SetBrightnessAt70()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.AdjustBrightnessByAmbientLight(0);
            Assert.Equal(70, newLamp.Intensity);
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
            {
                Assert.Equal(56, newLamp.Intensity);
            }
            else
            {
                Assert.Equal(70, newLamp.Intensity);
            }
        }
        //UltraEcoMode Tests
        [Fact]
        public void EcoLampUltraEcoMode_WhenEcoLampIsOff_ThrowArgumentException()
        {
            EcoLamp newLamp = new EcoLamp("n");
            Assert.Throws<ArgumentException>(() => newLamp.UltraEcoMode());
        }
        [Fact]
        public void EcoLampUltraEcoMode_WhenEcoLampIsOnAndBightnessIs70_ReduceBrightnessBy20Percent()
        {
            EcoLamp newLamp = new EcoLamp("n");
            newLamp.SwitchOn();
            newLamp.UltraEcoMode();
            Assert.Equal(56, newLamp.Intensity);
        }
    }
}
