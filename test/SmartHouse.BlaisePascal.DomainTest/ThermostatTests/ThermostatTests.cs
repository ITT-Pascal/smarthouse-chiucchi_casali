using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat;

namespace SmartHouse.Domain.UnitTest.ThermostatTest
{
    public class ThermostatTest
    {

        [Fact]
        public void When_WnatToSetNewTemperatureButNewTempIsHigherThanMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThermostat.SetTemperature(40));
        }

        [Fact]
        public void When_WnatToSetNewTemperatureButNewTempIsLowerThanMinTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThemostat.SetTemperature(14));
        }

        [Fact]
        public void When_WnatToSetNewTemperatureAndNewTempIsValid_SetNewTempCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(28);

            Assert.Equal(28, newThemostat.WorkingTemperature);
        }

        [Fact]
        public void When_WantToIncreaseTemperatureButIsAlredyAtMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(30);

            Assert.Throws<ArgumentException>(() => newThemostat.IncreaseTemperature());
        }

        [Fact]
        public void When_WantToIncreaseTemperatureAndIsNotAlredyAtMaxTemperature_IncreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(28);
            newThemostat.IncreaseTemperature();

            Assert.Equal(28.5, newThemostat.WorkingTemperature);
        }

        [Fact]
        public void When_WantToDecreaseTemperatureButIsAlredyAtMinTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(18);

            Assert.Throws<ArgumentException>(() => newThemostat.DecreaseTemperature());
        }

        [Fact]
        public void When_WantToDecreaseTemperatureAndIsNotAlredyAtMaxTemperature_DecreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(20);
            newThemostat.DecreaseTemperature();

            Assert.Equal(19.5, newThemostat.WorkingTemperature);
        }
    }
}