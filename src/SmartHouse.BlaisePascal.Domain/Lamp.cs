using System.Text.Json.Serialization;

namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp: AbstractLamp
    {
        public Lamp(string name):base(name) { }


        public override void ToggleOnOff() => IsOn = !IsOn;

        public override void SwitchOff()
        {
            base.SwitchOff();
        }

        public override void SwitchOn()
        {
            base.SwitchOn(); 
        }

        public override void SetBrightness(int newBrightness)
        {
            base.SetBrightness(newBrightness);
        }

        public override void SetName(string name)
        {
            base.SetName(name);
        }   
    }
}
