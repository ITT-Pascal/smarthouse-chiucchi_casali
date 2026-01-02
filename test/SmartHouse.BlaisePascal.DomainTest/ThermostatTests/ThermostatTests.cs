using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat;

namespace SmartHouse.Domain.UnitTest.ThermostatTest
{
    public class ThermostatTest
    { 

        [Fact]
        public void When_WantToSetNewTemperatureButNewTempIsHigherThanMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThermostat.SetTemperature(40));
        }

        [Fact]
        public void When_WantToSetNewTemperatureButNewTempIsLowerThanMinTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThermostat.SetTemperature(14));
        }

        [Fact]
        public void When_WantToSetNewTemperatureAndNewTempIsValid_SetNewTempCorrectly()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            newThermostat.SetTemperature(28);

            Assert.Equal(28, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void When_WantToIncreaseTemperatureButIsAlreadyAtMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            newThermostat.SetTemperature(30);

            Assert.Throws<ArgumentException>(() => newThermostat.IncreaseTemperature());
        }

        [Fact]
        public void When_WantToIncreaseTemperatureAndIsNotAlreadyAtMaxTemperature_IncreaseTemperatureCorrectly()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            newThermostat.SetTemperature(28);
            newThermostat.IncreaseTemperature();

            Assert.Equal(28.5, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void When_WantToDecreaseTemperatureButIsAlreadyAtMinTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            newThermostat.SetTemperature(18);

            Assert.Throws<ArgumentException>(() => newThermostat.DecreaseTemperature());
        }

        [Fact]
        public void When_WantToDecreaseTemperatureAndIsNotAlreadyAtMaxTemperature_DecreaseTemperatureCorrectly()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            newThermostat.SetTemperature(20);
            newThermostat.DecreaseTemperature();

            Assert.Equal(19.5, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void SwitchOn_WhenSwitchedOn_WorkingTemperatureIsSetToStandard()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.SwitchOff();
            newThermostat.SwitchOn();
            Assert.Equal(24, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void ToggleMode_WhenManualMode_ModeSwitchedToAutomatic()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            Assert.Equal(ThermostatMode.Automatic, newThermostat.Mode);
        }

        [Fact]
        public void ToggleMode_WhenAutoMode_ModeSwitchedToManual()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.ToggleMode();
            Assert.Equal(ThermostatMode.Manual, newThermostat.Mode);
        }

        [Fact]
        public void IncreaseTemperature_WhenModeIsAuto_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            Assert.Throws<ArgumentException>(() => newThermostat.IncreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenModeIsAuto_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            Assert.Throws<ArgumentException>(() => newThermostat.DecreaseTemperature());
        }

        [Fact]
        public void SetTemperature_WhenModeIsAuto_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            Assert.Throws<ArgumentException>(() => newThermostat.SetTemperature(20));
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_WhenModeIsAuto_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            Assert.Throws<ArgumentException>(() => newThermostat.AdjustTemperatureByAmbientTemperature(20));
        }

        [Fact]
        public void AutoSwitchOffWhenIsNight_WhenModeIsAuto_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            Assert.Throws<ArgumentException>(() => newThermostat.AutoSwitchOffWhenIsNight());
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_WhenThermostatIsOff_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.SwitchOff();
            Assert.Throws<ArgumentException>(() => newThermostat.AdjustTemperatureByAmbientTemperature(20));
        }

        [Fact]
        public void AutoSwitchOffWhenIsNight_WhenThermostatIsOff_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.SwitchOff();
            Assert.Throws<ArgumentException>(() => newThermostat.AutoSwitchOffWhenIsNight());
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_NormalAdjust1_SetsNewWorkingTemperature()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.AdjustTemperatureByAmbientTemperature(10);
            Assert.Equal(30, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_NormalAdjust2_SetsNewWorkingTemperature()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.AdjustTemperatureByAmbientTemperature(35);
            Assert.Equal(18, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_NormalAdjust3_SetsNewWorkingTemperature()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.AdjustTemperatureByAmbientTemperature(26);
            Assert.Equal(24, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void AdjustTemperatureByAmbientTemperature_NormalAdjust4_SetsNewWorkingTemperature()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.AdjustTemperatureByAmbientTemperature(20);
            Assert.Equal(24, newThermostat.WorkingTemperature);
        }

        [Fact]
        public void AutoSwitchOffWhenIsNight_NormalSwitch_IfIsNightSwitchesOff()
        {
            Thermostat newThermostat = new Thermostat("Franco");
            newThermostat.ToggleMode();
            newThermostat.AutoSwitchOffWhenIsNight();
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6)
                Assert.Equal(DeviceStatus.Off, newThermostat.Status);
            else
                Assert.Equal(DeviceStatus.On, newThermostat.Status);
        }
    }
}