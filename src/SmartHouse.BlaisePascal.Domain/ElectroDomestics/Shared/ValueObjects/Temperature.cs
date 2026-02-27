namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects
{
    public sealed record Temperature
    {
        public double _temperature { get; }

        private Temperature(double temperature) { _temperature = temperature; }

        public static Temperature Create(double temperature, int min, int max) => new Temperature(Math.Clamp(temperature, min, max));

        public static bool operator >=(Temperature t1, Temperature t2) => t1._temperature >= t2._temperature;
        public static bool operator <=(Temperature t1, Temperature t2) => t1._temperature <= t2._temperature;
        public static bool operator >(Temperature t1, Temperature t2) => t1._temperature > t2._temperature;
        public static bool operator <(Temperature t1, Temperature t2) => t1._temperature < t2._temperature;
        public static double operator +(Temperature t1, double t2) => t1._temperature + t2;
        public static double operator -(Temperature t1, double t2) => t1._temperature - t2;
        public static bool operator <(int t1, Temperature t2) => t1 < t2._temperature;
        public static bool operator >(int t1, Temperature t2) => t1 > t2._temperature;
        public static bool operator >=(int t1, Temperature t2) => t1 >= t2._temperature;
        public static bool operator <=(int t1, Temperature t2) => t1 <= t2._temperature;
    }
}
