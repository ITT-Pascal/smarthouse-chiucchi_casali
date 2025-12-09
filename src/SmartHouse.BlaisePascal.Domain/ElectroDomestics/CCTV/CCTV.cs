using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV
{
    public class CCTV: AbstractDevice
    {
        //Properties
        public CCTVMode Mode { get; private set; }

        //Constructor
        public CCTV(string name) : base(name) { Status = DeviceStatus.Off; Mode = CCTVMode.Normal; }

        //Methods
        public void SwitchToNormalMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change mode when CCTV is off.", nameof(Status));
            if (Mode == CCTVMode.Normal)
                throw new ArgumentException("Cannot set mode to normal when it already is normal.", nameof(Mode));
            Mode = CCTVMode.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToInfraredVisionMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change mode when CCTV is off.", nameof(Status));
            if (Mode == CCTVMode.InfraredVision)
                throw new ArgumentException("Cannot set mode to infrared vision when it already is infrared vision.", nameof(Mode));
            Mode = CCTVMode.InfraredVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNightVisionMode()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change mode when CCTV is off.", nameof(Status));
            if (Mode == CCTVMode.NightVision)
                throw new ArgumentException("Cannot set mode to night vision when it already is night vision.", nameof(Mode));
            Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetMode(CCTVMode newMode)
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change mode when CCTV is off.", nameof(Status));
            if (newMode == Mode)
                throw new ArgumentException("Cannot set new mode that is same to current mode.", nameof(Mode));

            Mode = newMode;
            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetNightVisionWhenNight()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change mode when CCTV is off.", nameof(Status));
            if (Mode == CCTVMode.NightVision)
                throw new ArgumentException("Cannot set mode to night vision when it already is night vision.", nameof(Mode));
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6) //Orari convenzionali per la notte 
                Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
