using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.LampTests
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
            Assert.Equal(DeviceStatus.On, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }
        [Fact]
        public void TwoLampsDeviceToggleOneLamp_WhenLamp2IsSelected_Lamp2IsToggled()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp2.Id);
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.On, newLamp.Lamp2.Status);
        }
        //TurnOnBothLamps test
        [Fact]
        public void TwoLampsDeviceTurnOnBothLamps_WhenBothLampsAreOff_BothLampsAreTurnedOn()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            Assert.Equal(DeviceStatus.On, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.On, newLamp.Lamp2.Status);
        }
        //TurnOffBothLamps test
        [Fact]
        public void TwoLampsDeviceTurnOffBothLamps_WhenBothLampsAreOn_Lamp1AndLamp2AreTurnedOff()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.TurnOffBothLamps();
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp2.Status);
        }
        [Fact]
        public void TwoLampsDeviceTurnOffBothLamps_WhenFirstLampIsOn_Lamp1IsTurnedOff()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            newLamp.TurnOffBothLamps();
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp2.Status);
        }
        [Fact]
        public void TwoLampsDeviceTurnOffBothLamps_WhenSecondLampIsOn_Lamp2IsTurnedOff()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp2.Id);
            newLamp.TurnOffBothLamps();
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, newLamp.Lamp2.Status);
        }
        //ChangeOneLampBrightness tests
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenLamp1IsSelected_SetNewBrightnessForLamp1()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            newLamp.SetOneLampIntensity(lamp1.Id, Intensity.Create(10, 0, 100));
            Assert.Equal(10, newLamp.Lamp1.Intensity._intensity);
        }
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenLamp2IsSelected_SetNewBrightnessForLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp2.Id);
            newLamp.SetOneLampIntensity(lamp2.Id, Intensity.Create(10, 0, 70));
            Assert.Equal(10, newLamp.Lamp2.Intensity._intensity);
        }
        [Fact]
        public void TwoLampsDeviceChangeOneLampBrightness_WhenSelectedLampIsOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("na");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            Assert.Throws<ArgumentException>(() => newLamp.SetOneLampIntensity(lamp1.Id, Intensity.Create(20, 0, 100)));
            Assert.Throws<ArgumentException>(() => newLamp.SetOneLampIntensity(lamp2.Id, Intensity.Create(10, 0, 70)));
        }
        //[Fact]
        //public void TwoLampsDeviceChangeOneLampBrightness_WhenNewBrightnessIsOutOfRange_ThrowNewArgumentOutOfRangeException()
        //{
        //    AbstractLamp lamp1 = new Lamp("n");
        //    AbstractLamp lamp2 = new EcoLamp("na");
        //    TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
        //    newLamp.ToggleOneLamp(lamp1.Id);
        //    newLamp.ToggleOneLamp(lamp2.Id);
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetOneLampIntensity(lamp1.Id, Intensity.Create(101, 0, 100)));
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetOneLampIntensity(lamp2.Id, Intensity.Create(71, 0, 70)));
        //}
        //ChangeBothLampsBrightness tests
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_ChangeGoesCorrectly_SetNewBrightnessForLamp1AndLamp2()
        {
            AbstractLamp lamp1 = new Lamp("na");
            AbstractLamp lamp2 = new EcoLamp("n");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.SetBothLampsIntensity(Intensity.Create(10, 0, 100), Intensity.Create(20, 0, 70));
            Assert.Equal(10, newLamp.Lamp1.Intensity._intensity);
            Assert.Equal(20, newLamp.Lamp2.Intensity._intensity);
        }
        //[Fact]
        //public void TwoLampsDeviceChangeBothLampsBrightness_NewBrightnessOutOfRange_ThrowArgumentOutOfRangeException()
        //{
        //    AbstractLamp lamp1 = new Lamp("n");
        //    AbstractLamp lamp2 = new EcoLamp("an");
        //    TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
        //    newLamp.TurnOnBothLamps();
        //    Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetBothLampsIntensity(Intensity.Create(-1, 0, 100), Intensity.Create(71, 0, 70)));
        //}
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_WhenBothLampsAreOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            Assert.Throws<ArgumentException>(() => newLamp.SetBothLampsIntensity(Intensity.Create(20, 0, 100), Intensity.Create(10, 0, 70)));
        }
        [Fact]
        public void TwoLampsDeviceChangeBothLampsBrightness_WhenOneLampIsOff_ThrowArgumentException()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.ToggleOneLamp(lamp1.Id);
            Assert.Throws<ArgumentException>(() => newLamp.SetBothLampsIntensity(Intensity.Create(20, 0, 100), Intensity.Create(10, 0, 70)));
        }
        //Dimmer Tests
        [Fact]
        public void DimmerOneLamp_IfIdIsLamp1_DimmersLamp1()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.DimmerOneLamp(lamp1.Id, 1);
            Assert.Equal(49, lamp1.Intensity._intensity);
            Assert.Equal(30, lamp2.Intensity._intensity);
        }
        [Fact]
        public void DimmerOneLamp_IfIdIsLamp2_DimmersLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.DimmerOneLamp(lamp2.Id, 1);
            Assert.Equal(50, lamp1.Intensity._intensity);
            Assert.Equal(29, lamp2.Intensity._intensity);
        }
        [Fact]
        public void DimmerBothLamps_DimmersLamp1AndLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.DimmerBothLamps(1, 1);
            Assert.Equal(49, lamp1.Intensity._intensity);
            Assert.Equal(29, lamp2.Intensity._intensity);
        }
        //Brighten Tests
        [Fact]
        public void BrightenOneLamp_IfIdIsLamp1_BrightensLamp1()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.BrightenOneLamp(lamp1.Id, 1);
            Assert.Equal(51, lamp1.Intensity._intensity);
            Assert.Equal(30, lamp2.Intensity._intensity);
        }
        [Fact]
        public void BrightenOneLamp_IfIdIsLamp2_BrightensLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.BrightenOneLamp(lamp2.Id, 1);
            Assert.Equal(50, lamp1.Intensity._intensity);
            Assert.Equal(31, lamp2.Intensity._intensity);
        }
        [Fact]
        public void BrightenBothLamps_BrightensLamp1AndLamp2()
        {
            AbstractLamp lamp1 = new Lamp("n");
            AbstractLamp lamp2 = new EcoLamp("nn");
            TwoLampsDevice newLamp = new TwoLampsDevice(lamp1, lamp2);
            newLamp.TurnOnBothLamps();
            newLamp.BrightenBothLamps(1, 1);
            Assert.Equal(51, lamp1.Intensity._intensity);
            Assert.Equal(31, lamp2.Intensity._intensity);
        }
    }
}
