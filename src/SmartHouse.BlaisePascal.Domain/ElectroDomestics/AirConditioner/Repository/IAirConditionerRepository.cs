using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.Repository
{
    public interface IAirConditionerRepository
    {
        void Add(AirConditioner airConditioner);
        void Update(AirConditioner airConditioner);
        void Remove(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
