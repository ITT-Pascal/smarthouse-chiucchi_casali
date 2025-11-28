using SmartHouse.BlaisePascal.Domain.ElectroDomestics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public abstract class DeviceProperties
    {
        public abstract Guid Id { get; protected set; }
        public virtual string Name { get; protected set; } = string.Empty;
        public abstract DeviceStatus Status { get; protected set; }

        public abstract DateTime CreationTime_UTC { get; protected set; }
        public abstract DateTime LastModification_UTC { get; protected set; }

        protected DeviceProperties(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime_UTC = DateTime.UtcNow;
            LastModification_UTC = DateTime.UtcNow;
        }
    }
}
