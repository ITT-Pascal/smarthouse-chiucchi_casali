namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp: AbstractLamp
    {
        private const int MaxBrightness = 100;

        private const int MinBrightness = 0;

        public Lamp()
        {
            Id = Guid.NewGuid();
            IsOn = false;
            Brightness = MinBrightness;
        }

        public Lamp(int brightness)
        {
            Id = Guid.NewGuid();
            Brightness = brightness;
            IsOn = true;
        }

        public override void ToggleOnOff() => IsOn = !IsOn;


        public override void TurnOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Brightness = MinBrightness;
        }

        public override void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = MaxBrightness;

        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100", nameof(Brightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if (newBrightness == MinBrightness)
                TurnOff();
            else
                Brightness = newBrightness;
        }
    }
}
