using System.Text.Json.Serialization;

namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp: AbstractLamp
    {
        private const int MaxBrightness = 100;

        //public Lamp() {}
        //
        //public Lamp()
        //{
        //    Id = Guid.NewGuid();
        //    IsOn = false;
        //    Brightness = MinBrightness;
        //}

        ////public Lamp(int brightness, string name )
        ////{
        ////    Id = Guid.NewGuid();
        ////    Brightness = brightness;
        ////    IsOn = true;
        ////    Name = name;
        ////}


        public Lamp(string name):base(name)
        {

        }

        public override void ToggleOnOff() => IsOn = !IsOn;


        public override void SwitchOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Brightness = MinBrightness;
        }

        public override void SwitchOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = MaxBrightness;

        }

        public override void SetBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100", nameof(Brightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if (newBrightness == MinBrightness)
                SwitchOff();
            else
                Brightness = newBrightness;
        }

        public override void SetName(string name)
        {
            if (name != null)
                Name = name;
        }
    }
}
