using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Thermostat
{
    public class Thermostat:AbstractDevice
    {
        //Property
        public double WorkingTemperature { get; private set; }
        public ThermostatMode Mode { get; private set; }

        //Constants
        public const double MinTemperature = 18; //Range of temperature the thermostat can work in
        public const double StandardTemperature = 24;
        public const double MaxTemperature = 30;
        public const double StandardStep = 0.5; 

        //Constructor
        public Thermostat(string name):base(name) 
        {
            WorkingTemperature = StandardTemperature;
            Status = DeviceStatus.On;
            Mode = ThermostatMode.Manual;
        }

        public override void SwitchOn()
        {
            base.SwitchOn();
            WorkingTemperature = StandardTemperature;
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            WorkingTemperature = MinTemperature;
        }

        public void ToggleMode()
        {
            if (Mode == ThermostatMode.Manual)
                Mode = ThermostatMode.Automatic;
            else
                Mode = ThermostatMode.Manual;
        }

        public void IncreaseTemperature()
        {
            if (WorkingTemperature >= MaxTemperature)
                throw new ArgumentException("Cannot increase more than the limit.", nameof(WorkingTemperature));
            if (Mode == ThermostatMode.Automatic)
                throw new ArgumentException("Cannot change temperature when in automatic mode.", nameof(Mode));
            WorkingTemperature = Math.Min(MaxTemperature, WorkingTemperature + StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            if (WorkingTemperature <= MinTemperature)
                throw new ArgumentException("Cannot decrease more than the limit.", nameof(WorkingTemperature));
            if (Mode == ThermostatMode.Automatic)
                throw new ArgumentException("Cannot change temperature when in automatic mode.", nameof(Mode));
            WorkingTemperature = Math.Max(MinTemperature, WorkingTemperature - StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetTemperature(int newTemperature)
        {
            if(newTemperature > MaxTemperature || newTemperature < MinTemperature)
                throw new ArgumentException("New temperature must be between the limits or equal to them.", nameof(WorkingTemperature));
            if (Mode == ThermostatMode.Automatic)
                throw new ArgumentException("Cannot change temperature when in automatic mode.", nameof(Mode));
            WorkingTemperature = newTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void AdjustTemperatureByAmbientTemperature(int ambientTemperature)
        {
            if (Status == DeviceStatus.Off) //E' meglio fare =! da On o == a Off?
                throw new ArgumentException("Cannot change temperature when the thermostat is off", nameof(Status));
            if (Mode == ThermostatMode.Manual)
                throw new ArgumentException("Cannot adjust temperature automatically when in manual mode.", nameof(Mode));

            if (ambientTemperature <= MinTemperature)
                WorkingTemperature = MaxTemperature;
            else if (ambientTemperature < MaxTemperature && ambientTemperature > MinTemperature)
                WorkingTemperature = Math.Max(MinTemperature, Math.Min(MaxTemperature, MaxTemperature - ambientTemperature));
            else if (ambientTemperature >= MaxTemperature)
                SwitchOff();

            LastModification_UTC = DateTime.UtcNow;
        }

        public void AutoSwitchOffWhenIsNight()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch off automatically when the thermostat is off", nameof(Status));
            if (Mode == ThermostatMode.Manual)
                throw new ArgumentException("Cannot switch off automatically when in manual mode.", nameof(Mode));
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte 
                SwitchOff();
        }
    }

    //public class Thermostat:AbstractDevice
    //{
    //    //Costanti: di temperatura minima e massima a cui si accende il termostato:  17 <= x <= 30
    //    private const int MinReachingTemperature = 17;
    //    private const int DefaultReachingTemperature = 22;
    //    private const int MaxReachingTemperature = 29;

    //    //Temperature notturne
    //    private const int DefaultNightReachingTemperature = 18;
    //    public int NightTemperature { get; private set; }
    //    private bool _isNight;

    //    //Properties
    //    public Values Power { get; private set; }
    //    public bool Automatic { get; private set; }

    //    //Temperatura ambientale
    //    public int AmbientTemperature { get; private set; }

    //    //Temperatura di lavoro attuale
    //    public int ReachingTemperature { get; private set; }


    //    //Costruttore
    //    public Thermostat(string name) : base(name) { }

    //    //Legge la temperatura ambientale
    //    public void ReadAmbientTemperature(int ambientTemperature)
    //    {
    //        if (Status == DeviceStatus.On)
    //        {
    //            AmbientTemperature = ambientTemperature;

    //            LastModification_UTC = DateTime.UtcNow;
    //        }
    //    }

    //    //Selezione della modalità di lavoro del termostato => manuale
    //    public void ManualMode(int newTemperature, Values power, int nightTemperature)
    //    {

    //        if (Status == DeviceStatus.On)
    //        {
    //            if (newTemperature >= MinReachingTemperature && newTemperature <= MaxReachingTemperature)
    //                ReachingTemperature = newTemperature;

    //            if (nightTemperature >= MinReachingTemperature && nightTemperature <= MaxReachingTemperature)
    //                NightTemperature = nightTemperature;
    //        }

    //        Power = power;

    //        LastModification_UTC = DateTime.UtcNow;
            
    //        Automatic = false;
    //    }
        
    //    //Selezione della modalità di lavoro del termostato => automatica  
    //    public void AutomaticMode()
    //    {
    //        Automatic = true;
    //        if (Status == DeviceStatus.On)
    //        {
    //            if (_isNight == true)
    //            {
    //                IsNight();
    //                return;
    //            }
    //            if (AmbientTemperature <= MinReachingTemperature)
    //            {
    //                Power = Values.Four;
    //                SetReachingTemperature();
    //            }
    //            else if(AmbientTemperature <= DefaultReachingTemperature)
    //            {
    //                Power = Values.Three;
    //                SetReachingTemperature();
    //            }
    //            else if(AmbientTemperature <= MaxReachingTemperature)
    //            {
    //                Power = Values.Two;
    //                SetReachingTemperature();
    //            }
    //            else
    //            {
    //                Status = DeviceStatus.Standby;
    //            }
    //            LastModification_UTC = DateTime.UtcNow;
    //        }
    //    }
        
    //    private void SetReachingTemperature() //Setta la temperatura in base alla potenza selezionata
    //    {
    //        if (Status == DeviceStatus.On)
    //        {
    //            if (Power == Values.One)
    //            {
    //                ReachingTemperature = MinReachingTemperature;
    //            }
    //            else if (Power == Values.Two)
    //            {
    //                ReachingTemperature = MinReachingTemperature + 2;
    //            }
    //            else if (Power == Values.Three)
    //            {
    //                ReachingTemperature = DefaultReachingTemperature;
    //            }
    //            else if (Power == Values.Four)
    //            {
    //                ReachingTemperature = DefaultReachingTemperature + 3;
    //            }
    //            else
    //            {
    //                ReachingTemperature = MaxReachingTemperature;
    //            }   
    //        }

    //        if(Automatic == true)
    //        {
    //            ReachingTemperature = DefaultReachingTemperature;
    //        }

    //        LastModification_UTC = DateTime.UtcNow;
    //    }

    //    public void IsNight()
    //    {
    //        int hour = DateTime.Now.Hour;

    //        if (hour >= 22 || hour < 6)//Orari convenzionali per la notte
    //        {
    //            _isNight = true;

    //            if (Automatic == true)
    //            {
    //                ReachingTemperature = DefaultNightReachingTemperature;
    //            }
    //            else
    //            {
    //                ReachingTemperature = NightTemperature;
    //            }
    //        }
    //        _isNight = false;
    //    }
}