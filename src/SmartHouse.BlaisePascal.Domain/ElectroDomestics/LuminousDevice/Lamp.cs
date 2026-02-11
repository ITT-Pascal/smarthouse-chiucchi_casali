using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class Lamp: AbstractLamp
    {
        //Defining standards
        Intensity StandardMin { get; init; } = Intensity.Create(0, 0, 100);
        Intensity StandardDefault { get; init; } = Intensity.Create(50, 0, 100);
        Intensity StandardMax { get; init; } = Intensity.Create(100, 0, 100);

        //Abstract properties override
        public override Intensity MinIntensity => StandardMin;
        public override Intensity MaxIntensity => StandardMax;
        public override Intensity DefaultIntensity => StandardDefault;
        
        //Constructor
        public Lamp(string name):base(name) { }  
    }
}
