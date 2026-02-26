using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV
{
    public sealed class CCTV: AbstractDevice, ILockable
    {
        //Properties
        public Pin Pin { get; private set; }
        public LockStatus LockStatus { get; private set; }
        public CCTVMode Mode { get; private set; }
        public FOV FOV { get; private set; } //FOV, or Field Of View, is the extent of the observable world visible at any moment, measured in degrees, representing how much of a scene a camera, eye, or device can capture.
        //Constants
        //FOV expressed in degrees (from min of 30° to max of 120°)
        public FOV FocusFOV { get; init; } = FOV.Create(30); //Min
        public FOV StandardFOV { get; init; } = FOV.Create(60);
        public FOV WideAngleFOV { get; init; } = FOV.Create(120); //Max
        public const int StandardStep = 1;

        //Constructor
        public CCTV(string name, int pin) : base(name) 
        { 
            Mode = CCTVMode.Normal; 
            FOV = StandardFOV;
            LockStatus = LockStatus.Unlocked;
            Pin = Pin.Create(pin);
        }

        //Methods
        public void Lock(Pin pin)
        {
            CheckLocked();
            LockStatus = LockStatus.Locked;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void Unlock(Pin pin)
        {
            CheckUnlocked();
            LockStatus = LockStatus.Unlocked;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void ChangePin(int currentPin, int newPin)
        {
            CheckLocked();
            if (Pin != currentPin)
                throw new ArgumentException("Wrong pin, police has been advised.", nameof(Pin));
            if (Pin == newPin)
                throw new ArgumentException("The new pin is equal to the current one.", nameof(Pin));

            Pin = Pin.Create(newPin);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToStandard()
        {
            CheckIsOff();
            CheckLocked();
            CheckFOV(StandardFOV);
            FOV = StandardFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToFocus()
        {
            CheckIsOff();
            CheckLocked();
            CheckFOV(FocusFOV);
            FOV = FocusFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToWideAngle()
        {
            CheckIsOff();
            CheckLocked();
            CheckFOV(WideAngleFOV);
            FOV = WideAngleFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOV(FOV newFOV) //Chiedi se fare int o FOV
        {
            CheckIsOff();
            CheckLocked();
            //if (newFOV < FocusFOV || newFOV > WideAngleFOV)
            //    throw new ArgumentException("Cannot exceed camera FOV limits.", nameof(newFOV));
            CheckFOV(newFOV);
            FOV = newFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IncreaseFOV()
        {
            CheckIsOff();
            CheckLocked();
            FOV = FOV.Create(FOV._fov + StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void DecreaseFOV()
        {
            CheckIsOff();
            CheckLocked();
            FOV = FOV.Create(FOV._fov - StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNormalMode()
        {
            CheckIsOff();
            CheckLocked();
            CheckMode(CCTVMode.Normal);
            Mode = CCTVMode.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToInfraredVisionMode()
        {
            CheckIsOff();
            CheckLocked();
            CheckMode(CCTVMode.InfraredVision);
            Mode = CCTVMode.InfraredVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNightVisionMode()
        {
            CheckIsOff();
            CheckLocked();
            CheckMode(CCTVMode.NightVision);
            Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetMode(CCTVMode newMode)
        {
            CheckIsOff();
            CheckLocked();
            CheckMode(newMode);
            Mode = newMode;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetNightVisionWhenNight()
        {
            CheckIsOff();
            CheckLocked();
            CheckMode(CCTVMode.NightVision);
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6) //Conventional Hours For Night
                Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void CheckMode(CCTVMode mode)
        {
            if (this.Mode == mode)
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(Mode));
        }

        public void CheckFOV(FOV fov)
        {
            if (FOV.Equals(fov))
                throw new ArgumentException("Method invocation failed: current value in incompatible state.", nameof(FOV));
        }

        public void CheckLocked()
        {
            if (this.LockStatus == LockStatus.Locked)
                throw new ArgumentException("CCTV is locked.", nameof(LockStatus));
        }

        public void CheckUnlocked()
        {
            if (this.LockStatus == LockStatus.Unlocked)
                throw new ArgumentException("CCTV is unlocked.", nameof(LockStatus));
        }
    }
}
