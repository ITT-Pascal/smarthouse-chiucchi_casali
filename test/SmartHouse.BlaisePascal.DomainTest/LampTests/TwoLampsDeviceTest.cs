using SmartHouse.BlaisePascal.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.DomainTest
{
    public class TwoLampsDeviceTest
    {
        //Constructor tests
        [Fact]
        public void TwoLampsDeviceConstructor_WhenDeviceIsCreated_SetCorrectlyLamp1AndLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            Assert.Equal(lamp1, newLamp.Lamp1);
            Assert.Equal(lamp2, newLamp.Lamp2);
        }
        //ToggleOneLamp tests
        [Fact]
        public void TwoLampsDeviceToggleOneLamp_WhenLamp1IsSelected_Lamp1IsToggled()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            Assert.True(newLamp.Lamp1.IsOn);
            Assert.False(newLamp.Lamp2.IsOn);
        }
        [Fact]
        public void TwoLampsDeviceToggleOneLamp_WhenLamp2IsSelected_Lamp2IsToggled()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp2.Id);
            Assert.False(newLamp.Lamp1.IsOn);
            Assert.True(newLamp.Lamp2.IsOn);
        }
        //TurnOnBothLamps test
        [Fact]
        public void TwoLampsDeviceTurnOnBothLamps_WhenBothLampsAreOff_BothLampsAreTurnedOn()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            Assert.True(newLamp.Lamp1.IsOn);
            Assert.True(newLamp.Lamp2.IsOn);
        }
        //TurnOffBothLamps test
        [Fact]
        public void TwoLampsDeviceTurnOffBothLamps_WhenBothLampsAreOn_Lamp1AndLamp2AreTurnedOff()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOffBothLamps();
            Assert.False(newLamp.Lamp1.IsOn);
            Assert.False(newLamp.Lamp2.IsOn);
        }
        //ChangeOneLampBrightness tests
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenLamp1IsSelected_SetNewBrightnessForLamp1()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            newLamp.SetOneLampIntensity(lamp1.Id, 10);
            Assert.Equal(10, newLamp.Lamp1.Intensity);
        }
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenLamp2IsSelected_SetNewBrightnessForLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp2.Id);
            newLamp.SetOneLampIntensity(lamp2.Id, 10);
            Assert.Equal(10, newLamp.Lamp2.Intensity);
        }
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenSelectedLampIsOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            Assert.Throws<ArgumentException>(() => newLamp.SetOneLampIntensity(lamp1.Id, 20));
            Assert.Throws<ArgumentException>(() => newLamp.SetOneLampIntensity(lamp2.Id, 10));
        }
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenNewBrightnessIsOutOfRange_ThrowNewArgumentOutOfRangeException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            newLamp.ToggleOneLamp(lamp2.Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetOneLampIntensity(lamp1.Id, 101));
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetOneLampIntensity(lamp2.Id, 71));
        }
        //ChangeBothLampsBrightness tests
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_ChangeGoesCorrectly_SetNewBrightnessForLamp1AndLamp2()
        {
            AbstractLamp lamp1 = new Lamp("na");
            AbstractLamp lamp2 = new EcoLamp("n");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.SetBothLampsIntensity(10, 20);
            Assert.Equal(10, newLamp.Lamp1.Intensity);
            Assert.Equal(20, newLamp.Lamp2.Intensity);
        }
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_NewBrightnessOutOfRange_ThrowArgumentOutOfRangeException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("an");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetBothLampsIntensity(-1, 71));
        }
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_WhenBothLampsAreOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            Assert.Throws<ArgumentException>(() => newLamp.SetBothLampsIntensity(20, 10));
        }
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_WhenOneLampIsOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            Assert.Throws<ArgumentException>(() => newLamp.SetBothLampsIntensity(20, 10));
        }
    }
}
