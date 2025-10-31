namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp
    {
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }

        public Lamp()
        {
            Brightness = 0;
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
            Brightness = 0;
        }

        public void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
            Brightness = 100;

        }

        public void ChangeBrightness(int newBrightness)
        {
            if (newBrightness >= 0 && newBrightness <= 100)
            {
                if (IsOn)
                {
                    Brightness = newBrightness;
                }
            } else
            {
                throw new ArgumentOutOfRangeException("Brightness must be between 0 and 100", nameof(Brightness));
            }
        }
    }
}
