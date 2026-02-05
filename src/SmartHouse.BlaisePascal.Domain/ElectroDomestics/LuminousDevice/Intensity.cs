using System.Reflection.Metadata.Ecma335;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed record Intensity
    {
        public int _intensity { get; }

        private Intensity(int intensity) { _intensity = intensity; }

        public static Intensity Create(int value, int min, int max) => new Intensity(Math.Clamp(value, min, max)); //continua la classe (inspirati da qualcuno ;) )
    }
}
