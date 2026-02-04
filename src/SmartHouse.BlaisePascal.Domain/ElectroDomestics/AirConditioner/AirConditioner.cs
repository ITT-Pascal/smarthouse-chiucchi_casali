using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner
{
    public sealed class AirConditioner:AbstractDevice
    {
        //Properties
        public AirConditionerMode Mode { get; private set; }
        public AirConditionerPower Power { get; private set; }
        public double AirTemperature { get; private set; }

        //Constants
        public const double CoolAirTemperature = 16;
        public const double DryAirTemperature = 22;
        public const double HotAirTemperature = 28;
        // public const double StandardStep = 0.5;

        //Constructor
        public AirConditioner(string name):base(name) 
        { 
            Mode = AirConditionerMode.Dry; 
            Power = AirConditionerPower.Normal;
            AirTemperature = DryAirTemperature;
        }

        public void SwitchToDryMode()
        {
            CheckIsOff();
            if (Mode == AirConditionerMode.Dry)
                throw new ArgumentException("Cannot change to dry mode when current mode is dry.", nameof(Mode));
            Mode = AirConditionerMode.Dry;
            AirTemperature = DryAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToHotMode()
        {
            CheckIsOff();
            if (Mode == AirConditionerMode.Hot)
                throw new ArgumentException("Cannot change to Hot mode when current mode is Hot.", nameof(Mode));
            Mode = AirConditionerMode.Hot;
            AirTemperature = HotAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToCoolMode()
        {
            CheckIsOff();
            if (Mode == AirConditionerMode.Cool)
                throw new ArgumentException("Cannot change to Cool mode when current mode is Cool.", nameof(Mode));
            Mode = AirConditionerMode.Cool;
            AirTemperature = CoolAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }
        
        public void SwitchMode(AirConditionerMode newMode)
        {
            CheckIsOff();
            if (Mode == newMode)
                throw new ArgumentException("Cannot change to a mode when current mode is the same.", nameof(Mode));
            Mode = newMode;
            if (newMode == AirConditionerMode.Cool)
                AirTemperature = CoolAirTemperature;
            else if(newMode == AirConditionerMode.Hot)
                AirTemperature = HotAirTemperature;
            else
                AirTemperature = DryAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        //Set Power
        public void SetPowerToPowerful()
        {
            CheckIsOff();
            if (Power == AirConditionerPower.Powerful)
                throw new ArgumentException("Cannot change to powerful when current power is powerful.", nameof(Power));
            Power = AirConditionerPower.Powerful;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToNormal()
        {
            CheckIsOff();
            if (Power == AirConditionerPower.Normal)
                throw new ArgumentException("Cannot change to normal when current power is normal.", nameof(Power));
            Power = AirConditionerPower.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToWeak()
        {
            CheckIsOff();
            if (Power == AirConditionerPower.Weak)
                throw new ArgumentException("Cannot change to weak when current power is weak.", nameof(Power));
            Power = AirConditionerPower.Weak;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPower(AirConditionerPower newPower)
        {
            CheckIsOff();
            if (Power == newPower)
                throw new ArgumentException("Cannot change to a power when current power is the same.", nameof(Mode));
            Power = newPower;

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
