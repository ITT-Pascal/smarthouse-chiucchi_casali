namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.ScrappedMaterial
{
    public class Cool_AirConditioner:Abstract_AirConditioner
    {
        //Override costante di temperatura massima
        protected new const int MaxTemperature = 25;
        private new const int DefaultTemperature = 22;
        
        //Costruttore
        public Cool_AirConditioner(string name):base(name) { }

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
            
            if(_isNight == true)
            {
                ReachingTemperature = DefaultTemperature + 2;
            }
            
            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
