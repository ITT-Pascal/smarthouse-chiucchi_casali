namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects
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

        public static bool operator ==(Pin p1, int p2) => p1._pin == p2;
        public static bool operator !=(Pin p1, int p2) => p1._pin != p2;
    }
}
