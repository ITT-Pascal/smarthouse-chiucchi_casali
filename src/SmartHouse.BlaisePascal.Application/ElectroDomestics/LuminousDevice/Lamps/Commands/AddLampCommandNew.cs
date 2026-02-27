using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class AddLampCommandNew
    {
        private readonly ILampRepository _lampRepository;

        public AddLampCommandNew(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }
    }
}
