namespace SmartHouse.BlaisePascal.Domain
{
    public class Lamp
    {
        public bool IsOn { get; private set; }

        public Lamp()
        {
            IsOn = false;
        }

        public void TurnOff()
        {
            if (!IsOn)
                throw new ArgumentException("Cannot turn off a lamp that is already off.", nameof(IsOn));
            IsOn = false;
        }

        public void TurnOn()
        {
            if (IsOn)
                throw new ArgumentException("Cannot turn on a lamp that is already on.", nameof(IsOn));
            IsOn = true;
        }
    }
}
