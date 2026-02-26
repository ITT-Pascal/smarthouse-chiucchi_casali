using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Enums;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.Interfaces;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Abstractions
{
    public abstract class AbstractDevice: IDevice
    {
        public Guid Id { get; protected set; }
        public Name Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }

        public DateTime CreationTime_UTC { get; protected set; }
        public DateTime LastModification_UTC { get; protected set; }

        protected AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = Name.Create(name);

            Status = DeviceStatus.Off;

            CreationTime_UTC = DateTime.UtcNow;
            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void SetName(string name)
        {
            if (name != null)
                Name = Name.Create(name);

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void Toggle()
        {
            if (Status == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            CheckIsOff();

            Status = DeviceStatus.Off;

            LastModification_UTC = DateTime.UtcNow;
        }

        public virtual void SwitchOn()
        {
            CheckIsOn();

            Status = DeviceStatus.On;

            LastModification_UTC = DateTime.UtcNow;
        }

        public void CheckIsOff()
        {
            if (Status == DeviceStatus.Off)
                throw new ArgumentException($"{Name} is off.");
        }

        public void CheckIsOn()
        {
            if (Status == DeviceStatus.On)
                throw new ArgumentException($"{Name} is on.");
        }
    }
}















































//╰(*°▽°*)╯ viva i test