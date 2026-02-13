namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV.Repositories
{
    public interface ICCTVRepository
    {
        void Add(CCTV cctv);
        void Update(CCTV cctv);
        void Remove(Guid id);
        CCTV GetById(Guid id);
        List<CCTV> GetAll();
    }
}
