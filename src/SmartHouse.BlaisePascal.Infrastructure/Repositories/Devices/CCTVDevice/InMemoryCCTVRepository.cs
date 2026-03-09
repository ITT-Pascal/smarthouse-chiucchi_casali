using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;

namespace SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.CCTVDevice
{
    public class InMemoryCCTVRepository:ICCTVRepository
    {
        private readonly List<CCTV> _cctvs;

        public InMemoryCCTVRepository()
        {
            _cctvs = new List<CCTV>
            {
                new CCTV("Pasquale", 1234),
                new CCTV("Vaccari", 4321),
                new CCTV("Salzemma", 5678)
            };
        }

        public void Add(CCTV cctv)
        {
            if (cctv == null)
                throw new ArgumentException("Can't add a null CCTV");
            _cctvs.Add(cctv);
        }

        public void Remove(Guid id)
        {
            var cctv = GetById(id);
            if (cctv != null)
                _cctvs.Remove(cctv);
        }

        public CCTV GetById(Guid id) => _cctvs.FirstOrDefault(cctv => cctv.Id == id);

        public List<CCTV> GetAll() => _cctvs;

        public void Update(CCTV cctv)
        {
            //TODO
        }
    }
}
