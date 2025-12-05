using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner
{
    public class AirConditioner:AbstractDevice
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

        //Methods
        public override void SwitchOn()
        {
            base.SwitchOn();
            Mode = AirConditionerMode.Dry; 
            Power = AirConditionerPower.Normal;
            AirTemperature = DryAirTemperature;
        }

        public void SwitchToDryMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch mode when the air conditioner is off.", nameof(Status));
            if (Mode == AirConditionerMode.Dry)
                throw new ArgumentException("Cannot change to dry mode when current mode is dry.", nameof(Mode));
            Mode = AirConditionerMode.Dry;
            AirTemperature = DryAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToHotMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch mode when the air conditioner is off.", nameof(Status));
            if (Mode == AirConditionerMode.Hot)
                throw new ArgumentException("Cannot change to Hot mode when current mode is Hot.", nameof(Mode));
            Mode = AirConditionerMode.Hot;
            AirTemperature = HotAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToCoolMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch mode when the air conditioner is off.", nameof(Status));
            if (Mode == AirConditionerMode.Cool)
                throw new ArgumentException("Cannot change to Cool mode when current mode is Cool.", nameof(Mode));
            Mode = AirConditionerMode.Cool;
            AirTemperature = CoolAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }
        
        public void SwitchMode(AirConditionerMode newMode)
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch mode when the air conditioner is off.", nameof(Status));
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
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch power when the air conditioner is off.", nameof(Status));
            if (Power == AirConditionerPower.Powerful)
                throw new ArgumentException("Cannot change to powerful when current power is powerful.", nameof(Power));
            Power = AirConditionerPower.Powerful;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToNormal()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch power when the air conditioner is off.", nameof(Status));
            if (Power == AirConditionerPower.Normal)
                throw new ArgumentException("Cannot change to normal when current power is normal.", nameof(Power));
            Power = AirConditionerPower.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToWeak()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch power when the air conditioner is off.", nameof(Status));
            if (Power == AirConditionerPower.Weak)
                throw new ArgumentException("Cannot change to weak when current power is weak.", nameof(Power));
            Power = AirConditionerPower.Weak;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPower(AirConditionerPower newPower)
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot switch mode when the air conditioner is off.", nameof(Status));
            if (Power == newPower)
                throw new ArgumentException("Cannot change to a power when current power is the same.", nameof(Mode));
            Power = newPower;

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
