using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.ScrappedMaterial;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner
{
    public abstract class Abstract_AirConditioner:AbstractDevice
    {
        //Costanti per temperature di lavoro
        protected const int MaxTemperature = 35;
        protected const int DefaultTemperature = 25;
        protected const int MinTemperature = 15;

        //Properties
        public virtual Values Power { get; protected set; }
        public virtual bool Automatic { get; protected set; }

        //Temperatura ambientale
        public virtual int AmbientTemperature { get; protected set; }

        //Temperatura di lavoro attuale
        public virtual int ReachingTemperature { get; protected set; }
        public virtual bool _isNight { get; protected set; }

        public Abstract_AirConditioner(string name):base(name) { }

        public virtual void ReadAmbientTemperature(int ambientTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                AmbientTemperature = ambientTemperature;

                LastModification_UTC = DateTime.UtcNow;
            }
        }

        //Selezione della modalità di lavoro del condizionatore => manuale
        public abstract void ManualMode(int newTemperature);

        //Selezione della modalità di lavoro del condizionatore => automatica  
        public abstract void AutomaticMode();

        public virtual void IsNight()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 22 || hour < 6)//Orari convenzionali per la notte
            {
                _isNight = true;
            }
            _isNight = false;
        }
    }
}
