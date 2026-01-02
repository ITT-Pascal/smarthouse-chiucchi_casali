using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.AirConditionerTests
{
    public class AirConditionerTest
    {
        [Fact]
        public void When_TheAirConditionerIsOff_CanTurnOnIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOn_CanTurnItOff()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchOff();

            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void SwitchToDryMode_WhenDeviceIsOff_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToDryMode());
        }

        [Fact]
        public void SwitchToHotMode_WhenDeviceIsOff_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToHotMode());
        }

        [Fact]
        public void SwitchToCoolMode_WhenDeviceIsOff_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToCoolMode());
        }

        [Fact]
        public void SwitchMode_WhenDeviceIsOff_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchMode(AirConditionerMode.Cool));
        }

        [Fact]
        public void SwitchToDryMode_WhenDeviceIsAlreadyInThatMode_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToDryMode());
        }

        [Fact]
        public void SwitchToHotMode_WhenDeviceIsAlreadyInThatMode_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchToHotMode();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToHotMode());
        }

        [Fact]
        public void SwitchToCoolMode_WhenDeviceIsAlreadyInThatMode_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchToCoolMode();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchToCoolMode());
        }

        [Fact]
        public void SwitchMode_WhenDeviceIsAlreadyInThatMode_ThrowArgumentException()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchMode(AirConditionerMode.Cool);
            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchMode(AirConditionerMode.Cool));
        }

        [Fact]
        public void SwitchToDryMode_NormalSwitch_SwitchesToDryMode()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchToCoolMode();
            newAirConditioner.SwitchToDryMode();
            Assert.Equal(AirConditionerMode.Dry, newAirConditioner.Mode);
        }

        [Fact]
        public void SwitchMode_NormalSwitch_SwitchesToDryMode()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchToCoolMode();
            newAirConditioner.SwitchMode(AirConditionerMode.Dry);
            Assert.Equal(AirConditionerMode.Dry, newAirConditioner.Mode);
        }

        [Fact]
        public void SwitchMode_NormalSwitch_SwitchesToHotMode()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchMode(AirConditionerMode.Hot);
            Assert.Equal(AirConditionerMode.Hot, newAirConditioner.Mode);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItToNormalFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SetPowerToPowerful();
            newAirConditioner.SwitchOff();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToNormal());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void SetPowerToNormal_TheAirConditionerIsAlreadyOnTheSelectedMode_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToNormal());
        }

        [Fact]
        public void SetPowerToNormal_NormalSwitch_SetsPowerToNormal()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();
            newAirConditioner.SetPowerToPowerful();
            newAirConditioner.SetPowerToNormal();
            Assert.Equal(AirConditionerPower.Normal, newAirConditioner.Power);
        }

        [Fact]
        public void SetPowerToWeak_TheAirConditionerIsAlreadyOnTheSelectedMode_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();

            newAirConditioner.SetPowerToWeak();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToWeak());
        }

        [Fact]
        public void SetPowerToPowerful_TheAirConditionerIsAlreadyOnTheSelectedMode_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");
            newAirConditioner.SwitchOn();

            newAirConditioner.SetPowerToPowerful();
            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToPowerful());
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnLowFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToWeak());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnLowFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPowerToWeak();

            Assert.Equal(AirConditionerPower.Weak, newAirConditioner.Power);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnMediumFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToWeak());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnMediumFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPowerToWeak();

            Assert.Equal(AirConditionerPower.Weak, newAirConditioner.Power);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnHighFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPowerToPowerful());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnHighFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPowerToPowerful();

            Assert.Equal(AirConditionerPower.Powerful, newAirConditioner.Power);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower(AirConditionerPower.Normal));
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
            Assert.Equal(AirConditionerPower.Normal, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower(AirConditionerPower.Powerful);

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(AirConditionerPower.Powerful, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeedButTheSpeedIsAlreadyAtMaximum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower(AirConditionerPower.Powerful);

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower(AirConditionerPower.Powerful));
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(AirConditionerPower.Powerful, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower(AirConditionerPower.Normal));
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower(AirConditionerPower.Weak);

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(AirConditionerPower.Weak, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeedButTheSpeedIsAlreadyAtMinimum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower(AirConditionerPower.Weak);

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower(AirConditionerPower.Weak));
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(AirConditionerPower.Weak, newAirConditioner.Power);
        }
    }
}
//[Fact]
//public void When_TheNameOfTheAirConditionerIsEmpty_TheNameIsNotValid()
//{
//    Assert.Throws<ArgumentException>(() => new AirConditioner(string.Empty));
//}