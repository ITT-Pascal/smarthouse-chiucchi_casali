using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV
{
    public sealed class CCTV: AbstractDevice
    {
        //Properties
        public CCTVMode Mode { get; private set; }
        public FOV FOV { get; private set; } //FOV, or Field Of View, is the extent of the observable world visible at any moment, measured in degrees, representing how much of a scene a camera, eye, or device can capture.
        //Constants
        //FOV expressed in degrees (from min of 30° to max of 120°)
        public FOV FocusFOV { get; init; } = FOV.Create(30); //Min
        public FOV StandardFOV { get; init; } = FOV.Create(60);
        public FOV WideAngleFOV { get; init; } = FOV.Create(120); //Max
        public const int StandardStep = 1;

        //Constructor
        public CCTV(string name) : base(name) { Mode = CCTVMode.Normal; FOV = StandardFOV; }

        //Methods
        public void SetFOVToStandard()
        {
            CheckIsOff();
            CheckFOV(StandardFOV);
            FOV = StandardFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToFocus()
        {
            CheckIsOff();
            CheckFOV(FocusFOV);
            FOV = FocusFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToWideAngle()
        {
            CheckIsOff();
            CheckFOV(WideAngleFOV);
            FOV = WideAngleFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOV(FOV newFOV) //Chiedi se fare int o FOV
        {
            CheckIsOff();
            //if (newFOV < FocusFOV || newFOV > WideAngleFOV)
            //    throw new ArgumentException("Cannot exceed camera FOV limits.", nameof(newFOV));
            CheckFOV(newFOV);
            FOV = newFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IncreaseFOV()
        {
            CheckIsOff();
            FOV = FOV.Create(FOV._fov + StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void DecreaseFOV()
        {
            CheckIsOff();
            FOV = FOV.Create(FOV._fov - StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNormalMode()
        {
            CheckIsOff();
            CheckMode(CCTVMode.Normal);
            Mode = CCTVMode.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToInfraredVisionMode()
        {
            CheckIsOff();
            CheckMode(CCTVMode.InfraredVision);
            Mode = CCTVMode.InfraredVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNightVisionMode()
        {
            CheckIsOff();
            CheckMode(CCTVMode.NightVision);
            Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetMode(CCTVMode newMode)
        {
            CheckIsOff();
            CheckMode(newMode);
            Mode = newMode;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetNightVisionWhenNight()
        {
            CheckIsOff();
            CheckMode(CCTVMode.NightVision);
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6) //Conventional Hours For Night
                Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        private void CheckMode(CCTVMode mode)
        {
            if (this.Mode == mode)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(Mode));
        }

        private void CheckFOV(FOV fov)
        {
            if (FOV._fov == fov._fov)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(FOV));
        }
    }
}
