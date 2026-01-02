using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV
{
    public class CCTV: AbstractDevice
    {
        //Properties
        public CCTVMode Mode { get; private set; }
        public double FOV { get; private set; } //FOV, or Field Of View, is the extent of the observable world visible at any moment, measured in degrees, representing how much of a scene a camera, eye, or device can capture.
        //Constants
        //FOV expressed in degrees (from min of 30° to max of 120°)
        public const int FocusFOV = 30; //Min
        public const int StandardFOV = 60;
        public const int WideAngleFOV = 120; //Max
        public const int StandardStep = 1;

        //Constructor
        public CCTV(string name) : base(name) { Status = DeviceStatus.Off; Mode = CCTVMode.Normal; FOV = StandardFOV; }

        //Methods
        public void SetFOVToStandard()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            if (FOV == StandardFOV)
                throw new ArgumentException("FOV is already standard.", nameof(FOV));
            FOV = StandardFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToFocus()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            if (FOV == FocusFOV)
                throw new ArgumentException("FOV is already focused.", nameof(FOV));
            FOV = FocusFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToWideAngle()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            if (FOV == WideAngleFOV)
                throw new ArgumentException("FOV is already wide angle.", nameof(FOV));
            FOV = WideAngleFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOV(int newFOV)
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            if (newFOV < FocusFOV || newFOV > WideAngleFOV)
                throw new ArgumentException("Cannot exceed camera FOV limits.", nameof(newFOV));
            if (newFOV == FOV)
                throw new ArgumentException("FOV already at that degree.", nameof(newFOV));
            FOV = newFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IncreaseFOV()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            FOV = Math.Min(WideAngleFOV, FOV + StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void DecreaseFOV()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException("Cannot change FOV when CCTV is off.", nameof(Status));
            FOV = Math.Max(FocusFOV, FOV - StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

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
            if (hour >= 22 || hour < 6) //Conventional Hours For Night
                Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
