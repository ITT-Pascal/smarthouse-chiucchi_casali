namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp
    {
        private const int MaxBrightness = 100;

        private const int MinBrightness = 0;
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }

        public Lamp()
        {
            Brightness = MinBrightness;
            IsOn = false;
        }

        public Lamp(int brightness)
        {
            Brightness = brightness;
            IsOn = true;
        }

        public void TurnOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
            Brightness = MinBrightness;
        }

        public void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = MaxBrightness;

        }

        public void ChangeBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100", nameof(Brightness));

            if (!IsOn)
                throw new ArgumentException("Cannot change brightness when the lamp is off", nameof(IsOn));

            if (newBrightness == MinBrightness)
            {
                TurnOff();
            }
            else
            {
                Brightness = newBrightness;
            }
        }
    }
}
