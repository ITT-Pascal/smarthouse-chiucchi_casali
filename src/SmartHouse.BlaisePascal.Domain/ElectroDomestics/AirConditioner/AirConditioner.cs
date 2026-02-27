using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner
{
    public sealed class AirConditioner:AbstractDevice
    {
        //Properties
        public AirConditionerMode Mode { get; private set; }
        public AirConditionerPower Power { get; private set; }
        public Temperature AirTemperature { get; private set; }

        //Constants
        Temperature CoolAirTemperature { get; init; } = Temperature.Create(16, 16, 28);
        Temperature DryAirTemperature { get; init; } = Temperature.Create(22, 16, 28);
        Temperature HotAirTemperature { get; init; } = Temperature.Create(28, 16, 28);
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
            CheckMode(AirConditionerMode.Dry);
            Mode = AirConditionerMode.Dry;
            AirTemperature = DryAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToHotMode()
        {
            CheckIsOff();
            CheckMode(AirConditionerMode.Hot);
            Mode = AirConditionerMode.Hot;
            AirTemperature = HotAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToCoolMode()
        {
            CheckIsOff();
            CheckMode(AirConditionerMode.Cool);
            Mode = AirConditionerMode.Cool;
            AirTemperature = CoolAirTemperature;

            LastModification_UTC = DateTime.UtcNow;
        }
        
        public void SwitchMode(AirConditionerMode newMode)
        {
            CheckIsOff();
            CheckMode(newMode);
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
            CheckPower(AirConditionerPower.Powerful);
            Power = AirConditionerPower.Powerful;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToNormal()
        {
            CheckIsOff();
            CheckPower(AirConditionerPower.Normal);
            Power = AirConditionerPower.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPowerToWeak()
        {
            CheckIsOff();
            CheckPower(AirConditionerPower.Weak);
            Power = AirConditionerPower.Weak;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetPower(AirConditionerPower newPower)
        {
            CheckIsOff();
            CheckPower(newPower);
            Power = newPower;

            LastModification_UTC = DateTime.UtcNow;
        }

        private void CheckMode(AirConditionerMode mode)
        {
            if (this.Mode == mode)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(Mode));
        }

        private void CheckPower(AirConditionerPower power)
        {
            if (this.Power == power)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(Power));
        }
    }
}
