namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner
{
    public class Hot_AirConditioner : Abstract_AirConditioner
    {
        //Override costante di temperatura massima
        private new const int MaxTemperature = 38;
        private new const int DefaultTemperature = 32;
        private new const int MinTemperature = 25;
        //Costruttore
        public Hot_AirConditioner(string name) : base(name) { }

        //manuale
        public override void ManualMode(int newTemperature)
        {
            if (newTemperature <= MaxTemperature && newTemperature >= MinTemperature)
            {
                ReachingTemperature = newTemperature;
            }

            Automatic = false;

            LastModification_UTC = DateTime.UtcNow;
        }

        //automatico
        public override void AutomaticMode()
        {
            Automatic = true;
            ReachingTemperature = DefaultTemperature;

            if (_isNight == true)
            {
                ReachingTemperature = DefaultTemperature + 2;
            }

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
