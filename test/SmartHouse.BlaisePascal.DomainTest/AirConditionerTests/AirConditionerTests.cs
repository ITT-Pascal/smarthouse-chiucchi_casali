using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.AirConditionerTests
{
    public class AirConditionerTest
    {
        [Fact]
        public void When_TheNameOfTheAirConditionerIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new AirConditioner(string.Empty));
        }

        [Fact]
        public void When_TheAirConditionerIsOff_CanTurnOnIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOn_CanTurnOffIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchOff();

            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
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

            Assert.Equal(Power.Weak, newAirConditioner.Power);
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

            Assert.Equal(Power.Normal, newAirConditioner.Power);
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

            Assert.Equal(Power.Powerful, newAirConditioner.Power);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
            Assert.Equal(Power.Normal, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(Power.Powerful, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeedButTheSpeedIsAlreadyAtMaximum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower();

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower());
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(Power.Powerful, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetPower());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
            Assert.Equal(Power.Weak, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(Power.Weak, newAirConditioner.Power);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeedButTheSpeedIsAlreadyAtMinimum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetPower();

            Assert.Throws<ArgumentException>(() => newAirConditioner.Power());
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(Power.Weak, newAirConditioner.Power);
        }
    }
}
