using System.Reflection.Metadata.Ecma335;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed record Intensity
    {
        public double _intensity { get; }

        private Intensity(double intensity) { _intensity = intensity; }

        public static Intensity Create(int value, int min, int max) => new Intensity(Math.Clamp(value, min, max));

        public static Intensity Create(double value, double min, double max) => new Intensity(Math.Clamp(value, min, max));

        public static Intensity operator -(Intensity i, int value) => new Intensity(i._intensity - value);

        public static Intensity operator -(Intensity i1, Intensity i2) => new Intensity(i1._intensity - i2._intensity);

        public static Intensity operator +(Intensity i, int value) => new Intensity(i._intensity + value);

        public static bool operator <(Intensity i1, Intensity i2) => i1._intensity < i2._intensity;

        public static bool operator <(int value, Intensity i) => value < i._intensity;

        public static bool operator >(int value, Intensity i) => value > i._intensity;

        public static bool operator >(Intensity i1, Intensity i2) => i1._intensity > i2._intensity;

        public static bool operator <(Intensity i, int value) => i._intensity < value;

        public static bool operator >(Intensity i, int value) => i._intensity > value;

        public static bool operator <=(Intensity i1, Intensity i2) => i1._intensity <= i2._intensity;

        public static bool operator >=(Intensity i1, Intensity i2) => i1._intensity >= i2._intensity;

        public static bool operator <=(Intensity i, int value) => i._intensity <= value;

        public static bool operator >=(Intensity i, int value) => i._intensity >= value;

        public static Intensity operator *(Intensity i, double value) => new Intensity(i._intensity * value);

        public static Intensity operator *(Intensity i, int value) => new Intensity(i._intensity * value);
    }
}
