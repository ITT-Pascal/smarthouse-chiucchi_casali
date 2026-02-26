namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat.ValueObjects
{
    public sealed record Temperature
    {
        public double _temperature { get; }

        private Temperature(double temperature) { _temperature = temperature; }

        public static Temperature Create(double temperature, int min, int max) => new Temperature(Math.Clamp(temperature, min, max));
    }
}
