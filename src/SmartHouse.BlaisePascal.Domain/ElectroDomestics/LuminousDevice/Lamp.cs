namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class Lamp: AbstractLamp
    {
        //Constants
        private const int StandardMin = 0;
        private const int StandardDeFault = 50;
        private const int StandardMax = 100;

        //Abstract properties override
        public override int MinIntensity => StandardMin;
        public override int MaxIntensity => StandardMax;
        public override int DefaultIntensity => StandardDeFault;
        
        //Constructor
        public Lamp(string name):base(name) { }  
    }
}
