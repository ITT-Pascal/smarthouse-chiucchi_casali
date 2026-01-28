using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public interface IDevice:ISwitchable
    {
        void SetName(string name);
    }
}
