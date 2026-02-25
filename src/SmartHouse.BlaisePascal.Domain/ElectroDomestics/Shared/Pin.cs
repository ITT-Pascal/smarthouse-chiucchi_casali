namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public sealed record Pin
    {
        public int _pin { get; }

        private Pin(int pin)
        {
            _pin = pin;
        }

        public static Pin Create(int pin)
        {
            if(pin.ToString().Length < 4)
                throw new Exception("Pin is invalid.");
            return new Pin(pin);
        }
    }
}
