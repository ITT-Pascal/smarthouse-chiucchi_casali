using System.Text.Json.Serialization;

namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp: AbstractLamp
    {
        //Constants
        private const int StandardMin = 0;
        private const int StandardDeFault = 50;
        private const int StandardMax = 100;

        //Abstract properties ovveride
        public override int MinIntensity => StandardMin;
        public override int MaxIntensity => StandardMax;
        public override int DefaultIntensity => StandardDeFault;
        
        //Construcor
        public Lamp(string name):base(name) { }  
    }
}
