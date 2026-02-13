namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Door.Repositories
{
    public interface IDoorRepository
    {
        void Add(Door door);
        void Update(Door door);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<Door> GetAll();
    }
}
