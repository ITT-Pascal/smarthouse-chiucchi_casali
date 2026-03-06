using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.ValueObjects;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice
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
        FOV FocusFOV { get; init; } = FOV.Create(30); //Min
        FOV StandardFOV { get; init; } = FOV.Create(60);
        FOV WideAngleFOV { get; init; } = FOV.Create(120); //Max
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
        public void Lock(int pin)
        {
            CheckIsOff();
            CheckPin(pin);
            CheckLockStatus(LockStatus.Locked);

            LockStatus = LockStatus.Locked;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void Unlock(int pin)
        {
            CheckIsOff();
            CheckPin(pin);
            CheckLockStatus(LockStatus.Unlocked);
            LockStatus = LockStatus.Unlocked;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void ChangePin(int currentPin, int newPin)
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckPin(currentPin);
            if (Pin == newPin)
                throw new ArgumentException("The new pin is equal to the current one.", nameof(Pin));

            Pin = Pin.Create(newPin);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToStandard()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckFOV(StandardFOV);
            FOV = StandardFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToFocus()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckFOV(FocusFOV);
            FOV = FocusFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOVToWideAngle()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckFOV(WideAngleFOV);
            FOV = WideAngleFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetFOV(FOV newFOV) //Chiedi se fare int o FOV
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            //if (newFOV < FocusFOV || newFOV > WideAngleFOV)
            //    throw new ArgumentException("Cannot exceed camera FOV limits.", nameof(newFOV));
            CheckFOV(newFOV);
            FOV = newFOV;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void IncreaseFOV()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            FOV = FOV.Create(FOV._fov + StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void DecreaseFOV()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            FOV = FOV.Create(FOV._fov - StandardStep);

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNormalMode()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckMode(CCTVMode.Normal);
            Mode = CCTVMode.Normal;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToInfraredVisionMode()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckMode(CCTVMode.InfraredVision);
            Mode = CCTVMode.InfraredVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SwitchToNightVisionMode()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckMode(CCTVMode.NightVision);
            Mode = CCTVMode.NightVision;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetMode(CCTVMode newMode)
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
            CheckMode(newMode);
            Mode = newMode;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void SetNightVisionWhenNight()
        {
            CheckIsOff();
            CheckLockStatus(LockStatus.Locked);
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

        public void CheckLockStatus(LockStatus status)
        {
            if (this.LockStatus == status)
                throw new ArgumentException("CCTV is locked.", nameof(LockStatus));
        }
        
        public void CheckPin(int pin)
        {
            if (this.Pin != pin)
                throw new ArgumentException("Wrong pin, police has been advised.", nameof(Pin));
        }
    }
}
