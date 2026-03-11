using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class Lamp : AbstractLamp
    {
        //Defining standards
        public Intensity StandardMin { get; init; } = Intensity.Create(0, 0, 100);
        public Intensity StandardDefault { get; init; } = Intensity.Create(50, 0, 100);
        public Intensity StandardMax { get; init; } = Intensity.Create(100, 0, 100);

        //Abstract properties override
        public override Intensity MinIntensity => StandardMin;
        public override Intensity MaxIntensity => StandardMax;
        public override Intensity DefaultIntensity => StandardDefault;

        //Constructor
        public Lamp(string name) : base(name) { }

        public Lamp(Guid id, string name, DeviceStatus status, double intensity, DateTime creationtime, DateTime lastupdatetime) : base(name)
        {
            Id = id;
            Status = status;
            Intensity = Intensity.Create(intensity, StandardMin._intensity, StandardMax._intensity);
            CreationTime_UTC = creationtime;
            LastModification_UTC = lastupdatetime;
        }
    }
}
